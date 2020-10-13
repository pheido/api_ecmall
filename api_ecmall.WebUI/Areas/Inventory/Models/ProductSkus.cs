using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_ecmall.WebUI.Areas.Inventory.Models
{
    /// <summary>
    /// OMS请求的sku实体
    /// </summary>
    public class ProductSkus
    {
        /// <summary>
        /// Sku数组
        /// </summary>
        public string[] SkuList { get; set; }
    }
}