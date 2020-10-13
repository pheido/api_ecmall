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
    public class Order
    {
        //OrderStatusId
        //ShippingStatusId
        //PaymentStatusId
        //PaymentMethodSystemName
        //CustomerCurrencyCode
        [Key]
        [JsonIgnore]
        //public int id { get; set; }
        public Guid OrderGuid { get; set; } = Guid.NewGuid();
        /// <summary>
        /// 订单状态id 等待处理:10，处理中:20，完成：30，取消：40
        /// </summary>
        [Required(ErrorMessage ="{0}必须字段")]
        [EnumDataType(typeof(enum_OrderStatu))]
        public int OrderStatusId { get; set; }
        ///// <summary>
        ///// 配送状态id 默认值：20
        ///// </summary>
        //[Required(ErrorMessage = "{0}必须字段")]
        //public int ShippingStatusId { get; set; }
        ///// <summary>
        ///// 支付状态id 未支付：10，支付处理中：20，已支付：30，部分支付35，退款：40，取消：50
        ///// </summary>
        //[Required(ErrorMessage = "{0}必须字段")]
        //[EnumDataType(typeof(ShippingStatus))]
        //public int PaymentStatusId { get; set; }
        /// <summary>
        /// 支付方法名称：支付宝、微信
        /// </summary>
        //[Required(ErrorMessage = "{0}必须字段")]                                       -------------------
        public string PaymentMethodSystemName { get; set; }
        /// <summary>
        /// 币种 限定为142
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        //[RegularExpression]
        [Check("142")]
        public string CustomerCurrencyCode { get; set; }

        //OrderTotal
        //RefundedAmount
        //AffiliateId
        //AuthorizationTransactionResult
        //ShippingMethod

        /// <summary>
        /// 订单金额合计金额
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public decimal OrderTotal { get; set; }
        /// <summary>
        /// 退款总额，无退款传0
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public decimal RefundedAmount { get; set; }
        /// <summary>
        /// 关联编号，无关联单据传0
        /// </summary>
        //[Required(ErrorMessage = "{0}必须字段")]
        public int AffiliateId { get; set; }
        /// <summary>
        /// 交易结果，交易无异常无需传此参数
        /// </summary>
        //[Required(ErrorMessage = "{0}必须字段")]                                     ----------------
        public string AuthorizationTransactionResult { get; set; }
        /// <summary>
        /// 配送方式 默认传ground
        /// </summary>
        public string ShippingMethod { get; set; }

        //Deleted
        //CreatedOnUtc
        //CustomOrderNumber
        //OrderNo
        //BuyerName

        /// <summary>
        /// 是否删除，默认传0
        /// </summary>
        public bool Deleted { get; set; }
        /// <summary>
        /// 创建日期 YYYY-MM-DD HH:mm:ss
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public DateTime CreatedOnUtc { get; set; }
        /// <summary>
        /// 报关订单编号,未取得申报单号无需传此参数
        /// </summary>
        public string CustomOrderNumber { get; set; }
        /// <summary>
        /// 订单编号 最长60位
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        [MaxLength(60)]
        public string OrderNo { get; set; }
        /// <summary>
        /// 购买人姓名 一般贸易不传
        /// </summary>
        //[Required(ErrorMessage = "{0}必须字段")]
        public string BuyerName { get; set; }


        //BuyerTelephone
        //BuyerRegNo
        //BuyerIdType
        //BuyerIdNumber
        //PayCode

        /// <summary>
        /// 购买人电话 一般贸易不传
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string BuyerTelephone { get; set; }
        /// <summary>
        /// 购买人平台注册账号
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string BuyerRegNo { get; set; }
        /// <summary>
        /// 购买身份证件类型，限定为1 一般贸易不传
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string BuyerIdType { get; set; }
        /// <summary>
        /// 购买人身份证件证号 一般贸易不传
        /// </summary>
        //[Required(ErrorMessage = "{0}必须字段")]
        public string BuyerIdNumber { get; set; }
        /// <summary>
        /// 支付企业海关编码,最长10位 一般贸易不传
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        [MaxLength(30)]
        public string PayCode { get; set; }



        //PayName
        //PayTransactionId
        //Consignee
        //ConsigneeTelephone
        //ConsigneeAddress

        /// <summary>
        /// 支付企业名称
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string PayName { get; set; }
        /// <summary>
        /// 支付单号 最长60位
        /// </summary>
        //[Required(ErrorMessage = "{0}必须字段")]                                     -----------------------
        [MaxLength(60)]
        public string PayTransactionId { get; set; }
        /// <summary>
        /// 收货人姓名
        /// </summary>
        //[Required(ErrorMessage = "{0}必须字段")]                                    ------------------------
        public string Consignee { get; set; }
        /// <summary>
        /// 收货人电话
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string ConsigneeTelephone { get; set; }
        /// <summary>
        /// 收货人地址
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string ConsigneeAddress { get; set; }

        //ConsigneeDitrict
        //IdCard
        //IdType
        //EtradeCountryCode
        //OrderItem

        /// <summary>
        /// 收货地址行政区划代码
        /// </summary>
        public string ConsigneeDitrict { get; set; }
        /// <summary>
        /// 收货人身份证件号码 一般贸易不传
        /// </summary>
        //[Required(ErrorMessage = "{0}必须字段")]
        public string IdCard { get; set; }
        /// <summary>
        /// 收货人证件类型 限定为1 一般贸易不传
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string IdType { get; set; }
        /// <summary>
        /// 商检贸易国别编码 一般贸易不传
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string EtradeCountryCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[Required(ErrorMessage = "{0}必须字段")]
        public virtual List<OrderItem> OrderItems { get; set; }
        /// <summary>
        /// 订单类型 1 初始订单  2 OMS拆单后订单 3 支付报关订单  4 海关报关  5发给WMS
        /// </summary>
        [JsonIgnore]
        public int api_type { get; set; }
        public string SubOrderNo { get; set; }
        /// <summary>
        /// 用户留言
        /// </summary>
        public string UserMessage { get; set; }
        public int StoreId { get; set; } = 0;
    }
    public enum orderstatus
    {
        wait = 10,
        waiting = 20,
        finish = 30,
        cancel = 40
    }
    /// <summary>
    /// 支付状态id 未支付：10，支付处理中：20，已支付：30，部分支付35，退款：40，取消：50
    /// </summary>
    public enum ShippingStatus
    {
        Waitpay = 10,
        Paying = 20,
        FinishPay = 30,
        ParPay = 35,
        Refund=40,
        Cancel=50
    }
}
