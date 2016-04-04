using System.ComponentModel.DataAnnotations;

namespace OtenkiBotCore.Entity
{
    /// <summary>
    /// 発言キーワードマスタ
    /// </summary>
    public class MentionKeywordMst
    {
        /// <summary>
        /// 発言キーワードID(PK)
        /// </summary>
        [Key]
        public int MentionKeywordsMstId { get; set; }

        /// <summary>
        /// 発言タイプID(FK)
        /// </summary>
        [Association("MentionKeywordsMst_MentionTypeMst", "MentionTypeMstId", "MentionTypeMstId")]
        public int MentionTypeMstId { get; set; }

        /// <summary>
        /// 検索文字列
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// 優先順位
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// 親：発言タイプマスタ
        /// </summary>
        public virtual MentionTypeMst MentionTypeMst { get; set; }
    }
}
