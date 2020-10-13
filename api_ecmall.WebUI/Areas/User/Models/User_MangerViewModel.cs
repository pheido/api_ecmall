using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using api_ecmall.Domain.Entities;

namespace api_ecmall.WebUI.Areas.User.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class User_MangerViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public AspNetUser aspNetUser { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public UserInfo userInfo { get; set; }

    }
}