using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_ecmall.WebUI.Areas.Inventory.Models
{
    /// <summary>
    /// shangpin xiajia
    /// </summary>
    public class CloseSku
    {
        /// <summary>
        /// 
        /// </summary>
        public string Sku { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Result { get; set; }
    }
}