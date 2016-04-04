using OtenkiBotCore.Entity;
using OtenkiBotCore.Forecast.Yahoo;
using OtenkiBotCore.Logic;

namespace OtenkiBotCore.TweetController
{
    /// <summary>
    /// 天気予報の発言を生成するクラス
    /// </summary>
    public class ForecastReplyCreator : IReplyCreator
    {
        /// <summary>
        /// 発言テンプレート(例：埼玉県 さいたま - mm日（x）の天気は 晴時々曇、最高気温は n℃、最低気温は n℃ です。)
        /// </summary>
        private const string FORECAST_TMP = "{0} {1} - {2}の天気は {3}、最高気温は {4}、最低気温は {5} {6}";

        /// <summary>
        /// 予報エリア関係情報
        /// </summary>
        public ForecastAreaRelationship Area { get; private set; }

        /// <summary>
        /// ForecastReplyCreatorを初期化します。
        /// </summary>
        /// <param name="area">予報エリア関係情報</param>
        public ForecastReplyCreator(ForecastAreaRelationship area)
        {
            Area = area;
        }

        /// <summary>
        /// 天気予報の発言を生成します。
        /// </summary>
        /// <param name="mention">発言</param>
        /// <returns>リプライ内容</returns>
        public string CreateReply(string mention)
        {
            // 地域取得できた ⇒ 予報リスト取得
            var feed = new YahooRequestor().GetFeed(Area.CityMst.ForecastUrl);
            var xml = new YahooXmlParser().Parse(feed);
            var list = new CustomForecastCreator().Create(xml);

            // 予報日を取得する
            var day = new ForecastDayLogic().GetTargetDay(mention);

            // 語尾を取得する
            var eow = new EndOfWordsMstLogic().GetRandomOne();

            // 予報リストから対象日の予報を取得してリプライを組み立てる
            var f = list[day.TargetIndex];
            var s = string.Format(
                FORECAST_TMP,
                Area.CityMst.PrefectureMst.PrefectureName,
                Area.CityMst.CityName,
                f.Day,
                f.Forecast,
                f.Temperature.Max,
                f.Temperature.Min,
                eow
                );

            return s;
        }
    }
}
