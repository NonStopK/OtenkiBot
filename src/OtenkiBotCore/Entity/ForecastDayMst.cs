using System.ComponentModel.DataAnnotations;

namespace OtenkiBotCore.Entity
{
    /// <summary>
    /// 天気予報日マスタ
    /// </summary>
    public class ForecastDayMst
    {
        /// <summary>
        /// ForecastDayMstを初期化します。
        /// </summary>
        public ForecastDayMst()
        {
            Keyword = "今日";
            TargetIndex = 0;
        }

        /// <summary>
        /// 天気予報日マスタID(PK)
        /// </summary>
        [Key]
        public int ForecastDayMstId { get; set; }

        /// <summary>
        /// 検索文字列
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// 予報対象インデックス
        /// </summary>
        public int TargetIndex { get; set; }

        /// <summary>
        /// 優先順位
        /// </summary>
        public int Priority { get; set; }
    }
}
