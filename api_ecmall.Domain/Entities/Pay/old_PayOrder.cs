using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace api_ecmall.Domain.Entities.Pay
{
    public class PayOrder
    {
        [Key]
        public Guid OrderGuid { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        [Display(Name ="订单编号")]
        [Required(ErrorMessage ="{0}必须字段")]
        public string OrderNo { get; set; }
        /// <summary>
        /// 支付单号
        /// </summary>
        [Display(Name ="支付单号")]
        [Required(ErrorMessage = "{0}必须字段")]
        public string PayTransactionId { get; set; }
    }
    public class PayOrder_Re
    {
        /// <summary>
        /// 
        /// </summary>
        public string success { get; set; } = "true";
        public PayCode code { get; set; }
        public string msg { get; set; }
    }
    public enum PayCode
    {
        success=200,
        fail=201,
        wait=201
    }
}
