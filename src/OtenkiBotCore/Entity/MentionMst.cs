using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OtenkiBotCore.Entity
{
    /// <summary>
    /// 発言マスタ
    /// </summary>
    public class MentionMst
    {
        /// <summary>
        /// 発言ID(PK)
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MentionMstId { get; set; }

        /// <summary>
        /// 発言タイプID(FK)
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Association("MentionMst_MentionSubTypeMst", "MentionTypeMstId", "MentionTypeMstId")]
        public int MentionTypeMstId { get; set; }

        /// <summary>
        /// 発言サブタイプID(FK)
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Association("MentionMst_MentionSubTypeMst", "MentionSubTypeMstId", "MentionSubTypeMstId")]
        public int MentionSubTypeMstId { get; set; }

        /// <summary>
        /// 発言
        /// </summary>
        public string Mention { get; set; }

        /// <summary>
        /// 親：発言サブタイプマスタ
        /// </summary>
        public virtual MentionSubTypeMst MentionSubTypeMst { get; set; }
    }
}
