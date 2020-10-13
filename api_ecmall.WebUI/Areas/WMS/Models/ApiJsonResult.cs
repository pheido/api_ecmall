using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace api_ecmall.WebUI.Areas.WMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiJsonResult<T> where T:class
    {
        //[Required(ErrorMessage = "{0}必须字段")]
        /// <summary>
        /// 
        /// </summary>
        public bool success { get; set; }
        //[Required(ErrorMessage = "{0}必须字段")]
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string msg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public T data { get; set; }
    }
}