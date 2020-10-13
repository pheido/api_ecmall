using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_ecmall.WebUI.Areas.ERP.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiJsonResult
    {
        /// <summary>
        /// 
        /// </summary>
        public bool success { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string data { get; set; }
    }
}