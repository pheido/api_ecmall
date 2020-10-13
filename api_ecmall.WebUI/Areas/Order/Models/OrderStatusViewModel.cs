using api_ecmall.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace api_ecmall.WebUI.Areas.Orders.Models
{
    /// <summary>
    /// ecmall取消订单时传给oms的订单状态
    /// </summary>
    public class OrderStatusViewModel
    {
        /// <summary>
        /// 状态
        /// </summary>
        [EnumDataType(typeof(enum_OrderStatu))]
        public int OrderStatusId { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { get; set; }
    }
}