using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OtenkiBotCore.Entity
{
    /// <summary>
    /// 予報エリア関係
    /// </summary>
    public class ForecastAreaRelationship
    {
        /// <summary>
        /// 市町村ID(PK)
        /// </summary>
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CityMstId { get; set; }

        /// <summary>
        /// エリア(PK)
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public string Area { get; set; }

        /// <summary>
        /// 優先順位
        /// </summary>
        public int? Priority { get; set; }

        /// <summary>
        /// 親：市町村マスタ
        /// </summary>
        public virtual CityMst CityMst { get; set; }
    }
}
