using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace api_ecmall.Pay.Entities.AliPayCustomsResult
{
    [XmlRoot(ElementName ="alipay")]
    public class alipay
    {
        public string sign { get; set; }

        public string sign_type { get; set; }

        public string is_success { get; set; }
        public string error { get; set; }
        public List<sparam> request { get; set; }
        public response response { get; set; }
    }
    [XmlType(TypeName = "param")]
    public class sparam
    {
        [XmlAttribute("name")]
        public string name { get; set; }
        [XmlText]
        public string item { get; set; }
    }
    public class response
    {
        public _alipay alipay { get; set; }
    }

    public class _alipay
    {
        public string alipay_declare_no { get; set; }
        public string identity_check { get; set; }
        public string out_request_no { get; set; }
        public string result_code { get; set; }
        public string trade_no { get; set; }
        public string detail_error_code { get; set; }
        public string detail_error_des { get; set; }
    }
}