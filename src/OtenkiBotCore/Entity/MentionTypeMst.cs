using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OtenkiBotCore.Entity
{
    /// <summary>
    /// 発言タイプマスタ
    /// </summary>
    public class MentionTypeMst
    {
        /// <summary>
        /// 発言タイプ
        /// </summary>
        public enum MentionType
        {
            /// <summary>
            /// ひとりごと
            /// </summary>
            Soliloquy = 1,

            /// <summary>
            /// 解析不能
            /// </summary>
            Unknown = 2
        }

        /// <summary>
        /// 発言タイプID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MentionTypeMstId { get; set; }

        /// <summary>
        /// 発言タイプ名
        /// </summary>
        public string MentionTypeName { get; set; }

        /// <summary>
        /// 詳細
        /// </summary>
        public string Detail { get; set; }

        /// <summary>
        /// 子：発言キーワードマスタ
        /// </summary>
        public virtual ICollection<MentionKeywordMst> MentionKeywordMst { get; set; }

        /// <summary>
        /// 子：発言サブタイプマスタ
        /// </summary>
        public virtual ICollection<MentionSubTypeMst> MentionSubTypeMst { get; set; }
    }
}
