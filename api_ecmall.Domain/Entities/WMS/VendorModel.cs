using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_ecmall.Domain.Entities.WMS
{
    public class VendorModel
    {
        /// <summary>
        /// 供应商（委托人）外部编号
        /// </summary>
        //[Required(ErrorMessage ="{0}必须字段")]
        public int OutId { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string Name { get; set; }
    }
}
