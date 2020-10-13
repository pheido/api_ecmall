using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace api_ecmall.Pay.Entities.AliPayCustomsQuery
{
    [XmlRoot(ElementName ="alipay")]
    public class alipay
    {
        
        public string sign { get; set; }
        
        public string sign_type { get; set; }
        
        public string is_success { get; set; }

        public string error { get; set; }
        [XmlArrayItem("param")]
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
        public string result_code { get; set; }
        public string not_found { get; set; }
        public string detail_error_code { get; set; }
        public string detail_error_des { get; set; }
        public records records { get; set; }
    }

    public class records
    {
        //[XmlArrayItem("customs_declare")]
        [XmlElement]
        public List<customs_declare> customs_declare { get; set; }

    }
    //[XmlType(TypeName = "customs_declare")]
    public class customs_declare
    {
        public string alipay_declare_no { get; set; }
        public string amount { get; set; }
        public string is_split { get; set; }
        public string sub_out_biz_no { get; set; }
        public string customs_place { get; set; }
        public string last_modified_time { get; set; }
        public string memo { get; set; }
        public string merchant_customs_code { get; set; }
        public string merchant_customs_name { get; set; }
        public string out_request_no { get; set; }
        public string status { get; set; }
        public string trade_no { get; set; }
        public string customs_code { get; set; }
        public string customs_info { get; set; }
        public string customs_return_time { get; set; }
    }
}