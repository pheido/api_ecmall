using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace api_ecmall.Domain.Entities
{
    /// <summary>
    /// 订单状态
    /// </summary>
    public class order_status
    {
        /// <summary>
        /// 自增序号
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// 终端id
        /// </summary>
        //[Required(ErrorMessage = "{0}必须字段")]
        [Display(Name = "终端id")]
        public string ClientGuid { get; set; }
        /// <summary>
        /// 终端名称
        /// </summary>
        [Display(Name = "终端名称")]
        //[Required(ErrorMessage = "{0}必须字段")]
        public string ClientName { get; set; }
        /// <summary>
        /// 子订单编号
        /// </summary>
        [Display(Name = "子订单编号")]
        public string OrderBn { get; set; }
        /// <summary>
        /// 主订单编号
        /// </summary>
        [Display(Name = "主订单编号")]
        [Required(ErrorMessage ="{0}必须字段")]
        public string SubOrderBn { get; set; }
        public virtual List<OrderItem_status> OrderItems { get; set; }
        #region 20180813新加
        /// <summary>
        /// 快递公司名称
        /// </summary>
        public string ShipmentCopName { get; set; }
        /// <summary>
        /// 快递公司编号
        /// </summary>
        public string ShipmentCopCode { get; set; }
        /// <summary>
        /// 快递单号
        /// </summary>
        public string TrackingNo { get; set; }
        #endregion

        ///// <summary>
        ///// 海关报关状态 1、已校验 2、报关暂存 3、已申报 4、申报成功 5、申报失败 6、已放行 7、已配送
        ///// </summary>
        //public int CustomsStatus { get; set; }
        ///// <summary>
        ///// 支付报关状态 1、已校验 2、报关暂存 3、已申报 4、申报成功 5、申报失败
        ///// </summary>
        //public int PayStatus { get; set; }
        ///// <summary>
        ///// 交易状态 1、审核通过 2、商家取消
        ///// </summary>
        //public int TradeStatus { get; set; }
    }
    public class OrderItem_status
    {
        public string Sku { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        [EnumDataType(typeof(enum_OrderStatu))]
        public int OrderStatus { get; set; }
        public virtual List<SkuItem_status> SkuItems { get; set; }
        
    }
    public class SkuItem_status
    {
        public string Sku { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        [EnumDataType(typeof(enum_OrderStatu))]
        public int OrderStatus { get; set; }
        #region 20180813新加
        ///// <summary>
        ///// 快递公司名称
        ///// </summary>
        //public string ShipmentCopName { get; set; }
        ///// <summary>
        ///// 快递公司编号
        ///// </summary>
        //public string ShipmentCopCode { get; set; }
        ///// <summary>
        ///// 快递单号
        ///// </summary>
        //public string TrackingNo { get; set; }
        #endregion
    }
    /// <summary>
    /// 订单状态
    /// </summary>
    public enum enum_OrderStatu
    {
        /// <summary>
        /// 暂存
        /// </summary>
        temporary = 10,//暂存
        /// <summary>
        /// 取消
        /// </summary>
        cancel = 20,//取消
        /// <summary>
        /// 已支付
        /// </summary>
        prepaid = 30,//已支付
        /// <summary>
        /// 已拆单
        /// </summary>
        spkited = 40,//已拆单
        /// <summary>
        /// 支付报关中
        /// </summary>
        pay_customsing=50,
        /// <summary>
        /// 支付报关结果——成功
        /// </summary>
        pay_customs_su = 61,
        /// <summary>
        /// 支付报关结果——失败
        /// </summary>
        pay_customs_fa = 62,
        /// <summary>
        /// 身份验证异常
        /// </summary>
        pay_customs_auth_fa = 63,
        /// <summary>
        /// 海关报关
        /// </summary>
        customs=70,
        /// <summary>
        /// 海关报关结果——成功
        /// </summary>
        customs_su=81,
        /// <summary>
        /// 海关报关结果——失败
        /// </summary>
        customs_fa = 82,
        /// <summary>
        /// 物流下单成功
        /// </summary>
        express_order = 90,
        /// <summary>
        /// 物流收单成功
        /// </summary>
        express_recive_su = 91,
        /// <summary>
        /// 物流收货成功
        /// </summary>
        express_su = 92,
        /// <summary>
        /// 物流下单失败
        /// </summary>
        express_fail = 93,
        /// <summary>
        /// 禁运  超限额
        /// </summary>
        express_embargo=94,
        /// <summary>
        /// 退运给销售商
        /// </summary>
        express_recive = 95,
        /// <summary>
        /// 货物以清关放行
        /// </summary>
        express_qingkuan = 96,
        express_kouliu=98,
        chuku=99,
        jinneipeisong=110,
        /// <summary>
        /// 顾客确认收货
        /// </summary>
        customer_confirms = 1000,
        /// <summary>
        /// platform shipped the goods
        /// </summary>
        platform_shipped=102,
        custome_tuiyun = 97,
        pingtaishouhuo = 100,
        //pingtaiyifahuo = 102,
        gongyingshangfahuo = 103,
        kucunbuzu = 200,
        duijian = 201,
        shenfenwufashibie = 202,
        qita = 203
    }
}
