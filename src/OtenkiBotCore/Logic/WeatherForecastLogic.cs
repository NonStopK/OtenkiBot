using OtenkiBotCore.Entity;
using System.Linq;

namespace OtenkiBotCore.Logic
{
    /// <summary>
    /// 地域に関するデータを制御するクラス
    /// </summary>
    public class WeatherForecastLogic
    {
        /// <summary>
        /// 発言を解析して天気予報の対象地域を取得します。
        /// </summary>
        /// <param name="mention">発言</param>
        /// <returns>地域</returns>
        public ForecastAreaRelationship GetTargetArea(string mention)
        {
            using (var context = new OtenkiBotDbContext())
            {
                var t = from f in context.ForecastAreaRelationships
                        join c in context.CityMsts
                        on f.CityMstId equals c.CityMstId
                        where mention.Contains(f.Area)
                        orderby f.Priority
                        select f;

                if (t.Count() == 0)
                {
                    return null;
                }
                else
                {
                    // 遅延読み込み
                    var rec = t.First();
                    context.Entry(rec).Reference("CityMst").Load();
                    context.Entry(rec.CityMst).Reference("PrefectureMst").Load();
                    return rec;
                }
            }
        }
    }
}
