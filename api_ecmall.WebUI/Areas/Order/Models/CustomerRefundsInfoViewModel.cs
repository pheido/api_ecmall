using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace api_ecmall.WebUI.Areas.Orders.Models
{
    /// <summary>
    /// 退货实体
    /// </summary>
    public class CustomerRefundsInfoViewModel
    {
        /// <summary>
        /// 用户GUID
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string ClientGuid { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string ClientName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public CustomerRefundsInfo CustomerRefundsInfo { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class CustomerRefundsInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CopName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TrackingNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Action { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RefundsBillNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int OverSellNum { get; set; }
    }
}