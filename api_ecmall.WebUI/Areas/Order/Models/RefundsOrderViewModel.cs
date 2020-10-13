using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace api_ecmall.WebUI.Areas.Orders.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class RefundsOrderViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> PaymentNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [EnumDataType(typeof(enum_RefundStatus))]
        public int RefundStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [EnumDataType(typeof(enum_IsEnabled))]
        public int IsEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int VendorId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string VendorName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int GoodsNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ConfirmNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Currency { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal OrderTotal { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public decimal TaxTotal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Freight { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Total { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime OrderCreateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? StockInTime { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string RefundsBillNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WishNo { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public enum enum_RefundStatus
    {
        /// <summary>
        /// 待确认
        /// </summary>
        waitack = 100,
        /// <summary>
        /// 待退款
        /// </summary>
        waitrefund = 200,
        /// <summary>
        /// 已退款
        /// </summary>
        refunded = 300,
        /// <summary>
        /// 退款关闭
        /// </summary>
        overrefund = 400
    }
    /// <summary>
    /// 
    /// </summary>
    public enum enum_IsEnabled
    {
        /// <summary>
        /// 
        /// </summary>
        isot = 0,
        /// <summary>
        /// 
        /// </summary>
        notis = 1
    }
    /// <summary>
    /// 
    /// </summary>
    public class RefundQueryOrderViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public RefundQueryOrder QueryOrders { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class RefundQueryOrder
    {
        /// <summary>
        /// 
        /// </summary>
        [EnumDataType(typeof(enum_IsCustomerRefunds))]
        public bool IsCustomerRefunds { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public enum enum_IsCustomerRefunds
    {
        /// <summary>
        /// 
        /// </summary>
        need = 1,
        /// <summary>
        /// 
        /// </summary>
        notneed = 0
    }
}