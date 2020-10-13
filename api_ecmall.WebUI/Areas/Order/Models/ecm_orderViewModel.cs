using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using api_ecmall.Domain.Entities;

namespace api_ecmall.WebUI.Areas.Orders.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ecm_orderViewModel: Domain.Entities.Order_1
    {
        /// <summary>
        /// 
        /// </summary>
        public List<ecm_order_goods> goods { get; set; }
    }
}