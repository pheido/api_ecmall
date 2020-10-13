using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_ecmall.Domain.Entities.Pay
{
    public class old_alipay
    {
        public string app_id { get; set; }
        public string method { get; set; }
        public string format { get; set; }
        public string charset { get; set; }
        public string sign_type { get; set; }
        public string sign { get; set; }
        public string timestamp { get; set; }
        public string version { get; set; }
        public string app_auth_token { get; set; }
        public string biz_conten { get; set; }
    }
    public class biz_conten
    {
        public string out_request_no { get; set; }
        public string trade_no { get; set; }
        public string merchant_customs_code { get; set; }
        public string merchant_customs_name { get; set; }
        public string amount { get; set; }
        public string customs_place { get; set; }
        public string is_split { get; set; }
        public string sub_out_biz_no { get; set; }
        public string declare_mode { get; set; }
        public CustomsDeclareBuyerUnfo buyer_info { get; set; }
    }
    public class CustomsDeclareBuyerUnfo
    {
        public string buyer_name { get; set; }
        public string buyer_cert_no { get; set; }
    }
}
