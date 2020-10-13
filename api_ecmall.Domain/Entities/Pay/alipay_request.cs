using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace api_ecmall.Domain.Entities.Pay
{
    public class alipay_request
    {
        [Required(ErrorMessage ="{0}必须字段")]
        [Display(Name ="报关流水号")]
        [MinLength(6)]
        [MaxLength(32)]
        public string out_request_no { get; set; }
        [Display(Name = "支付宝交易号")]
        [Required(ErrorMessage = "{0}必须字段")]
        [MaxLength(64)]
        public string trade_no { get; set; }
        [Display(Name = "商户海关备案编号")]
        [Required(ErrorMessage = "{0}必须字段")]
        public string merchant_customs_code { get; set; }
        [Display(Name = "报关金额")]
        [Required(ErrorMessage = "{0}必须字段")]
        public string amount { get; set; }
        [Display(Name = "海关编号")]
        [Required(ErrorMessage = "{0}必须字段")]
        public string customs_place { get; set; }



        [Display(Name = "商户海关备案名称")]
        [Required(ErrorMessage = "{0}必须字段")]
        public string merchant_customs_name { get; set; }
        [Display(Name = "是否拆单")]
        public string is_split { get; set; }
        [Display(Name = "子订单号")]
        public string sub_out_biz_no { get; set; }
        [Display(Name = "订购人姓名")]
        public string buyer_name { get; set; }
        [Display(Name = "订购人身份证号")]
        public string buyer_id_no { get; set; }
    }
}
