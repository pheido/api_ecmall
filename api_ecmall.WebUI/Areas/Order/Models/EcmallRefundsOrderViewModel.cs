using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_ecmall.WebUI.Areas.Orders.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class EcmallRefundsOrderViewModel
    {
        /// <summary>
        /// 注册系统Id
        /// </summary>
        public string ClientGuid { get; set; }
        /// <summary>
        /// 注册系统名称
        /// </summary>
        public string ClientName { get; set; }
        /// <summary>
        /// 单据编号
        /// </summary>
        public string BillNo { get; set; }
        /// <summary>
        /// 单据类型
        /// </summary>
        public int? BillType { get; set; }
        /// <summary>
        /// 支付单位名称
        /// </summary>
        public string PayName { get; set; }
        /// <summary>
        /// 支付单位编号
        /// </summary>
        public string PayCode { get; set; }
        /// <summary>
        /// 支付宝或微信的退款单号
        /// </summary>
        public string PayTransactionId { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal? PayPrice { get; set; }
        /// <summary>
        /// Ecmall退款单号
        /// </summary>
        public string RefundNo { get; set; }
    }
}