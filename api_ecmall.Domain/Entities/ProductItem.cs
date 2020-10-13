using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_ecmall.Domain.Entities
{
    public class ProductItem
    {
        /// <summary>
        /// 自增ID
        /// </summary>
        [Display(Name = "自增ID")]
        public virtual int id { get; set; }
        [Key]
        public virtual Guid ItemGuid { get; set; } = Guid.NewGuid();
        ///// <summary>
        ///// 商品类型ID
        ///// </summary>
        //[Display(Name = "商品类型ID")]
        //public int ProductTypeId { get; set; }
        ///// <summary>
        ///// 商品类型
        ///// </summary>
        //[Display(Name = "商品类型")]
        //public string ProductType { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [Display(Name = "商品名称")]
        [Required(ErrorMessage ="{0}必须字段")]
        public string Name { get; set; }
        /// <summary>
        /// 商品简要介绍
        /// </summary>
        [Display(Name = "商品简要介绍")]
        //[Required(ErrorMessage = "{0}必须字段")]
        public string ShortDescription { get; set; }
        /// <summary>
        /// 商品介绍
        /// </summary>
        [Display(Name = "商品介绍")]
        public string FullDescription { get; set; }
        /// <summary>
        /// 供应商ID
        /// </summary>
        [Display(Name = "供应商ID")]
        public int VendorId { get; set; }
        /// <summary>
        /// 商品编码
        /// </summary>
        [Display(Name = "商品编码")]
        [Required(ErrorMessage = "{0}必须字段")]
        public string Sku { get; set; }
        ///// <summary>
        ///// 所属分类ID 末级
        ///// </summary>
        //[Display(Name = "所属分类ID 末级")]
        //public int CateId { get; set; }
        /// <summary>
        /// 税则类型ID
        /// </summary>
        [Display(Name = "税则类型ID")]
        public int TaxCategoryId { get; set; }
        /// <summary>
        /// 仓库ID
        /// </summary>
        [Display(Name = "仓库ID")]
        public int WareHoseId { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        [Display(Name = "价格")]
        public decimal Price { get; set; }
        /// <summary>
        /// 库存数量，默认为0 如开启规格则为0
        /// </summary>
        [Display(Name = "库存数量，默认为0 如开启规格则为0")]
        public decimal StockQuantity { get; set; }
        /// <summary>
        /// 市场价
        /// </summary>
        [Display(Name = "市场价")]
        public decimal OldPrice { get; set; }
        /// <summary>
        /// 规格SKU数量，未开启规格则为0
        /// </summary>
        [Display(Name = "规格SKU数量，未开启规格则为0")]
        public int SpecCount { get; set; }
        /// <summary>
        /// 品牌
        /// </summary>
        [Display(Name = "品牌")]
        [Required(ErrorMessage = "{0}必须字段")]
        public string Manufacturer { get; set; }
        /// <summary>
        /// 商品标签，以半角逗号分隔
        /// </summary>
        [Display(Name = "商品标签，以半角逗号分隔")]
        public string ProductTags { get; set; }
        /// <summary>
        /// 是否显示1、显示 0、不显示
        /// </summary>
        [Display(Name = "是否显示1、显示 0、不显示")]
        public int ShowOnHomePage { get; set; }
        /// <summary>
        /// 是否启用 1、启用 0、不启用
        /// </summary>
        [Display(Name = "是否启用 1、启用 0、不启用")]
        public int Published { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public DateTime CreatedOnUtc { get; set; }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        [Display(Name = "最后更新时间")]
        public DateTime? UpdateOnUtc { get; set; }
        /// <summary>
        /// 创建时间戳
        /// </summary>
        [Display(Name = "创建时间戳")]
        //[Required(ErrorMessage = "{0}必须字段")]
        public string CreatedTimeStamp { get; set; }
        /// <summary>
        /// 最后更新时间戳
        /// </summary>
        [Display(Name = "最后更新时间戳")]
        //[Required(ErrorMessage = "{0}必须字段")]
        public string UpdateTimeStamp { get; set; }
        /// <summary>
        /// 默认图片
        /// </summary>
        [Display(Name = "默认图片")]
        [Required(ErrorMessage = "{0}必须字段")]
        public string DefaultImg { get; set; }

        [Display(Name = "默认图片Oss路径")]
        [Required(ErrorMessage = "{0}必须字段")]
        public string DefaultOssImg { get; set; }

        ///// <summary>
        ///// 是否推荐 1、推荐 0、不推荐
        ///// </summary>
        //[Display(Name = "是否推荐 1、推荐 0、不推荐")]
        //public int IsRecommended { get; set; }
        /// <summary>
        /// 一级分类ID 如果无，即为0
        /// </summary>
        //[Display(Name = "一级分类ID 如果无，即为0")]
        //public int CateId1 { get; set; }
        ///// <summary>
        ///// 二级分类ID 如果无，即为0
        ///// </summary>
        //[Display(Name = "二级分类ID 如果无，即为0")]
        //public int CateId2 { get; set; }
        ///// <summary>
        ///// 三级分类ID 如果无，即为0
        ///// </summary>
        //[Display(Name = "三级分类ID 如果无，即为0")]
        //public int CateId3 { get; set; }
        ///// <summary>
        ///// 四级分类ID 如果无，即为0
        ///// </summary>
        //[Display(Name = "四级分类ID 如果无，即为0")]
        //public int CateId4 { get; set; }
        ///// <summary>
        ///// 规格名称1 如果SpecCount>0
        ///// </summary>
        //[Display(Name = "规格名称1 如果SpecCount>0")]
        //public string Spec1 { get; set; }
        ///// <summary>
        ///// 规格名称2 如果SpecCount>0
        ///// </summary>
        //[Display(Name = "规格名称2 如果SpecCount>0")]
        //public string Spec2 { get; set; }
        ///// <summary>
        ///// 规格名称3 如果SpecCount>0
        ///// </summary>
        //[Display(Name = "规格名称3 如果SpecCount>0")]
        //public string Spec3 { get; set; }
        ///// <summary>
        ///// 规格名称4 如果SpecCount>0
        ///// </summary>
        //[Display(Name = "规格名称4 如果SpecCount>0")]
        //public string Spec4 { get; set; }
        ///// <summary>
        ///// 最大兑换积分
        ///// </summary>
        //[Display(Name = "最大兑换积分")]
        //public int PointMax { get; set; }
        /// <summary>
        /// 搜索标签，以半角逗号分隔
        /// </summary>
        [Display(Name = "搜索标签，以半角逗号分隔")]
        public string Tag { get; set; }
        /// <summary>
        /// 排序标记 0-255
        /// </summary>
        [Display(Name = " 排序标记 0-255")]
        public int SortNum { get; set; }
        /// <summary>
        /// 规格列表 如果SpecCount>0则必须有
        /// </summary>
        [Display(Name = "规格列表 如果SpecCount>0则必须有")]
        public virtual List<SpecItem> SpecItems { get; set; }
        ///// <summary>
        ///// 是否上架1、上架 2、不上架
        ///// </summary>
        //[Display(Name = "是否上架1、上架 2、不上架")]
        //public int IsSale { get; set; }



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
        [Required(ErrorMessage = "{0}必须字段")]
        [EnumDataType(typeof(TradeType))]
        public int TradeType { get; set; }
        [Required(ErrorMessage = "{0}必须字段")]
        public string CustomsChannelId { get; set; }


        #region ///2019-05-10
        /// <summary>
        /// 修改标识：0：未修改，1：已修改 OMS调用档案上传接口无需传此字段
        /// </summary>
        public int ModifyFlag { get; set; }
        /// <summary>
        /// 图片路径，order表示排序，url表示图片所在服务器路径(图片张数 1~8 张，仅支持大于等于300*300,小于等于640*640的等宽 高 图 片 , 单张 大小 不超 过1M。仅支持 jpg,jpeg,png 格式。Json.length不能小于SpecCount的数量)
        /// </summary>
        public string ProductImgs { get; set; }
        /// <summary>
        /// 原厂地 国检。最大4位数字
        /// </summary>
        public int CiqCountry { set; get; }
        /// <summary>
        /// 条形码
        /// </summary>
        //[Required(ErrorMessage ="{0}必须字段")]
        public string Gtin { get; set; }
        /// <summary>
        /// 详情图片
        /// </summary>
        public string DetailsImgs { get; set; }
        /// <summary>
        /// 材质 20190704
        /// </summary>
        public string Material { get; set; }
        #endregion

        #region///WMS新加
        /// <summary>
        /// 上传类型 1:手动 2 自动
        /// </summary>
        //[EnumDataType(typeof(UploadeType_Enum))]
        public int UploadType { get; set; }
        /// <summary>
        /// 上传状态：1：待上传  2上传中  3 上传成功   4 上传失败
        /// </summary>
        //[EnumDataType(typeof(UploadStatus_Enum))]
        public int UploadStatus { get; set; }
        /// <summary>
        /// 国际码
        /// </summary>
        public string InternationalCode { get; set; }
        /// <summary>
        /// 生产企业名称
        /// </summary>
        public string ProductionCompany { get; set; }
        /// <summary>
        /// Erp关联吗
        /// </summary>
        public string OutCode { get; set; }
        public string ErrorMessage { get; set; }
        /// <summary>
        /// 推送类型 1仓库 2 店铺
        /// </summary>
        public int PushType { get; set; }
        /// <summary>
        /// 仓库ID
        /// </summary>
        public int WarehouseId { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public string StoreId { get; set; }
        /// <summary>
        /// 水流好
        /// </summary> 
        public string SwiftNumber { get; set; }
        /// <summary>
        /// 商品分类Id 
        /// </summary>
        public int CategoryId { get; set; }
        #endregion

        #region ///20190813新加
        [Range(typeof(decimal),"0.00","100000000.00",ErrorMessage ="超出数值范围")]
        public decimal HKGPrice { get; set; }
        [Range(typeof(decimal), "0.00", "100000000.00", ErrorMessage = "超出数值范围")]
        public decimal EURPrice { get; set; }
        [Range(typeof(decimal), "0.00", "100000000.00", ErrorMessage = "超出数值范围")]
        public decimal CHNPrice { get; set; }
        [Range(typeof(decimal), "0.00", "100000000.00", ErrorMessage = "超出数值范围")]
        public decimal BDAPrice { get; set; }
        [Range(typeof(decimal), "0.00", "100000000.00", ErrorMessage = "超出数值范围")]
        public decimal HKGCost { get; set; }
        [Range(typeof(decimal), "0.00", "100000000.00", ErrorMessage = "超出数值范围")]
        public decimal EURCost { get; set; }
        [Range(typeof(decimal), "0.00", "100000000.00", ErrorMessage = "超出数值范围")]
        public decimal CHNCost { get; set; }
        [Range(typeof(decimal), "0.00", "100000000.00", ErrorMessage = "超出数值范围")]
        public decimal BDACost { get; set; }
        #endregion
        public string Times { get; set; }
        public string Gender { get; set; }
    }
    public enum UploadeType_Enum
    {
        s=1,
        z=2
    }
    public enum UploadStatus_Enum
    {
        one=1,
        two=2,
        three=3,
        four=4
    }
    public enum TradeType
    {
        bonded=1, //保税备货
        direct=2, //直邮
        general=3 //一般贸易
    }
}
