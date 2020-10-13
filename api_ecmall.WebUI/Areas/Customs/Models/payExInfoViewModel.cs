using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using api_ecmall.Domain.Entities;

namespace api_ecmall.WebUI.Areas.Customs.Models
{
    public class payExInfoViewModel:payExInfo
    {
        public string Message { get; set; }
    }
}