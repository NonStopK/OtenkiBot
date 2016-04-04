using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OtenkiBotCore.Entity
{
    /// <summary>
    /// 発言サブタイプマスタ
    /// </summary>
    public class MentionSubTypeMst
    {
        /// <summary>
        /// 発言タイプ
        /// </summary>
        public enum MentionSubType
        {
            /// <summary>
            /// 解析不能
            /// </summary>
            Unknown = 0
        }

        /// <summary>
        /// 発言サブタイプID
        /// </summary>
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MentionSubTypeMstId { get; set; }

        /// <summary>
        /// 発言サブタイプ名
        /// </summary>
        public string MentionSubTypeName { get; set; }

        /// <summary>
        /// 発言タイプID(FK)
        /// </summary>
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Association("MentionMst_MentionTypeMst", "MentionTypeMstId", "MentionTypeMstId")]
        public int MentionTypeMstId { get; set; }

        /// <summary>
        /// 開始日
        /// </summary>
        public int BeginDate { get; set; }

        /// <summary>
        /// 開始時刻
        /// </summary>
        public int BeginTime { get; set; }

        /// <summary>
        /// 終了日
        /// </summary>
        public int EndDate { get; set; }

        /// <summary>
        /// 終了時刻
        /// </summary>
        public int EndTime { get; set; }

        /// <summary>
        /// 詳細
        /// </summary>
        public string Detail { get; set; }

        /// <summary>
        /// 親：発言タイプマスタ
        /// </summary>
        public virtual MentionTypeMst MentionTypeMst { get; set; }

        /// <summary>
        /// 子：発言マスタ
        /// </summary>
        public virtual ICollection<MentionMst> MentionMst { get; set; }
    }
}
