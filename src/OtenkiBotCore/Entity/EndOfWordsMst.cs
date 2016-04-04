using System.ComponentModel.DataAnnotations;

namespace OtenkiBotCore.Entity
{
    /// <summary>
    /// 語尾マスタ
    /// </summary>
    public class EndOfWordsMst
    {
        /// <summary>
        /// 語尾ID(PK)
        /// </summary>
        [Key]
        public int EndOfWordsMstId { get; set; }

        /// <summary>
        /// 語尾文字列
        /// </summary>
        public string Word { get; set; }
    }
}
