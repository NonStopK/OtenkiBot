using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OtenkiBotCore.Entity
{
    /// <summary>
    /// 都道府県マスタ
    /// </summary>
    public class PrefectureMst
    {
        /// <summary>
        /// 都道府県ID(PK)
        /// </summary>
        [Key]
        public int PrefectureMstId { get; set; }

        /// <summary>
        /// 都道府県名
        /// </summary>
        public string PrefectureName { get; set; }

        /// <summary>
        /// 子：市町村マスタ
        /// </summary>
        public virtual ICollection<CityMst> CityMst { get; set; }
    }
}
