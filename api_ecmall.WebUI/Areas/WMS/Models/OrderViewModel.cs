using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using api_ecmall.Domain.Entities.Orders;

namespace api_ecmall.WebUI.Areas.WMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderViewModel : Order
    {
        /// <summary>
        /// 电商平台海关代码
        /// </summary>
        public string ebpCode { get; set; }
        /// <summary>
        /// 电商平台海关名称
        /// </summary>
        public string ebpName { get; set; }
        /// <summary>
        /// 电商企业海关代码
        /// </summary>
        public string ebcCode { get; set; }
        /// <summary>
        /// 电商企业海关名称
        /// </summary>
        public string ebcName { get; set; }
        /// <summary>
        /// 检查检验电商平台备案编号
        /// </summary>
        public string ecpCode { get; set; }
        /// <summary>
        /// 检查检验电商企业备案编号
        /// </summary>
        public string cbeCode { get; set; }
    }
}