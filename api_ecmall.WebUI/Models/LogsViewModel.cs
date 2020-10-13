using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using api_ecmall.Domain.Entities;

namespace api_ecmall.WebUI.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class LogsViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int page { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int index { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<LoggerInfo> info { get; set; }
    }
}