using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XML311.XmlModel
{
    [XmlRoot(ElementName = "CEB312Message", Namespace = "http://www.chinaport.gov.cn/ceb", IsNullable = true)]
    [Serializable]
    public class CEB312Message
    {
        [XmlAttribute]
        public string version { get; set; }
        [XmlAttribute]
        public string guid { get; set; }
        [XmlElement]
        public OrderReture OrderReturn { get; set; }
    }
    public class OrderReture
    {
        public string guid { get; set; }
        public string ebpCode { get; set; }
        public string ebcCode { get; set; }
        public string orderNo { get; set; }
        public string returnStatus { get; set; }
        public string returnTime { get; set; }
        public string returnInfo { get; set; }
        public string orderSerialNode { get; set; }
    }
    /// <summary>
    /// 报关回执
    /// </summary>
    public class DeclarationReceipt
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 回执结果 SUCCESS/FAIL
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// 回执编码
        /// </summary>
        public string ResultCode { get; set; }

        /// <summary>
        /// 回执信息
        /// </summary>
        public string ResultMessage { get; set; }

        /// <summary>
        /// 人员校验
        /// UNCHECKED 商户未上传订购人身份信息
        /// SAME 商户上传的订购人身份信息与支付人身份信息一致
        /// DIFFERENT 商户上传的订购人身份信息与支付人身份信息不一致
        /// </summary>
        public string ResultPersonnelVerification { get; set; }
    }
}
