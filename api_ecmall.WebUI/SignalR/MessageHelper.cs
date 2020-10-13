using api_ecmall.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_ecmall.WebUI.SignalR
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public delegate void MessageHelp(payExInfo info);
    /// <summary>
    /// 
    /// </summary>
    public static class MessageHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public static event MessageHelp envenMessageHelp;
        /// <summary>
        /// 
        /// </summary>
        public static void Helper(payExInfo info)
        {
            envenMessageHelp(info);
        }
    }
}