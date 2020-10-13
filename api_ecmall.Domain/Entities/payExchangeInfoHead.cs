using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace api_ecmall.Domain.Entities
{
    /// <summary>
    /// 支付原始数据表头
    /// </summary>
    [JsonObject(MemberSerialization.OptOut)]
    public class payExchangeInfoHead
    {
        /// <summary>
        /// 系统唯一序号
        /// </summary>
        [Key]
        //[JsonIgnore]
        public  Guid guid { get; set; }
        [JsonIgnore]
        public  Guid payguid { get; set; }
        /// <summary>
        /// 原始请求
        /// </summary>
        public string initalRequest { get; set; }
        /// <summary>
        /// 原始响应
        /// </summary>
        public string initalResponse { get; set; }
        /// <summary>
        /// 电商平台代码
        /// </summary>
        public string ebpCode { get; set; }
        /// <summary>
        /// 支付企业代码一个
        /// </summary>
        public string payCode { get; set; }

        /// <summary>
        /// 交易流水号
        /// </summary>
        public string payTransactionId { get; set; }
        /// <summary>
        /// 交易金额
        /// </summary>
        public double totalAmount { get; set; }
        /// <summary>
        /// 币制
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// 验核机构
        /// </summary>
        public string verDept { get; set; }
        /// <summary>
        /// 支付类型
        /// </summary>
        public string payType { get; set; }

        /// <summary>
        /// 交易成功时间
        /// </summary>
        [MaxLength(14)]
        public string tradingTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string note { get; set; }
    }
}
