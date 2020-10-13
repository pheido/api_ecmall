using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace api_ecmall.Domain.Entities.Pay
{
    [XmlRoot(IsNullable =false)]
    public class wxpay
    {
        /// <summary>
        /// 
        /// </summary>
        public string sign { get; set; }
        /// <summary>
        /// 微信分配的公众账号ID 
        /// </summary>
        public string appid { get; set; }
        /// <summary>
        /// 微信支付分配的商户号
        /// </summary>
        public string mch_id { get; set; }
        /// <summary>
        /// 商户系统内部订单号，要求32个字符内，只能是数字、大小写字母_-|*@ ，且在同一个商户号下唯一。
        /// </summary>
        public string out_trade_no { get; set; }
        /// <summary>
        /// 微信支付返回的订单号
        /// </summary>
        public string transaction_id { get; set; }
        /// <summary>
        /// GUANGZHOU_ZS 广州（总署版）

        // GUANGZHOU_HP_GJ 广州黄埔国检（需推送订单至黄埔国检的订单需分别推送广州（总署版）和广州黄埔国检，即需要请求两次报关接口）

        //GUANGZHOU_NS_GJ 广州南沙国检（需推送订单至南沙国检的订单需分别推送广州（总署版）和广州南沙国检，即需要请求两次报关接口）

        //HANGZHOU_ZS 杭州（总署版）

        //NINGBO 宁波

        //ZHENGZHOU_BS 郑州（保税物流中心）

        //CHONGQING 重庆

        //SHANGHAI_ZS 上海（总署版）

        //SHENZHEN 深圳

        //ZHENGZHOU_ZH_ZS 郑州综保（总署版）

        //TIANJIN 天津（需要推送订单至天津海关时，需要在商户管理后台同时配置天津海关备案信息与天津国检备案信息；调用报关接口时只需推送天津海关，即请求一次报关接口。)

        /// </summary>
        public string customs { get; set; }
        /// <summary>
        /// 商户在海关登记的备案号
        /// </summary>
        public string mch_customs_no { get; set; }
        /// <summary>
        /// 关税，以分为单位，非必填
        /// </summary>
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? duty { get; set; }
        /// <summary>
        /// 不传，默认是新增ADD新增报关申请  MODIFY修改报关信息
        /// </summary>
        /// 
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string action_type { get; set; }



        //以下字段在拆单或拆单修改时必传 

        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string sub_order_no { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string fee_type { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string order_fee { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string transport_fee { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string product_fee { get; set; }



        //身份信息
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string cert_type { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string cert_id { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string name { get; set; }
    }
}
