using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace api_ecmall.WebUI.Areas.ERP.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class PriceViewModel
    {
        /// <summary>
        /// 客户端id
        /// </summary>
        public string ClientGuid { get; set; }
        /// <summary>
        /// 客户端名称
        /// </summary>
        public string ClientName { get; set; }
        /// <summary>
        /// 价格单详情
        /// </summary>
        [Required(ErrorMessage ="必须项")]
        public List<PriceModel> PriceListCollection { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class PriceModel
    {
        /// <summary>
        /// 供应商Id
        /// </summary>
        public int? VendorId { get; set; }
        /// <summary>
        /// 仓库Id
        /// </summary>
        public int? WarehouseId { get; set; }
        /// <summary>
        /// 供货价
        /// </summary>
        public decimal? Price { get; set; }
        /// <summary>
        /// Spu
        /// </summary>
        public string Spu { get; set; }
        /// <summary>
        /// 国际货号
        /// </summary>
        public string InternationalCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool? IsAvailable { get; set; }
        /// <summary>
        /// 1上架，0下架
        /// </summary>
        public int? ProductAvailbale { get; set; }
    }
}