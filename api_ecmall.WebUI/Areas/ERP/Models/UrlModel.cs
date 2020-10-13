using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_ecmall.WebUI.Areas.ERP.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class UrlModel
    {
        /// <summary>
        /// 顺序
        /// </summary>
        public string order { get; set; }
        /// <summary>
        /// URL
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 国际码
        /// </summary>
        public string InternationalCode { get; set; }
    }
}