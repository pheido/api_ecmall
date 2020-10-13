using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace XML311.JsonModel
{
    //public class ENT311Message
    //{
    //    // [XmlAttribute]
    //    //public string xmlns1 { get; set; }
      
    //    public string guid { get; set; }
       
    //    public string version { get; set; }
        
    //    public string sendCode { get; set; }
      
    //    public string reciptCode { get; set; }
       
    //    public SonClass.Order Order { get; set; }
    //    public SonClass.BaseTransfer BaseTransfer { get; set; }
    //}
    //public class BaseTransfer
    //{
    //    ///<summary>
    //    ///报文传输的企业代码（需要与接入客户端的企业身份一致），最大18位英文字母+数字
    //    /// </summary>
    //    public string copCode { get; set; }

    //    ///<summary>
    //    ///报文传输的企业名称，最大50个汉字
    //    /// </summary>
    //    public string copName { get; set; }

    //    ///<summary>
    //    ///报文传输模式，默认为DXP；指中国电子口岸数据交换平台，最大3位英文字母
    //    /// </summary>
    //    public string dxpMode { get; set; }

    //    ///<summary>
    //    ///报文传输编号，向中国电子口岸数据中心申请数据交换平台的用户编号，最大30位英文字母+数字
    //    /// </summary>
    //    public string dxpId { get; set; }

    //    ///<summary>
    //    ///非必填，备注，最大500个汉字
    //    /// </summary>
    //    public string note { get; set; }


    //}
    //public class Order
    //{
    //    public OrderHead OrderHead { get; set; }
    //    [XmlElement]
    //    public List<OrderList> OrderList { get; set; }
    //}
    //public class OrderHead
    //{
    //    ///<summary>
    //    ///系统唯一序号，企业系统生成36位唯一序号（英文字母大写）。36位英文字母+数字
    //    /// </summary>
    //    public string guid { get; set; }

    //    ///<summary>
    //    ///企业报送类型。1-新增 2-变更 3-删除。默认为1。1位数字
    //    /// </summary>
    //    public string appType { get; set; }

    //    ///<summary>
    //    ///企业报送时间。格式:YYYYMMDDhhmmss。14位数字
    //    /// </summary>
    //    public string appTime { get; set; }

    //    ///<summary>
    //    ///业务状态:1-暂存,2-申报,默认为2。最大3位数字
    //    /// </summary>
    //    public string appStatus { get; set; }

    //    ///<summary>
    //    ///电子订单类型：I进口，1位英文字母
    //    /// </summary>
    //    public string orderType { get; set; }

    //    ///<summary>
    //    ///交易平台的订单编号，同一交易平台的订单编号应唯一。订单编号长度不能超过30位。最大30位英文字母+数字
    //    /// </summary>
    //    public string orderNo { get; set; }

    //    ///<summary>
    //    ///电商平台的海关注册登记编号；电商平台未在海关注册登记，由电商企业发送订单的，以中国电子口岸发布的电商平台标识编号为准。最大18位英文字母+数字
    //    /// </summary>
    //    public string ebpCode { get; set; }

    //    ///<summary>
    //    ///电商平台的海关注册登记名称；电商平台未在海关注册登记，由电商企业发送订单的，以中国电子口岸发布的电商平台名称为准。最大50个汉字
    //    /// </summary>
    //    public string ebpName { get; set; }

    //    ///<summary>
    //    ///电商企业的海关注册登记编号。最大18位英文字母+数字
    //    /// </summary>
    //    public string ebcCode { get; set; }

    //    ///<summary>
    //    ///电商企业的海关注册登记名称。最大50个汉字
    //    /// </summary>
    //    public string ebcName { get; set; }

    //    ///<summary>
    //    ///商品实际成交价，含非现金抵扣金额。小数点后保留两位数字
    //    /// </summary>
    //    public string goodsValue { get; set; }

    //    ///<summary>
    //    ///不包含在商品价格中的运杂费，无则填写"0"。小数点后保留两位数字
    //    /// </summary>
    //    public string freight { get; set; }

    //    ///<summary>
    //    ///使用积分、虚拟货币、代金券等非现金支付金额，无则填写"0"。小数点后保留两位数字
    //    /// </summary>
    //    public string discount { get; set; }

    //    ///<summary>
    //    ///企业预先代扣的税款金额，无则填写“0”，小数点后保留两位数字
    //    /// </summary>
    //    public string taxTotal { get; set; }

    //    ///<summary>
    //    ///商品价格+运杂费+代扣税款-非现金抵扣金额，与支付凭证的支付金额一致。小数点后保留两位数字
    //    /// </summary>
    //    public string acturalPaid { get; set; }

    //    ///<summary>
    //    ///限定为人民币，填写“142”。3位数字
    //    /// </summary>
    //    public string currency { get; set; }

    //    ///<summary>
    //    ///检验检疫币制。3位数字
    //    /// </summary>
    //    public string ciqcurrency { get; set; }

    //    ///<summary>
    //    ///订购人的交易平台注册号。最大60位英文字母+数字
    //    /// </summary>
    //    public string buyerRegNo { get; set; }

    //    ///<summary>
    //    ///订购人的真实姓名。最大30个汉字
    //    /// </summary>
    //    public string buyerName { get; set; }
    //    /// <summary>
    //    /// 海关监督对象电话，要求实际联系电话                                 --注释：2018年新增
    //    /// </summary>
    //    public string buyerTelephone { get; set; }
    //    ///<summary>
    //    ///1-身份证,2-其它。限定为身份证，填写“1”。1位数字
    //    /// </summary>
    //    public string buyerIdType { get; set; }

    //    ///<summary>
    //    ///订购人的身份证件号码。最大60位英文字母+数字
    //    /// </summary>
    //    public string buyerIdNumber { get; set; }

    //    ///<summary>
    //    ///非必填，支付企业的海关注册登记编号。最大18位英文字母+数字
    //    /// </summary>
    //    public string payCode { get; set; }

    //    ///<summary>
    //    ///非必填，支付企业在海关注册登记的企业名称。最大50位汉字
    //    /// </summary>
    //    public string payName { get; set; }

    //    ///<summary>
    //    ///非必填，支付企业唯一的支付流水号。最大60位英文字母+数字
    //    /// </summary>
    //    public string payTrCsactionId { get; set; }

    //    ///<summary>
    //    ///非必填，商品批次号。最大30位英文字母+数字
    //    /// </summary>
    //    public string batchNumbers { get; set; }

    //    ///<summary>
    //    ///收货人姓名，必须与电子运单的收货人姓名一致。最大30个汉字
    //    /// </summary>
    //    public string consignee { get; set; }

    //    ///<summary>
    //    ///收货人联系电话，必须与电子运单的收货人电话一致。最大20位数字
    //    /// </summary>
    //    public string consigneeTelephone { get; set; }

    //    ///<summary>
    //    ///收货地址，必须与电子运单的收货地址一致。最大100个汉字
    //    /// </summary>
    //    public string consigneeAddress { get; set; }

    //    ///<summary>
    //    ///非必填，参照国家统计局公布的国家行政区划标准填制。最大6位数字
    //    /// </summary>
    //    public string consigneeDitrict { get; set; }

    //    ///<summary>
    //    ///最大500个汉字
    //    /// </summary>
    //    public string note { get; set; }

    //    ///<summary>
    //    ///检验检疫电商平台备案编号
    //    /// </summary>
    //    public string ecpCode { get; set; }

    //    ///<summary>
    //    ///检验检疫电商企业备案编号
    //    /// </summary>
    //    public string cbeCode { get; set; }

    //    ///<summary>
    //    ///业务类型 1保税备货 2保税集货  3邮件 4快件，最大2位数字
    //    /// </summary>
    //    public string bizType { get; set; }

    //    ///<summary>
    //    ///检验检疫代理申报企业备案编号
    //    /// </summary>
    //    public string agentCode { get; set; }

    //    ///<summary>
    //    ///收货人所在国编号，最大4位数字
    //    /// </summary>
    //    public string consigneeCountryCode { get; set; }

    //    ///<summary>
    //    ///发货人，最大30位汉字，或60位数字
    //    /// </summary>
    //    public string consignorCname { get; set; }

    //    ///<summary>
    //    ///发货人地址，最大127个汉字
    //    /// </summary>
    //    public string consignorAddress { get; set; }

    //    ///<summary>
    //    ///发货人电话，最大30位数字
    //    /// </summary>
    //    public string consignorTel { get; set; }

    //    ///<summary>
    //    ///发货人所在国编号(检验检疫)，最大4位数字
    //    /// </summary>
    //    public string consignorCountryCode { get; set; }

    //    ///<summary>
    //    ///收货人证件类型编号 1身份证 2军官证 3护照 4其他，最大4位数字
    //    /// </summary>
    //    public string idType { get; set; }

    //    ///<summary>
    //    ///收货人证件号码，最大30位英文字母+数字
    //    /// </summary>
    //    public string idCard { get; set; }

    //    ///<summary>
    //    ///贸易国别编号(检验检疫)，最大4位数字
    //    /// </summary>
    //    public string etradeCountryCode { get; set; }

    //    ///<summary>
    //    ///订单流水号(检验检疫电商平台编号+订单编号)，最大50位英文字母+数字
    //    /// </summary>
    //    public string orderSerialNo { get; set; }

    //    ///<summary>
    //    ///1：报税进口； 2：直邮进口，最大2位数字
    //    /// </summary>
    //    public string intype { get; set; }


    //}
    //public class OrderList
    //{
    //    ///<summary>
    //    ///从1开始的递增序号。最大4位小数
    //    /// </summary>
    //    public string gnum { get; set; }

    //    ///<summary>
    //    ///电商企业自定义的商品货号（SKU）。最大30位英文字母+数字
    //    /// </summary>
    //    public string itemNo { get; set; }

    //    ///<summary>
    //    ///交易平台销售商品的中文名称。最大125位汉字
    //    /// </summary>
    //    public string itemName { get; set; }
    //    /// <summary>
    //    /// 满足海关归类、审价以及监管 的要求为准。包括：品名、牌 名、规格、型号、成份、含量、 等级等  --注释：2018年新增
    //    /// </summary>
    //    public string gmodel { get; set; }
    //    ///<summary>
    //    ///非必填，交易平台销售商品的描述信息。最大500位汉字
    //    /// </summary>
    //    public string itemDescribe { get; set; }

    //    ///<summary>
    //    ///非必填，国际通用的商品条形码，一般由前缀部分、制造厂商代码、商品代码和校验码组成。最大20位英文字母+数字
    //    /// </summary>
    //    public string barCode { get; set; }

    //    ///<summary>
    //    ///填写海关标准的参数代码，参照《JGS-20 海关业务代码集》- 计量单位代码。最大3位数字
    //    /// </summary>
    //    public string unit { get; set; }

    //    ///<summary>
    //    ///商品实际数量。小数点后保留两位数字
    //    /// </summary>
    //    public string qty { get; set; }

    //    ///<summary>
    //    ///小数点后保留两位数字
    //    /// </summary>
    //    public string price { get; set; }

    //    ///<summary>
    //    ///商品总价，等于单价乘以数量。小数点后保留两位小数
    //    /// </summary>
    //    public string totalPrice { get; set; }

    //    ///<summary>
    //    ///限定为人民币，填写“142”。
    //    /// </summary>
    //    public string currency { get; set; }

    //    ///<summary>
    //    ///检验检疫币制。
    //    /// </summary>
    //    public string ciqcurrency { get; set; }

    //    ///<summary>
    //    ///原产地，填写海关标准的参数代码，参照《JGS-20 海关业务代码集》-国家（地区）代码表。最大3位数字
    //    /// </summary>
    //    public string country { get; set; }

    //    ///<summary>
    //    ///原产地，国检。最大4位数字
    //    /// </summary>
    //    public string ciqcountry { get; set; }

    //    ///<summary>
    //    ///非必填，促销活动，商品单价偏离市场价格的，可以在此说明。最大500位汉字
    //    /// </summary>
    //    public string note { get; set; }

    //    ///<summary>
    //    ///品牌，最大100位汉字
    //    /// </summary>
    //    public string shelfGoodsName { get; set; }

    //    ///<summary>
    //    ///包装种类编号，最大5位数字，请参照检验检疫商品备案相关信息。
    //    /// </summary>
    //    public string wraptypeCode { get; set; }

    //    ///<summary>
    //    ///用途编号，最大5位数字，请参照检验检疫商品备案相关信息。
    //    /// </summary>
    //    public string purposeCode { get; set; }

    //    ///<summary>
    //    ///规格型号，最大200个汉字，请参照检验检疫商品备案相关信息。
    //    /// </summary>
    //    public string goodsModel { get; set; }

    //    ///<summary>
    //    ///商品备案编号（检验检疫），直邮业务必填。
    //    /// </summary>
    //    public string goodsRegNo { get; set; }



    //}
}