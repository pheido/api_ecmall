using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using api_ecmall.Domain.Entities.Pay;

namespace api_ecmall.WebUI.Areas.Customs.Models
{
    public class WxpayViewModel
    {
        public string wxpayCode { get; set; }
        public string wxshopId { get; set; }
        public string wxappId { get; set; }
        public wxpay wxpay { get; set; }
    }
}