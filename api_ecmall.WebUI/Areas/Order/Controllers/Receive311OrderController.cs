using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using api_ecmall.Domain.Abstract;
using api_ecmall.Domain.Entities.Orders;
using api_ecmall.Domain.Entities;
using XML311.XmlModel;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Text;

namespace api_ecmall.WebUI.Areas.Orders.Controllers
{
    ///// <summary>
    ///// 311订单接受接口
    ///// </summary>
    //[Route("api/order/Receive311Order")]
    //public class Receive311OrderController : ApiController
    //{
    //    private IRabbitMQHelper _IRabbitMQHelper;
    //    private IEcmOrderRepository _iEcmOrder;
    //    private ILog4netHelper _logger;
    //    private IUserRepository _IUserRepository;
    //    /// <summary>
    //    /// 构造函数
    //    /// </summary>
    //    /// <param name="IRabbitMQHelper"></param>
    //    /// <param name="iEcmOrder"></param>
    //    /// <param name="logger"></param>
    //    /// <param name="IUserRepository"></param>
    //    public Receive311OrderController(IRabbitMQHelper IRabbitMQHelper, IEcmOrderRepository iEcmOrder, ILog4netHelper logger, IUserRepository IUserRepository)
    //    {
    //        _IRabbitMQHelper = IRabbitMQHelper;
    //        _iEcmOrder = iEcmOrder;
    //        _logger = logger;
    //        _IUserRepository = IUserRepository;
    //    }
    //    /// <summary>
    //    /// 311订单接受接口
    //    /// </summary>
    //    /// <param name="value"></param>
    //    public string Post([FromBody]Order value)
    //    {
    //        string reStr = "";
    //        if (ModelState.IsValid)
    //        {
    //            string username = User.Identity.Name;
    //            UserInfo userinfo = new UserInfo();//   _IUserRepository.UserInfos.Where(t => t.UserName == username).FirstOrDefault();
    //            userinfo = _IUserRepository.UserInfos.Where(t=>t.userId==value.OrderItems[0].CustomsChannelId.ToString()).FirstOrDefault();


    //            value.OrderGuid = Guid.NewGuid();
    //            value.api_type = 1;

    //            ENT311Message message_311 = new ENT311Message();



    //            Order_311 order_311 = new Order_311();
    //            OrderHead orderhead_311 = new OrderHead();
    //            List<OrderList> orderlist_311 = new List<OrderList>();


    //            #region ///311报关头部
    //            orderhead_311.guid = value.OrderGuid.ToString();
    //            orderhead_311.appType = "1";
    //            orderhead_311.appTime = DateTime.Now.ToString("yyyyMMDDHHmmss");
    //            orderhead_311.appStatus = "2";
    //            orderhead_311.orderType = "I";

    //            orderhead_311.orderNo = value.SubOrderNo;
    //            orderhead_311.freight = "0";
    //            orderhead_311.discount = "0";
    //            orderhead_311.acturalPaid = value.OrderTotal.ToString();
    //            orderhead_311.currency = "142";

    //            orderhead_311.buyerRegNo = value.BuyerRegNo;
    //            orderhead_311.buyerName = value.BuyerName;
    //            orderhead_311.buyerTelephone = value.BuyerTelephone;
    //            orderhead_311.buyerIdType = value.BuyerIdType;
    //            orderhead_311.buyerIdNumber = value.BuyerIdNumber;

    //            orderhead_311.payCode = value.PayCode;
    //            orderhead_311.payName = value.PayName;
    //            orderhead_311.payTrCsactionId = value.PayTransactionId;
    //            orderhead_311.batchNumbers = "";
    //            orderhead_311.consignee = value.Consignee;

    //            orderhead_311.consigneeTelephone = value.ConsigneeTelephone;
    //            orderhead_311.consignorAddress = value.ConsigneeAddress;
    //            orderhead_311.consigneeDitrict = value.ConsigneeDitrict;
    //            orderhead_311.note = "";
    //            orderhead_311.agentCode = "";

    //            orderhead_311.consigneeCountryCode = value.EtradeCountryCode;
    //            orderhead_311.idCard = "";
    //            orderhead_311.idType = "";
    //            orderhead_311.etradeCountryCode = value.EtradeCountryCode;
    //            orderhead_311.orderSerialNo = userinfo.ecpCode + value.SubOrderNo;


    //            orderhead_311.ebcCode = userinfo.ebcCode;
    //            orderhead_311.ebcName = userinfo.ebcName;
    //            orderhead_311.ebpCode = userinfo.ebpCode;
    //            orderhead_311.ebpName = userinfo.ebpName;
    //            orderhead_311.ecpCode = userinfo.ecpCode;

    //            orderhead_311.cbeCode = userinfo.cebCode;

    //            BaseTransfer basetransfer = new BaseTransfer();
    //            basetransfer.copCode = userinfo.copCode;
    //            basetransfer.copName = userinfo.copName;
    //            basetransfer.dxpMode = "DXP";
    //            basetransfer.dxpId = userinfo.dxpId;
    //            basetransfer.note = " ";
    //            #endregion

    //            int count = 0;
    //            for (int i = 0; i < value.OrderItems.Count; i++)
    //            {
    //                OrderItem item = value.OrderItems[i];
    //                orderhead_311.ciqcurrency = item.CiqCurrency;
    //                orderhead_311.bizType = item.TradeType.ToString();
    //                orderhead_311.intype = item.TradeType.ToString();

    //                if (item.OrderItemDetails != null)
    //                {
    //                    count++;
    //                    OrderList orderlist = new OrderList();

    //                    orderlist.gnum = count.ToString();
    //                    orderlist.itemNo = item.ProductSku;
    //                    orderlist.itemName = item.ItemName;
    //                    orderlist.gmodel = item.ItemDescribe;
    //                    orderlist.itemDescribe = item.ItemDescribe;

    //                    orderlist.barCode = item.BarCode;
    //                    orderlist.unit = item.Unit;
    //                    orderlist.qty = item.Quantity.ToString();
    //                    orderlist.price = item.PriceInclTax.ToString();
    //                    orderlist.totalPrice = item.TotalPrice.ToString();

    //                    orderlist.currency = "142";
    //                    orderlist.ciqcountry = item.CiqCountry;
    //                    orderlist.country = item.Country;
    //                    orderlist.ciqcurrency = item.CiqCurrency;
    //                    orderlist.note = " ";

    //                    orderlist.shelfGoodsName = item.ShelfGoodsName;
    //                    orderlist.wraptypeCode = item.WrapTypeCode;
    //                    orderlist.purposeCode = item.PurposeCode;
    //                    orderlist.goodsModel = "";
    //                    orderlist.goodsRegNo = "";
    //                    orderlist_311.Add(orderlist);
    //                }
    //                else
    //                {
    //                    for (int j = 0; j < item.OrderItemDetails.Count; j++)
    //                    {
    //                        count++;
    //                        OrderList orderlist = new OrderList();

    //                        orderlist.gnum = count.ToString();
    //                        orderlist.itemNo = item.OrderItemDetails[j].AttributeSku;
    //                        orderlist.itemName = item.ItemName;
    //                        orderlist.gmodel = item.ItemDescribe;
    //                        orderlist.itemDescribe = item.ItemDescribe;

    //                        orderlist.barCode = item.OrderItemDetails[j].BarCode;
    //                        orderlist.unit = item.Unit;
    //                        orderlist.qty = item.OrderItemDetails[j].Quantity.ToString();
    //                        orderlist.price = item.OrderItemDetails[j].Price.ToString();
    //                        orderlist.totalPrice = item.TotalPrice.ToString();

    //                        orderlist.currency = "142";
    //                        orderlist.ciqcountry = item.CiqCountry;
    //                        orderlist.country = item.Country;
    //                        orderlist.ciqcurrency = item.CiqCurrency;
    //                        orderlist.note = " ";

    //                        orderlist.shelfGoodsName = item.ShelfGoodsName;
    //                        orderlist.wraptypeCode = item.WrapTypeCode;
    //                        orderlist.purposeCode = item.PurposeCode;
    //                        orderlist.goodsModel = "";
    //                        orderlist.goodsRegNo = "";
    //                        orderlist_311.Add(orderlist);
    //                    }
    //                }
    //            }

    //            order_311.OrderHead = orderhead_311;
    //            order_311.OrderList = orderlist_311;

    //            message_311.Order = order_311;
    //            message_311.BaseTransfer = basetransfer;
    //            message_311.guid = "FBF24A92-B66D-4EE3-8A5B-1007C2A39777";
    //            message_311.version = "v1.0";
    //            message_311.sendCode = "Q120000201706151205";
    //            message_311.reciptCode = "121500";

    //            XmlSerializer xsOrder = new XmlSerializer(typeof(ENT311Message));
    //            using (var stream = new MemoryStream())
    //            {
    //                try
    //                {
    //                    XmlWriterSettings setting = new XmlWriterSettings();
    //                    setting.Encoding = Encoding.GetEncoding("UTF-8");

    //                    setting.Indent = true;
    //                    setting.IndentChars = "    ";
    //                    setting.NewLineChars = "\r\n";
    //                    setting.OmitXmlDeclaration = false;

    //                    XmlWriter wrint = XmlWriter.Create(stream, setting);
    //                    var n = new XmlSerializerNamespaces();
    //                    n.Add("", "http://www.chinaport.gov.cn/ENT");
    //                    xsOrder.Serialize(wrint, message_311, n);
    //                    wrint.Close();
    //                }
    //                catch (Exception ex)
    //                {

    //                }
    //                stream.Position = 0;
    //                StreamReader sr = new StreamReader(stream);
    //                reStr = sr.ReadToEnd();
    //                sr.Dispose();
    //                stream.Dispose();
    //            }
    //        }
    //        else
    //        {
    //            return BadRequest(ModelState).ToString();
    //        }
    //        return reStr;
    //    }
    //}
}
