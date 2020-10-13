using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace api_ecmall.Domain.Entities
{
    [JsonObject(MemberSerialization.OptOut)]
    public class custom_order
    {
        [Key]
        [JsonIgnore]
        public Guid guid { get; set; }
        /// <summary>
        /// 申报订单的订单编号
        /// </summary>
        [Display(Name = "申报订单的订单编号")]
        [Required(ErrorMessage = "必须字段{}")]
        public string orderNo { get; set; }
        /// <summary>
        /// 海关发起请求时，平台接收的会话ID
        /// </summary>
        [Display(Name = "海关发起请求时，平台接收的会话ID")]
        [Required(ErrorMessage = "必须字段{}")]
        public string sessionID { get; set; }
        /// <summary>
        /// 调用时的系统时间
        /// </summary>
        [Display(Name = "调用时的系统时间")]
        //[Required(ErrorMessage = "必须字段{}")]
        public long serviceTime { get; set; }
    }
    [JsonObject(MemberSerialization.OptOut)]
    public class custom_order_re
    {
        [Key]
        [JsonIgnore]
        public Guid guid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "状态代号。10000为正常调用值")]
        [Required(ErrorMessage = "必须字段{}")]
        public string code { get; set; }
        /// <summary>
        /// 异常信息，正常时为空值
        /// </summary>
        [Display(Name = "异常信息，正常时为空值")]
        //[Required(ErrorMessage = "必须字段{}")]
        public string message { get; set; }
        /// <summary>
        /// 系统响应时间
        /// </summary>
        [Display(Name = "系统响应时间")]
        //[Required(ErrorMessage = "必须字段{}")]
        public long serviceTime { get; set; }
    }
    public enum Message_code
    {
        succes=10000,
        faile=20000
    }
}
