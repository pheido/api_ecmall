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
    /// 支付原始数据表体
    /// </summary>
    [JsonObject(MemberSerialization.OptOut)]
    public class payExchangeInfoList
    {
        [Key]
        [JsonIgnore]
        public Guid listguid { get; set; }
        [JsonIgnore]
        public virtual Guid payguid { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string orderNo { get; set; }
        /// <summary>
        /// 商品信息
        /// </summary>
        public virtual List<goodsInfo> goodsInfo { get; set; }
        /// <summary>
        /// 收款账号
        /// </summary>
        public string recpAccount { get; set; }
        /// <summary>
        /// 收款企业代码
        /// </summary>
        public string recpCode { get; set; }
        /// <summary>
        /// 收款企业名称
        /// </summary>
        public string recpName { get; set; }
    }
    /// <summary>
    /// 属性描述
    /// </summary>
    [JsonObject(MemberSerialization.OptOut)]
    public class goodsInfo
    {
        [Key]
        [JsonIgnore]
        public int goodsid { get; set; }
        [JsonIgnore]
        public Guid listguid { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string gname { get; set; }
        /// <summary>
        /// 商品展示连接地址
        /// </summary>
        public string itemLink { get; set; }
    }
}
