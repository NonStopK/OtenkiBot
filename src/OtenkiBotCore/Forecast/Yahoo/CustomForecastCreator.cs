using System;
using System.Collections.Generic;

namespace OtenkiBotCore.Forecast.Yahoo
{
    public class CustomForecastCreator : ICustomForecastCreator
    {
        public List<CustomForecast> Create(List<YahooForecast> list)
        {
            var cList = new List<CustomForecast>();
            int i = 0;

            foreach (var item in list)
            {
                var c = new CustomForecast()
                {
                    Title = item.Title,
                    Link = item.Link,
                    Description = item.Description,
                    PubDate = item.PubDate,
                    Day = GetDay(item.Title),
                    Forecast = GetForecast(item.Description),
                    Temperature = GetTemperature(item.Description),
                };
                c.RelativeDay = GetRelativeDay(c.Day) ? i : -1;
                cList.Add(c);
                i++;    // 次のRelativeDayのためにインクリメント
            }

            // 予報でないリストを削除
            cList.RemoveAll(item => item.RelativeDay == -1);

            return cList;
        }

        private string GetDay(string target)
        {
            // <title>【 1日（木） 南部（さいたま） 】 晴時々曇 - 6℃/0℃ - Yahoo!天気・災害</title>
            // ⇒1日（木）
            try
            {
                var array = target.Split(' ');
                return array[1];
            }
            catch
            {
                return string.Empty;
            }
        }

        private string GetForecast(string target)
        {
            // <description>晴時々曇 - 6℃/0℃</description>
            // ⇒晴時々曇
            try
            {
                var array = target.Split(' ');
                return array[0];
            }
            catch
            {
                return string.Empty;
            }
        }

        private Temperature GetTemperature(string target)
        {
            // <description>晴時々曇 - 6℃/0℃</description>
            // ⇒6℃/0℃
            try
            {
                var array = target.Split(new[] { " - " }, StringSplitOptions.None);
                array = array[1].Split('/');
                return new Temperature()
                {
                    Max = array[0],
                    Min = array[1]
                };
            }
            catch
            {
                return new Temperature();
            }
        }

        private bool GetRelativeDay(string target)
        {
            //  1日（木）
            try
            {
                var startIndex = target.IndexOf("日");
                var day = target.Substring(0, startIndex);
                int result;
                return int.TryParse(day, out result);
            }
            catch
            {
                return false;
            }
        }
    }
}
