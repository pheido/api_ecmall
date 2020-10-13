using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_ecmall.WebUI.Areas.Pay.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class payExInfoOmsViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string Orderno { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PaymentMethodSystemName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PayTransactionId { get; set; }
    }
}