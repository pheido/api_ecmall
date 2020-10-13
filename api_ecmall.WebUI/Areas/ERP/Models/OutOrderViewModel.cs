using api_ecmall.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_ecmall.WebUI.Areas.ERP.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class OutOrderViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string ClientGuid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Order Order { get; set; }
    }
}