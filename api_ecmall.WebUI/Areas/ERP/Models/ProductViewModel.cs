using api_ecmall.Domain.Entities;
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
    public class ProductViewModel:ClientViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public List<ProductItemERP> ProductItems { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class ProductItemERP
    {
        #region ///one
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string ShortDescription { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int VendorId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Sku { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string Spu { get; set; }
        #endregion


        #region ///two
        /// <summary>
        /// 
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int WarehouseId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal HKGPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal ERUPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal CHNPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        #endregion


        #region ///three
        /// <summary>
        /// 
        /// </summary>
        public decimal DBAPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal HKGCost { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal ERUCost { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal CHNCost { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal DBACost { get; set; }
        #endregion


        #region ///four
        /// <summary>
        /// 
        /// </summary>
        public decimal OldPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal StockQuantity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int SpecCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string Manufacturer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string ProductTags { get; set; }
        #endregion


        #region ///five
        /// <summary>
        /// 
        /// </summary>
        public int Published { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [EnumDataType(typeof(enumGoodsShelvessStatus))]
        public int? GoodsOnShelvesStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreatedOnUtc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdateOnUtc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CreatedTimeStamp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UpdateTimeStamp { get; set; }
        #endregion


        #region ///six
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string DefaultImg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int SortNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string HsCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CountryId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string CountryName { get; set; }
        #endregion


        #region ///seven
        /// <summary>
        /// 
        /// </summary>
        public string UnitId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string UnitName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WrapId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string WrapName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal VATRate { get; set; }
        #endregion


        #region ///eight
        /// <summary>
        /// 
        /// </summary>
        public decimal ConsumtionTaxRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TradeType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CustomsChannelId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int UploadType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int UploadStatus { get; set; }
        #endregion


        #region ///nine
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string ProductImgs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string DetailsImgs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CiqCountry { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[Required(ErrorMessage = "{0}必须字段")]
        public string Gtin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string InternationalCode { get; set; }
        #endregion


        #region ///ten
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string Material { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProductionCompany { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal ShortInSizePrice { get; set; }
        /// <summary>
        /// 年代
        /// </summary>
        public string Times { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<SpecItemERP> SpecItems { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        #endregion
    }
    /// <summary>
    /// 
    /// </summary>
    public class SpecItemERP
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public int ProductId { get; set; }
        ///// <summary>
        ///// 规格ID
        ///// </summary>
        //public int SpecID { get; set; }
        /// <summary>
        /// 规格编码
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string Sku { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 库存数量
        /// </summary>
        public int StockNum { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        //[Required(ErrorMessage = "{0}必须字段")]
        public DateTime CreatTime { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        //CustomsChannelId
        //HsCode
        //CountryId
        //CountryName
        //UnitId
        /// <summary>
        /// 报关通道（仓库）id
        /// </summary>
        public int CustomsChannelId { get; set; }
        /// <summary>
        /// 商品海关编码（对应海关HSCODE表）一般贸易不传
        /// </summary>
        public string HsCode { get; set; }
        /// <summary>
        /// 原产地国家（地区）海关代码（对应海关国家地区代码表）一般贸易不传
        /// </summary>
        public int CountryId { get; set; }
        /// <summary>
        /// 原产地国家（地区）名称（对应海关国家地区代码表）
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string CountryName { get; set; }
        /// <summary>
        /// 销售单位海关代码（对应海关单位代码表）一般贸易不传
        /// </summary>
        public string UnitId { get; set; }



        //UnitName
        //WarpId
        //WarpName
        //VATRate
        //ConsumptionTaxRate

        /// <summary>
        /// 销售单位名称（对应海关单位代码表）
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string UnitName { get; set; }
        /// <summary>
        /// 包装类别海关代码（对应海关包装类别代码表）一般贸易不传
        /// </summary>
        public string WrapId { get; set; }
        /// <summary>
        /// 包装类别海关名称（对应海关包装类别代码表）
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string WrapName { get; set; }
        /// <summary>
        /// 增值税率 一般贸易不传
        /// </summary>
        public decimal VATRate { get; set; }
        /// <summary>
        /// 消费税率 一般贸易不传
        /// </summary>
        public decimal ConsumptionTaxRate { get; set; }

        //TradeType
        //Published
        //AttrComb

        /// <summary>
        /// 贸易类型 1:保税备货 2：直邮 3：一般贸易
        /// </summary>
        [EnumDataType(typeof(TradeType))]
        public int TradeType { get; set; }
        /// <summary>
        /// 是否启用 1：启用 0：不启用
        /// </summary>
        [EnumDataType(typeof(enumPublished))]
        public int Published { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [EnumDataType(typeof(enumGoodsShelvessStatus))]
        public int? GoodsOnShelvesStatus { get; set; }
        /// <summary>
        /// 规格组合，遍历规格组合，拼接json
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string AttrComb { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Range(0, 9999)]
        public int CiqCountry { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[Required(ErrorMessage = "{0}必须字段")]
        public string Gtin { get; set; }
        /// <summary>
        /// 国际码
        /// </summary>
        public string InternationalCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsShortInSize { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public enum enumGoodsShelvessStatus
    {
        /// <summary>
        /// 
        /// </summary>
        wei = 10,
        /// <summary>
        /// 
        /// </summary>
        yishang = 20,
        /// <summary>
        /// 
        /// </summary>
        yixia = 30
    }
}