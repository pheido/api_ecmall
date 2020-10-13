using api_ecmall.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_ecmall.WebUI.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class LogsAntViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public Pagination pagination { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<LoggerInfo> list { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class Pagination
    {
        /// <summary>
        /// 
        /// </summary>
        public int total { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pageSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int current { get; set; }
    }
}