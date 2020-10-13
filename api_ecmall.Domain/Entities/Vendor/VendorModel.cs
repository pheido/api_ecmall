using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace api_ecmall.Domain.Entities.Vendor
{
    /// <summary>
    /// 店铺状态更改实体
    /// </summary>
    public class VendorModel
    {
        /// <summary>
        /// 店铺名称
        /// </summary>
        [Required(ErrorMessage ="{0}必须字段")]
        public string Name { get; set; }
        /// <summary>
        /// 店铺（供应商）id
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        [RegularExpression(@"\d+")]
        public string ExternCode { get; set; }
        /// <summary>
        /// 店铺（供应商）地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 是否启用 1：启用 0：禁用
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        [EnumDataType(typeof(ActiveStatus))]
        public string Active { get; set; }
    }
    /// <summary>
    /// 是否启用 1：启用 0：禁用
    /// </summary>
    public enum ActiveStatus
    {
        noactive=0,
        active=1
    }
}
