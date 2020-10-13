using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace api_ecmall.WebUI.Areas.ERP.Models
{
    /// <summary>
    /// 客户实体
    /// </summary>
    public class ClientViewModel
    {
        /// <summary>
        /// 用户GUID
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string ClientGuid { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string ClientName { get; set; }
    }
}