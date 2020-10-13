using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_ecmall.Domain.Entities.WMS
{
    /// <summary>
    /// 商品规格值实体
    /// </summary>
    public class AttributeValueList
    {
        /// <summary>
        /// 规格id
        /// </summary>
        public int AttributeId { get; set; }
        /// <summary>
        /// 规格值id
        /// </summary>
        public int AttributeValueId { get; set; }
        /// <summary>
        /// 规格值名称
        /// </summary>
        [Required(ErrorMessage =("{0}必须字段"))]
        public string AttributeValueName { get; set; }
    }
}
