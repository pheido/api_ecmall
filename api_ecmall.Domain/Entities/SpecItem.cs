using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_ecmall.Domain.Entities
{
    //[Table("SpecItems")]
    public class SpecItem
    {
        [Key]
        public int id { get; set; }
        public Guid ItemGuid { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        public int ProductID { get; set; }
        ///// <summary>
        ///// 规格ID
        ///// </summary>
        //public int SpecID { get; set; }
        /// <summary>
        /// 规格编码
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string Sku { get; set; }
        ///// <summary>
        ///// 表示颜色的商品图片URL
        ///// </summary>
        //public string Spec1 { get; set; }
        ///// <summary>
        ///// 规格2值
        ///// </summary>
        //public string Spec2 { get; set; }
        ///// <summary>
        ///// 规格3值
        ///// </summary>
        //public string Spec3 { get; set; }
        ///// <summary>
        ///// 规格4值
        ///// </summary>
        //public string Spec4 { get; set; }
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
        /// 规格组合，遍历规格组合，拼接json
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string AttrComb { get; set; }
        [Range(0,9999)]
        public int CiqCountry { get; set; }
        //[Required(ErrorMessage = "{0}必须字段")]
        public string Gtin { get; set; }
        /// <summary>
        /// 国际码
        /// </summary>
        public string InternationalCode { get; set; }
    }
    public enum enumPublished
    {
        publist=1,
        nopublist=0
    }
}
