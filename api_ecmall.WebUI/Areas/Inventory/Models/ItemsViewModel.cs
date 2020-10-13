using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using api_ecmall.Domain.Entities;

namespace api_ecmall.WebUI.Areas.Inventory.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ItemsViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ClientGuid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ClientName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ProductItem Item { get; set; }
    }
}