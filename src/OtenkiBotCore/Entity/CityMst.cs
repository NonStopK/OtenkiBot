using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OtenkiBotCore.Entity
{
    /// <summary>
    /// 市町村マスタ
    /// </summary>
    public class CityMst
    {
        /// <summary>
        /// 市町村マスタID(PK)
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CityMstId { get; set; }

        /// <summary>
        /// 市町村名
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// 都道府県ID(FK)
        /// </summary>
        [Association("CityMst_PrefectureMst", "PrefectureMstId", "PrefectureMstId")]
        public int PrefectureMstId { get; set; }

        /// <summary>
        /// 県庁所在地
        /// </summary>
        public bool PrefecturalSeat { get; set; }

        /// <summary>
        /// 予報URL
        /// </summary>
        public string ForecastUrl { get; set; }

        /// <summary>
        /// 親：都道府県マスタ
        /// </summary>
        public virtual PrefectureMst PrefectureMst { get; set; }

        /// <summary>
        /// 子：予報エリア関係
        /// </summary>
        public virtual ICollection<ForecastAreaRelationship> ForecastAreaRelationships { get; set; }
    }
}
