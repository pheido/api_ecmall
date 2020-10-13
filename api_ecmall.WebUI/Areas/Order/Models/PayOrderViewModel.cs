using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using api_ecmall.Domain.Entities.Pay;
using api_ecmall.Domain.Entities;

namespace api_ecmall.WebUI.Areas.Orders.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class PayOrderViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public UserInfo userinfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public PayOrder payorder { get; set; }
    }
}