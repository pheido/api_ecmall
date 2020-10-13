using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace api_ecmall.Domain.Entities
{
    public class UserInfo
    {
        public string UserName { get; set; }
        [Key]
        public int infoid { get; set; }
        [Display(Name = "是否激活")]
        public bool isActive { get; set; }
        public string userId { get; set; }
        [Display(Name = "支付宝AppId")]
        public string alipayAppId { get; set; }
        [Display(Name = "支付宝安全码")]
        public string alipaySec { get; set; }
        [Display(Name = "微信支付商户号")]
        public string wxshopId { get; set; }
        [Display(Name = "微信支付支付码")]
        public string wxpayCode { get; set; }
        [Display(Name = "微信支付AppId")]
        public string wxappId { get; set; }
        [Display(Name = "系统序列号")]
        public string SysCode { get; set; }
        [Display(Name = "海关电商平台名称")]
        public string ebpName { get; set; }
        [Display(Name = "海关电商平台编码")]
        public string ebpCode { get; set; }
        [Display(Name = "海关电商企业名称")]
        public string ebcName { get; set; }
        [Display(Name = "海关电商企业编码")]
        public string ebcCode { get; set; }
        [Display(Name = "商检电商平台编码")]
        public string ecpCode { get; set; }
        [Display(Name = "商检电商企业编码")]
        public string cebCode { get; set; }
        [Display(Name = "报关平台API地址")]
        public string customsApiUrl { get; set; }
        [Display(Name = "贸易类型")]
        [EnumDataType(typeof(tradeType))]
        public  int customsType { get; set; }
        [Display(Name = "传输企业名称")]
        public string copName { get; set; }
        [Display(Name = "传输企业编码")]
        public string copCode { get; set; }
        [Display(Name = "报文传输编号")]
        public string dxpId { get; set; }
        /// <summary>
        /// 仓库id
        /// </summary>
        [Required(ErrorMessage ="{0}必须字段")]
        public string WarehouseId { get; set; }
        /// <summary>
        /// 关区代码
        /// </summary>
        public string PortCode { get; set; }
        public string AlipayPortCode { get; set; }
        public string WxpayPortCode { get; set; }
    }
    public enum tradeType
    {
    		保税进口=1,
    		直邮进口=2,
            一般贸易=3
    	}
}