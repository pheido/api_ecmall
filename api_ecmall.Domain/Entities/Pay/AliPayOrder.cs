using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Com.Alipay
{
    public class AliPayOrder
    {
        ///<summary>
        ///接口名称接口名称。
        ///</summary>
        public string service { get; set; }
        ///<summary>
        ///合作者身份ID签约的支付宝账号对应的支付宝唯一用户号。
        ///</summary>
        public string partner { get; set; }
        public string alipaySec { get; set; }
        ///<summary>
        ///参数编码字符集商户网站使用的编码格式，如UTF-8、GBK、GB2312等。
        ///</summary>
        public string _input_charset { get; set; }
        ///<summary>
        ///签名方式DSA、RSA、MD5三个值可选，必须大写。
        ///</summary>
        public string sign_type { get; set; }
        ///<summary>
        ///签名请参见本文档“附录：签名与验签”。
        ///</summary>
        public string sign { get; set; }
        ///<summary>
        ///报关流水号商户生成的用于唯一标识一次报关操作的业务编号。
        ///</summary>
        public string out_request_no { get; set; }
        ///<summary>
        ///支付宝交易号该交易在支付宝系统中的交易流水号，最长64位。
        ///</summary>
        public string trade_no { get; set; }
        ///<summary>
        ///商户海关备案编号商户在海关备案的编号。
        ///</summary>
        public string merchant_customs_code { get; set; }
        ///<summary>
        ///报关金额报关金额，单位为人民币“元”，精确到小数点后2位。
        ///</summary>
        public string amount { get; set; }
        ///<summary>
        ///海关编号海关编号，大小写均支持。
        ///</summary>
        public string customs_place { get; set; }
        ///<summary>
        ///商户海关备案名称商户海关备案名称。
        ///</summary>
        public string merchant_customs_name { get; set; }
        ///<summary>
        ///是否拆单商户控制本单是否拆单报关。
        ///</summary>
        public string is_split { get; set; }
        ///<summary>
        ///子订单号商户子订单号。拆单时由商户传入，且拆单时必须传入，否则会报INVALID_PARAMETER错误码。
        ///</summary>
        public string sub_out_biz_no { get; set; }
        ///<summary>
        ///订购人姓名订购人姓名。即订购人留在商户处的姓名信息。
        ///</summary>
        public string buyer_name { get; set; }
        ///<summary>
        ///订购人身份证号订购人身份证号。即订购人留在商户处的身份证信息。
        ///</summary>
        public string buyer_id_no { get; set; }

    }
}