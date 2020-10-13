using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_ecmall.Domain.Entities.WMS
{
    /// <summary>
    /// 商品规格表   请求来源OMS  转发目的  WMS
    /// </summary>
    public class ProductAttribute
    {
        /// <summary>
        /// 规格id
        /// </summary>
        public int AttributeId { get; set; }
        /// <summary>
        /// 规格名称
        /// </summary>
        [Required(ErrorMessage =("{0}必须字段"))]
        public string AttributeName { get; set; }
    }
}
