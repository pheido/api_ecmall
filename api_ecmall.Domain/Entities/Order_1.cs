using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace api_ecmall.Domain.Entities
{
    /// <summary>
    /// 商城订单表【important】
    /// </summary>
    public class Order_1
    {
        [Key]
        public int ID { get; set; }




        /// <summary>
        /// 订单ID，索引
        /// </summary>
        [Required(ErrorMessage ="{0}必须字段")]
        [Display(Name = "订单ID，索引")]
        //[MaxLength(10)]
        public int Order_id { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        [MaxLength(20)]
        [Display(Name = "订单号")]
        public string Order_sn { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        [MaxLength(10)]
        [Display(Name = "订单类型")]
        public string Type { get; set; }
        /// <summary>
        /// 订单扩展信息
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        [MaxLength(10)]
        [Display(Name = "订单扩展信息")]
        public string extension { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        //[MaxLength(10)]
        [Display(Name = "商家ID")]
        public int Seller_id { get; set; }
        /// <summary>
        /// 商家名
        /// </summary>
        [MaxLength(100)]
        public string Seller_name { get; set; }
        /// <summary>
        /// 购买者ID
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        //[MaxLength(10)]
        [Display(Name = "购买者ID")]
        public int Buyer_id { get; set; }
        /// <summary>
        /// 购买者名
        /// </summary>
        [MaxLength(100)]
        [Display(Name = "购买者名")]
        public string Buyer_name { get; set; }
        /// <summary>
        /// 购买者EMAIL
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        [MaxLength(60)]
        [Display(Name = "购买者EMAIL")]
        public string Buyer_email { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        //[MaxLength(3)]
        public int Status { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        //[MaxLength(10)]
        public int Add_time { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        //[MaxLength(10)]
        public int Payment_id { get; set; }
        /// <summary>
        /// 支付名
        /// </summary>
        [MaxLength(100)]
        public string Payment_name { get; set; }
        /// <summary>
        /// 支付编码
        /// </summary>
        [Required(ErrorMessage = "必须字段")]
        [MaxLength(20)]
        public string Payment_code { get; set; }
        /// <summary>
        /// 外部支付号
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        [MaxLength(20)]
        public string Out_trade_sn { get; set; }
        /// <summary>
        /// 支付时间
        /// </summary>
        //[MaxLength(10)]
        public int Pay_time { get; set; }
        /// <summary>
        /// 支付信息
        /// </summary>
        [Required(ErrorMessage = "必须字段")]
        [MaxLength(255)]
        public string Pay_message { get; set; }
        /// <summary>
        /// 发货时间
        /// </summary>
        //[MaxLength(10)]
        public int Ship_time { get; set; }
        /// <summary>
        /// 发票号
        /// </summary>
        [MaxLength(255)]
        public string Invoice_no { get; set; }
        /// <summary>
        /// 快递公司
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        [MaxLength(50)]
        public string Express_company { get; set; }
        /// <summary>
        /// 完成时间
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        //[MaxLength(10)]
        public int Finished_time { get; set; }
        /// <summary>
        /// 自动完成时间
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        //[MaxLength(10)]
        public int Auto_finished_time { get; set; }
        /// <summary>
        /// 合计总金额
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        //[MaxLength(10)]
        public decimal Goods_amount { get; set; }
        /// <summary>
        /// 折扣价
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        //[MaxLength(10)]
        public decimal discount { get; set; }
        /// <summary>
        /// 订单折扣价
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        //[MaxLength(10)]
        public decimal order_amount { get; set; }
        /// <summary>
        /// 评定状态
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        //[MaxLength(1)]
        public int evaluation_status { get; set; }
        /// <summary>
        /// 评定时间
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        //[MaxLength(10)]
        public int evaluation_time { get; set; }
        /// <summary>
        /// 卖家评论状态
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        //[MaxLength(1)]
        public int seller_evaluation_status { get; set; }
        /// <summary>
        /// 卖家评价时间
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        //[MaxLength(10)]
        public int seller_evaluation_time { get; set; }
        /// <summary>
        /// 是否匿名
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        //[MaxLength(3)]
        public int anonymous { get; set; }
        /// <summary>
        /// 评定信息
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        [MaxLength(255)]
        public string postscript { get; set; }
        /// <summary>
        /// 支付变更
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        //[MaxLength(1)]
        public int pay_alter { get; set; }
    }
}
