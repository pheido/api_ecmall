using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_ecmall.Domain.Entities.Pay
{
    public class wxpay_re
    {
        public string return_code { get; set; }
        public string return_msg { get; set; }

        #region ///以下字段在return_code为SUCCESS的时候有返回 
        public string sign_type { get; set; }
        public string sign { get; set; }
        public string appid { get; set; }

        public string mch_id { get; set; }
        public string result_code { get; set; }
        public string errr_code { get; set; }
        public string err_code_des { get; set; }
        #endregion


        #region ///以下字段在return_code 和result_code都为SUCCESS的时候有返回 
        public string state { get; set; }

        public string transaction_id { get; set; }
        public string out_trade_no { get; set; }
        public string sub_order_no { get; set; }
        public string sub_order_id { get; set; }
        public string modify_time { get; set; }

        public string cert_check_result { get; set; }
        public string verify_department { get; set; }
        public string verify_department_trade_id { get; set; }
        #endregion
    }
}
