using OtenkiBotCore.Entity;
using System.Linq;

namespace OtenkiBotCore.Logic
{
    /// <summary>
    /// 天気予報：天気予報日に関わるデータを制御するクラス
    /// </summary>
    public class ForecastDayLogic
    {
        /// <summary>
        /// 発言を解析して対象の予報日を取得します。解析できない場合は当日を取得します。
        /// </summary>
        /// <param name="mention">発言</param>
        /// <returns>予報日</returns>
        public ForecastDayMst GetTargetDay(string mention)
        {
            using (var context = new OtenkiBotDbContext())
            {
                var t = from f in context.ForecastDayMsts
                        where mention.Contains(f.Keyword)
                        orderby f.Priority
                        select f;

                // 「当日」はForecastDayMstのコンストラクタに委ねる
                return (t.Count() == 0) ?
                    new ForecastDayMst() : t.First();
            }
        }
    }
}
