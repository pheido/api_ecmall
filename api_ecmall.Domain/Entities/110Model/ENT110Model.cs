using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace api_ecmall.Domain.Entities._110Model
{
    /// <summary>
    /// 天津海关 ENT110Message商品备案
    /// </summary>
    [XmlRoot(ElementName = "ENT110Message", Namespace = "http://www.chinaport.gov.cn/ceb", IsNullable = true)]
    [Serializable]
    public class ENT110Model
    {
        public GoodsRegDocument GoodsRegDocument { get; set; }
    }
    public class GoodsRegDocument
    {
        public GoodsRegHead GoodsRegHead { get; set; }
        public List<GoodsRegAnnexListInformation> GoodsRegAnnexList { get; set; }
    }
    public class GoodsRegHead
    {
        /// <summary>
        /// 商品备案流水号
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string GOODS_SERIAL_NO { get; set; }
        /// <summary>
        /// 企业备案号
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string ENT_CODE { get; set; }
        /// <summary>
        /// 申报单位代码
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string DECL_ENT_CODE { get; set; }
        /// <summary>
        /// 商品大类
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string GOODS_CATEGORIES { get; set; }
        /// <summary>
        /// 进出口标志
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string IE_FLAG { get; set; }


        /// <summary>
        /// 申报时间
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string APPLY_TIME { get; set; }
        /// <summary>
        /// HS编码
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string HSCODE { get; set; }
        /// <summary>
        /// 商品货号
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string GOODS_SKU_NO { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string GOODS_NAME { get; set; }
        /// <summary>
        /// 主要成分
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string MASTER_BASE { get; set; }


        /// <summary>
        /// 规格型号
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string SPEC { get; set; }
        /// <summary>
        /// 生产国
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string ORIGIN_COUNTRY { get; set; }
        /// <summary>
        /// 生产企业
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string PRO_ENT { get; set; }
        /// <summary>
        /// 生产品牌
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string BRAND { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string SUPPLIER { get; set; }


        /// <summary>
        /// 包装单位代码
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string QTY_UNIT_CODE { get; set; }
        /// <summary>
        /// 最小包装单位代码
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string SMALL_QTY_UNIT_CODE { get; set; }
        /// <summary>
        /// 用途
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string USE_WAY { get; set; }
        /// <summary>
        /// 是否符合国家相关法规 是:Y 否; N
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string ACCORD_WITH { get; set; }
        /// <summary>
        /// 1 保税出口  2  直邮出口
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string intype { get; set; }
    }
    public class GoodsRegAnnexListInformation
    {
        [Required(ErrorMessage = "{0}必须字段")]
        /// <summary>
        /// 业务类型：固定值2（商品备案）
        /// </summary>
        public string BIZ_TYPE { get; set; }
        /// <summary>
        /// 附件名称
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string ANNEX_NAME { get; set; }
        /// <summary>
        /// 附件内容，base64加码
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string ANNEX_CONTENT { get; set; }
        /// <summary>
        /// 附件类型
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string ANNEX_TYPE { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string RAMARK { get; set; }
    }
}
