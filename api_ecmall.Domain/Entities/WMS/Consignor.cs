using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_ecmall.Domain.Entities.WMS
{
    /// <summary>
    /// 发货人同步实体
    /// </summary>
    public class Consignor
    {
        /// <summary>
        /// 发货人地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 发货人电话
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string Phone { get; set; }
        /// <summary>
        /// 发货人外部编号
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string OutId { get; set; }
        /// <summary>
        /// 发货人姓名
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string Name { get; set; }
    }
}
