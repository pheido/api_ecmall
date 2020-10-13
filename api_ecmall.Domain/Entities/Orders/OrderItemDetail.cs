using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace api_ecmall.Domain.Entities.Orders
{
    [JsonObject(MemberSerialization.OptOut)]
    public class OrderItemDetail
    {
        //AttributeSku
        //Quantity
        //Price
        //TaxRates
        //OrderTax
        [Key]
        [JsonIgnore]
        public int id { get; set; }
        [JsonIgnore]
        public Guid ItemGuid { get; set; }
        /// <summary>
        /// 规格Sku（货号）
        /// </summary>
        [Required(ErrorMessage ="{0}必需字段")]
        public string AttributeSku { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        //[Required(ErrorMessage = "{0}必需字段")]
        public int Quantity { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        //[Required(ErrorMessage = "{0}必需字段")]
        public decimal Price { get; set; }
        /// <summary>
        /// 税率 跨境综合税率，一般贸易传0
        /// </summary>
        //[Required(ErrorMessage = "{0}必需字段")]
        public decimal TaxRates { get; set; }
        /// <summary>
        /// 订单综合税税额，包税商品传0
        /// </summary>
        //[Required(ErrorMessage = "{0}必需字段")]
        public decimal OrderTax { get; set; }

        //OrderDiscount
        //BarCode
        //TradeType
        //CustomsChannelId
        /// <summary>
        /// 订单折扣，无折扣传0
        /// </summary>
        //[Required(ErrorMessage = "{0}必需字段")]
        public decimal OrderDiscount { get; set; }
        /// <summary>
        /// 国际通用的商品条形码，一般由前缀部分、制造厂商代码、商品代码和校验码组成。最大20位英文字母+数字
        /// </summary>
        //[Required(ErrorMessage = "{0}必需字段")]
        [MaxLength(50)]
        public string BarCode { get; set; }
        /// <summary>
        /// 贸易类型 1：保税备货 2：直邮 3:一般贸易
        /// </summary>
        //[Required(ErrorMessage = "{0}必需字段")]
        [EnumDataType(typeof(tradeType))]
        public int TradeType { get; set; }
        /// <summary>
        /// 报关通道ID（仓库ID）
        /// </summary>
        //[Required(ErrorMessage = "{0}必需字段")]
        public int? CustomsChannelId { get; set; }
        public int? WarehouseId { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
    }
}
