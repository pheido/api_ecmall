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
    public class QueryRefundViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string ClientGuid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ClientName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "{0}必须项")]
        public List<RefundOrder> Order { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class RefundOrder
    {
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "{0}必须项")]
        public string OrderNo { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class RefundRe
    {
        /// <summary>
        /// 
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int AllowedRefund { get; set; }
    }
}