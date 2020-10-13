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
    public class payExInfo
    {
        [Key]
        [JsonIgnore]
        public Guid payguid { get; set; }
        /// <summary>
        /// 海关发起请求时，平台接受的会话ID
        /// </summary>
        public string sessionID { get; set; }
        /// <summary>
        /// 支付原始数据表头
        /// </summary>
        public virtual payExchangeInfoHead payExchangeInfoHead { get; set; }
        /// <summary>
        /// 支付原始数据表体
        /// </summary>
        public virtual List<payExchangeInfoList> payExchangeInfoLists { get; set; }
        /// <summary>
        /// 返回时的系统时间
        /// </summary>
        public long serviceTime { get; set; }
        /// <summary>
        /// 证书编号
        /// </summary>
        public string certNo { get; set; }
        /// <summary>
        /// 签名结果值
        /// </summary>
        public string signValue { get; set; }
    }
}
