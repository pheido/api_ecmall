using api_ecmall.WebUI.Areas.WMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_ecmall.WebUI.Areas.Inventory.Models
{
    /// <summary>
    /// 商品价格
    /// </summary>
    public class ProductPriceViewModel : ApiJsonResult<List<PriceList>>
    {
         
    }
    /// <summary>
    /// 
    /// </summary>
    public class PriceList
    {
        /// <summary>
        /// 
        /// </summary>
        public string Sku { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? StoreId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<WarehousePrice> WarehousePriceList { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class WarehousePrice
    {
        /// <summary>
        /// 
        /// </summary>
        public int? WarehouseId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Price { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class QueryProductPrice
    {
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
        public PriceChange PriceChange { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class PriceChange
    {
        /// <summary>
        /// 
        /// </summary>
        public string[] SkuList { get; set; }
    }
}