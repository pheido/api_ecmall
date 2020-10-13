using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace api_ecmall.Domain.Entities.Orders
{
    [JsonObject(MemberSerialization.OptOut)]
    public class OrderItem
    {
        //ProductId
        //Quantity
        //PriceInclTax
        //ProductSku
        //TotalPrice
        [Key]
        [JsonIgnore]
        public Guid ItemGuid { get; set; }
        [JsonIgnore]
        public Guid OrderGuid { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        [Required(ErrorMessage ="{0}必需字段")]
        public int ProductId { get; set; }
        /// <summary>
        /// 商品实际数量。
        /// </summary>
        //[Required(ErrorMessage = "{0}必需字段")]
        public int Quantity { get; set; }
        /// <summary>
        /// 税前单价
        /// </summary>
        //[Required(ErrorMessage = "{0}必需字段")]
        public decimal PriceInclTax { get; set; }
        /// <summary>
        /// 商品Sku
        /// </summary>
        [Required(ErrorMessage = "{0}必需字段")]
        public string ProductSku { get; set; }
        /// <summary>
        /// 商品总价，等于单价乘以数量。小数点后保留两位小数
        /// </summary>
        //[Required(ErrorMessage = "{0}必需字段")]
        public decimal TotalPrice { get; set; }

        //CustomsChannelId
        //ItemName
        //ItemDescribe
        //BarCode
        //Unit
        /// <summary>
        /// 报关通道Id
        /// </summary>
        //[Required(ErrorMessage = "{0}必需字段")]
        public int? CustomsChannelId { get; set; }
        public int? WarehouseId { get; set; }
        public int? StoreId { get; set; } = 0;
        /// <summary>
        /// 交易平台销售商品的中文名称。最大125位汉字
        /// </summary>
        [Required(ErrorMessage = "{0}必需字段")]
        [MaxLength(125)]

        public string ItemName { get; set; }
        /// <summary>
        /// 交易平台销售商品的描述信息。最大500位汉字
        /// </summary>
        [MaxLength(500)]
        public string ItemDescribe { get; set; }
        /// <summary>
        /// 国际通用的商品条形码，一般由前缀部分、制造厂商代码、商品代码和校验码组成。最大20位英文字母+数字
        /// </summary>
        //[Required(ErrorMessage = "{0}必需字段")]
        [MaxLength(20)]
        public string BarCode { get; set; }
        /// <summary>
        /// 计量单位 填写海关标准的参数代码，参照《JGS-20 海关业务代码集》- 计量单位代码。最大3位数字
        /// </summary>
        [Required(ErrorMessage = "{0}必需字段")]
        [MaxLength(3)]
        public string Unit { get; set; }

        //Currency
        //CiqCurrency
        //Country
        //CiqCountry
        //Note
        /// <summary>
        /// 限定为人民币，填写“142”。
        /// </summary>
        [Required(ErrorMessage = "{0}必需字段")]
        [MaxLength(10)]
        public string Currency { get; set; }
        /// <summary>
        /// 检验检疫币制。一般贸易不传
        /// </summary>
        [Required(ErrorMessage = "{0}必需字段")]
        [MaxLength(10)]
        public string CiqCurrency { get; set; }
        /// <summary>
        /// 原产地 填写海关标准的参数代码，参照《JGS-20 海关业务代码集》-国家（地区）代码表。最大3位数字
        /// </summary>
        [Required(ErrorMessage = "{0}必需字段")]
        [MaxLength(3)]
        public string Country { get; set; }
        /// <summary>
        /// 原厂地 国检。最大4位数字 一般贸易不传
        /// </summary>
        [Required(ErrorMessage = "{0}必需字段")]
        [MaxLength(4)]
        public string CiqCountry { get; set; }
        /// <summary>
        /// 促销活动，商品单价偏离市场价格的，可以在此说明。最大500位汉字
        /// </summary>
        [MaxLength(500)]
        public string Note { get; set; }

        //ShelfGoodsName
        //WrapTypeCode
        //PurposeCode
        //VendorId
        //OrderItemDetail
        /// <summary>
        /// 品牌，最大100位汉字
        /// </summary>
        [MaxLength(100)]
        public string ShelfGoodsName { get; set; }
        /// <summary>
        /// 包装种类编号，最大5位数字，请参照检验检疫商品备案相关信息。
        /// </summary>
        [Required(ErrorMessage = "{0}必需字段")]
        [MaxLength(5)]
        public string WrapTypeCode { get; set; }
        /// <summary>
        /// 用途编号，最大5位数字，请参照检验检疫商品备案相关信息。一般贸易不传
        /// </summary>
        [Required(ErrorMessage = "{0}必需字段")]
        [MaxLength(5)]
        public string PurposeCode { get; set; }
        /// <summary>
        /// 供应商id(店铺id)
        /// </summary>
        //[Required(ErrorMessage = "{0}必需字段")]
        public int VendorId { get; set; }
        /// <summary>
        /// 商品规格明细 
        /// </summary>
        //[Required(ErrorMessage = "{0}必需字段")]
        public virtual List<OrderItemDetail> OrderItemDetails { get; set; }

        //TaxRates
        //OrderTax
        //OrderDiscount
        //TradeType
        /// <summary>
        /// 税率 跨境综合税率，一般贸易传0
        /// </summary>
        //[Required(ErrorMessage = "{0}必需字段")]
        public decimal? TaxRates { get; set; }
        /// <summary>
        /// 订单综合税税额，包税商品传0
        /// </summary>
        //[Required(ErrorMessage = "{0}必需字段")]
        public decimal OrderTax { get; set; }
        /// <summary>
        /// 订单折扣，无折扣传0
        /// </summary>
        //[Required(ErrorMessage = "{0}必需字段")]
        public decimal OrderDiscount { get; set; }
        /// <summary>
        /// 贸易类型 1：保税备货 2：直邮 3:一般贸易
        /// </summary>
        //[Required(ErrorMessage = "{0}必需字段")]
        public int? TradeType { get; set; }

    }
}
