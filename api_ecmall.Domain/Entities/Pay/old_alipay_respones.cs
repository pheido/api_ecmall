using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_ecmall.Domain.Entities.Pay
{
    public class old_alipay_respones
    {

    }
    public class alipay_trade_customs_declare_response
    {
        public string code { get; set; }
        public string msg { get; set; }
        public string sub_code { get; set; }
        public string sub_msg { get; set; }
        public string trade_no { get; set; }
        public string alipay_declare_no { get; set; }
        public string pay_code { get; set; }
        public string pay_transaction_id { get; set; }
        public string total_amount { get; set; }
        public string currency { get; set; }
        public string ver_dept { get; set; }
        public string identity_check { get; set; }
    }
}
