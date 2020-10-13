using api_ecmall.Domain.Abstract;
using api_ecmall.Domain.Entities;
using api_ecmall.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Xml;
using System.Xml.Serialization;
using XML311.XmlModel;
using Newtonsoft.Json;

namespace api_ecmall.WebUI.Areas.Customs.Controllers
{
    /// <summary>
    /// 311报关接口集合
    /// </summary>
    public class custom311Controller : ApiController
    {
        private IRabbitMQHelper _IRabbitMQHelper;
        private IEcmOrderRepository _iEcmOrder;
        private ILog4netHelper _logger;
        private IUserRepository _IUserRepository;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="IRabbitMQHelper"></param>
        /// <param name="iEcmOrder"></param>
        /// <param name="logger"></param>
        /// <param name="IUserRepository"></param>
        public custom311Controller(IRabbitMQHelper IRabbitMQHelper, IEcmOrderRepository iEcmOrder, ILog4netHelper logger, IUserRepository IUserRepository)
        {
            _IRabbitMQHelper = IRabbitMQHelper;
            _iEcmOrder = iEcmOrder;
            _logger = logger;
            _IUserRepository = IUserRepository;
        }
        /// <summary>
        /// 311报关
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [Route("api/order/Receive311Order")]
        public IHttpActionResult Receive311Order([FromBody]Order order)
        {
            API_Message message = new API_Message();
            message.MessageCode = "1";
            string reStr = "";
            _logger.WriteLog_Info<custom311Controller>(JsonConvert.SerializeObject(order), null, null, null);
            if (ModelState.IsValid)
            {
                string username = User.Identity.Name;
                UserInfo userinfo = new UserInfo();//   _IUserRepository.UserInfos.Where(t => t.UserName == username).FirstOrDefault();
                try
                {
                    userinfo = _IUserRepository.UserInfos.Where(t => t.userId == (order.OrderItems?[0].OrderItemDetails?[0].CustomsChannelId.ToString()?? order.OrderItems[0].CustomsChannelId.ToString())).FirstOrDefault();

                    if(userinfo==null)
                    {
                        message.MessageCode = "2";
                        message.ErrorMsg = "没有查询到相应的报关通道！";
                        return Json(message);
                    }
                    order.OrderGuid = Guid.NewGuid();
                    order.api_type = 1;

               
                    //reStr = Custom_GuangZhou(order, userinfo);
                    if (userinfo.PortCode.ToLower().Contains("tianjin"))
                    {
                        reStr = Custom_TianJin(order, userinfo);
                    }
                    else if (userinfo.PortCode.ToLower().Contains("guangzhou"))
                    {
                        reStr = Custom_GuangZhou(order, userinfo);
                    }
                    _logger.WriteLog_Info<custom311Controller>(reStr, null, null, null);
                }
                catch(Exception ex)
                {
                    message.MessageCode = "2";
                    _logger.WriteLog_Error<custom311Controller>(reStr, null, null, ex);
                }
            }
            else
            {
                //return BadRequest(ModelState).ToString();
                var modelstate = BadRequest(ModelState);
                string returestr = "";
                foreach (var item in modelstate.ModelState.Keys)
                {
                    returestr += "Key:" + item + "value:" + (modelstate.ModelState[item].Errors != null ? (modelstate.ModelState?[item].Errors?[0].ErrorMessage + "   " + modelstate.ModelState?[item].Errors?[0].Exception?.Message) : "");// item.Errors != null ? item.Errors[0].ErrorMessage + "\r\n" : "";
                }
                message.MessageCode = "2";
                message.ErrorMsg = returestr;
            }
            return Json(message);
        }




        private string Custom_TianJin(Order order,UserInfo userinfo)
        {
            string reStr = "";
            ENT311Message message_311 = new ENT311Message();



            Order_311 order_311 = new Order_311();
            OrderHead orderhead_311 = new OrderHead();
            List<OrderList> orderlist_311 = new List<OrderList>();


            #region ///311报关头部
            orderhead_311.guid = order.OrderGuid.ToString();
            orderhead_311.appType = "1";
            orderhead_311.appTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            orderhead_311.appStatus = "2";
            orderhead_311.orderType = "I";

            orderhead_311.orderNo = order.OrderNo;
            //orderhead_311.goodsValue = order?.OrderTotal.ToString("f2");
            //orderhead_311.freight = "0";
            //orderhead_311.discount = "0";
            //orderhead_311.taxTotal = order?.OrderTotal.ToString("f2");
            //orderhead_311.acturalPaid = order?.OrderTotal.ToString("f2");


            decimal goodsValue = 0;//商品实际成交价格
            decimal freight = 0;//运杂费
            decimal discount = 0;//抵扣金额
            decimal taxTotal = 0;//税款
            decimal acturalPaid = 0;//实际支付


            

            orderhead_311.currency = "142";

            orderhead_311.buyerRegNo = order.BuyerRegNo;
            orderhead_311.buyerName = order.BuyerName;
            orderhead_311.buyerTelephone = order.BuyerTelephone;
            orderhead_311.buyerIdType = order.BuyerIdType;
            orderhead_311.buyerIdNumber = order.BuyerIdNumber;

            orderhead_311.payCode = order.PayCode;
            orderhead_311.payName = order.PayName;
            orderhead_311.payTransactionId = order.PayTransactionId;
            orderhead_311.batchNumbers = userinfo.cebCode;
            orderhead_311.consignee = order.Consignee;

            //orderhead_311.consigneeTelephone = order.ConsigneeTelephone;
            //orderhead_311.consignorAddress = order.ConsigneeAddress;
            //orderhead_311.consigneeDitrict = order.ConsigneeDitrict;


            orderhead_311.consigneeTelephone = order.ConsigneeTelephone;
            orderhead_311.consigneeAddress = order.ConsigneeAddress;
            orderhead_311.consigneeDitrict = order.ConsigneeDitrict;

            orderhead_311.note = " ";
            orderhead_311.agentCode = userinfo.cebCode;

            orderhead_311.consigneeCountryCode = order.EtradeCountryCode;

            orderhead_311.consignorCname = "智信通";
            orderhead_311.consignorAddress = "智信通";
            orderhead_311.consignorTel = "110";
            orderhead_311.consignorCountryCode = "156";

            orderhead_311.idCard = order.IdCard;
            orderhead_311.idType = order.IdType;
            orderhead_311.etradeCountryCode = order.EtradeCountryCode;
            orderhead_311.orderSerialNo = userinfo.ecpCode + order.SubOrderNo;


            orderhead_311.ebcCode = userinfo.ebcCode;
            orderhead_311.ebcName = userinfo.ebcName;
            orderhead_311.ebpCode = userinfo.ebpCode;
            orderhead_311.ebpName = userinfo.ebpName;
            orderhead_311.ecpCode = userinfo.ecpCode;

            orderhead_311.cbeCode = userinfo.cebCode;

            BaseTransfer basetransfer = new BaseTransfer();
            basetransfer.copCode = userinfo.copCode;
            basetransfer.copName = userinfo.copName;
            basetransfer.dxpMode = "DXP";
            basetransfer.dxpId = userinfo.dxpId;
            basetransfer.note = " ";
            #endregion

            int count = 0;
            for (int i = 0; i < order.OrderItems.Count; i++)
            {
                OrderItem item = order.OrderItems[i];
                orderhead_311.ciqcurrency = item.CiqCurrency;
                orderhead_311.bizType = item.OrderItemDetails==null? item.TradeType.ToString():item.OrderItemDetails[0].TradeType.ToString();
                orderhead_311.intype = item.OrderItemDetails == null ? item.TradeType.ToString() : item.OrderItemDetails[0].TradeType.ToString();

                if (item.OrderItemDetails == null)
                {
                    count++;
                    OrderList orderlist = new OrderList();

                    orderlist.gnum = count.ToString();
                    orderlist.itemNo = item.ProductSku?.Split('|')[0];
                    orderlist.itemName = item.ItemName;
                    orderlist.gmodel = item.ItemDescribe ?? " ";
                    orderlist.itemDescribe = item.ItemDescribe ?? " ";

                    orderlist.barCode = item.BarCode == "none" ? "0" : item.BarCode;
                    orderlist.unit = item.Unit;
                    orderlist.qty = item.Quantity.ToString();
                    orderlist.price = item.PriceInclTax.ToString();


                    goodsValue += item.Quantity * item.PriceInclTax;//
                    discount += item.Quantity * item.OrderDiscount;
                    taxTotal += item.Quantity * item.OrderTax;

                    orderlist.totalPrice = item?.TotalPrice.ToString("f2");

                    orderlist.currency = "142";
                    orderlist.ciqcountry = item.CiqCountry;
                    orderlist.country = item.Country;
                    orderlist.ciqcurrency = item.CiqCurrency;
                    orderlist.note = " ";

                    orderlist.shelfGoodsName = item.ShelfGoodsName;
                    orderlist.wraptypeCode = item.WrapTypeCode;
                    orderlist.purposeCode = item.PurposeCode;
                    orderlist.goodsModel = " ";
                    orderlist.goodsRegNo = " ";
                    orderlist_311.Add(orderlist);
                }
                else
                {
                    for (int j = 0; j < item.OrderItemDetails.Count; j++)
                    {
                        count++;
                        OrderList orderlist = new OrderList();

                        orderlist.gnum = count.ToString();
                        orderlist.itemNo = item.OrderItemDetails[j].AttributeSku?.Split('|')[0];
                        orderlist.itemName = item.ItemName;
                        orderlist.gmodel = item.ItemDescribe ?? " ";
                        orderlist.itemDescribe = item.ItemDescribe ?? " ";

                        orderlist.barCode = item.BarCode == "none" ? "0" : item.BarCode;
                        orderlist.unit = item?.Unit;
                        orderlist.qty = item?.OrderItemDetails?[j].Quantity.ToString("f2");
                        orderlist.price = item?.OrderItemDetails[j].Price.ToString("f2");
                        orderlist.totalPrice = (item.OrderItemDetails[j].Quantity* item.OrderItemDetails[j].Price).ToString("f2");// item?.OrderItemDetails==null item?.TotalPrice.ToString("f2"):item?.OrderItemDetails[j]..ToString("f2");

                        goodsValue += (item?.OrderItemDetails?[j].Quantity??0) * (item?.OrderItemDetails[j].Price??0);//
                        discount += (item?.OrderItemDetails?[j].Quantity ?? 0) * (item.OrderItemDetails?[j].OrderDiscount??0);
                        taxTotal += (item?.OrderItemDetails?[j].Quantity ?? 0) * (item.OrderItemDetails?[j].OrderTax ?? 0);



                        orderlist.currency = "142";
                        orderlist.ciqcountry = item.CiqCountry;
                        orderlist.country = item.Country;
                        orderlist.ciqcurrency = item.CiqCurrency;
                        orderlist.note = " ";

                        orderlist.shelfGoodsName = item.ShelfGoodsName;
                        orderlist.wraptypeCode = item.WrapTypeCode;
                        orderlist.purposeCode = item.PurposeCode;
                        orderlist.goodsModel = " ";
                        orderlist.goodsRegNo = " ";
                        orderlist_311.Add(orderlist);
                    }
                }
            }
            orderhead_311.goodsValue = goodsValue.ToString("f2");
            orderhead_311.freight = freight.ToString("f2");
            orderhead_311.discount = discount.ToString("f2");
            orderhead_311.taxTotal = taxTotal.ToString("f2");
            orderhead_311.acturalPaid = orderhead_311.acturalPaid = (goodsValue + freight + taxTotal - discount).ToString("f2"); 


            order_311.OrderHead = orderhead_311;
            order_311.OrderList = orderlist_311;

            message_311.Order = order_311;
            message_311.BaseTransfer = basetransfer;
            message_311.guid = "FBF24A92-B66D-4EE3-8A5B-1007C2A39777";
            message_311.version = "v1.0";
            message_311.sendCode = userinfo.cebCode;// "Q120600201905000322";
            message_311.reciptCode = "121500";

            XmlSerializer xsOrder = new XmlSerializer(typeof(ENT311Message));
            using (var stream = new MemoryStream())
            {
                try
                {
                    XmlWriterSettings setting = new XmlWriterSettings();
                    setting.Encoding = Encoding.GetEncoding("UTF-8");

                    setting.Indent = true;
                    setting.IndentChars = "    ";
                    setting.NewLineChars = "\r\n";
                    setting.OmitXmlDeclaration = false;

                    XmlWriter wrint = XmlWriter.Create(stream, setting);
                    var n = new XmlSerializerNamespaces();
                    n.Add("", "http://www.chinaport.gov.cn/ENT");


                    //n.Add("ceb", "http://www.chinaport.gov.cn/ceb");
                    //n.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                    xsOrder.Serialize(wrint, message_311, n);
                    wrint.Close();
                }
                catch (Exception ex)
                {

                }
                stream.Position = 0;
                StreamReader sr = new StreamReader(stream);
                reStr = sr.ReadToEnd();
                sr.Dispose();
                stream.Dispose();
                _IRabbitMQHelper.Publish<custom311Controller>(reStr);
            }
            return reStr;
        }
        private string Custom_GuangZhou(Order order, UserInfo userinfo)
        {
            string reStr = "";
            ENT311Message_GuangZhou message_311 = new ENT311Message_GuangZhou();



            Order_311_GuangZhou order_311 = new Order_311_GuangZhou();
            OrderHead_GuangZhou orderhead_311 = new OrderHead_GuangZhou();
            List<OrderList_GuangZhou> orderlist_311 = new List<OrderList_GuangZhou>();


            #region ///311报关头部
            orderhead_311.guid = order.OrderGuid.ToString();
            orderhead_311.appType = "1";
            orderhead_311.appTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            orderhead_311.appStatus = "2";
            orderhead_311.orderType = "I";

            orderhead_311.orderNo = order.OrderNo;
            //orderhead_311.goodsValue = order?.OrderTotal.ToString("f2");
            //orderhead_311.freight = "0";
            //orderhead_311.discount = "0";
            //orderhead_311.acturalPaid = order?.OrderTotal.ToString("f2");
            //orderhead_311.taxTotal = order?.OrderTotal.ToString("f2");


            decimal goodsValue = 0;//商品实际成交价格
            decimal freight = 0;//运杂费
            decimal discount = 0;//抵扣金额
            decimal taxTotal = 0;//税款
            decimal acturalPaid = 0;//实际支付


            orderhead_311.currency = "142";

            orderhead_311.buyerRegNo = order.BuyerRegNo;
            orderhead_311.buyerName = order.BuyerName;
            orderhead_311.buyerTelephone = order.BuyerTelephone;
            orderhead_311.buyerIdType = order.BuyerIdType;
            orderhead_311.buyerIdNumber = order.BuyerIdNumber;

            orderhead_311.payCode = order.PayCode;
            orderhead_311.payName = order.PayName;
            orderhead_311.payTransactionId = order.PayTransactionId;
            orderhead_311.batchNumbers = " ";
            orderhead_311.consignee = order.Consignee;

            orderhead_311.consigneeTelephone = order.ConsigneeTelephone;
            orderhead_311.consigneeAddress = order.ConsigneeAddress;
            orderhead_311.consigneeDitrict = order.ConsigneeDitrict;
            orderhead_311.note = " ";
            //orderhead_311.agentCode = " ";

            //orderhead_311.consigneeCountryCode = order.EtradeCountryCode;
            //orderhead_311.idCard = order.IdCard;
            //orderhead_311.idType = order.IdType;
            //orderhead_311.etradeCountryCode = order.EtradeCountryCode;
            //orderhead_311.orderSerialNo = userinfo.ecpCode + order.SubOrderNo;


            orderhead_311.ebcCode = userinfo.ebcCode;
            orderhead_311.ebcName = userinfo.ebcName;
            orderhead_311.ebpCode = userinfo.ebpCode;
            orderhead_311.ebpName = userinfo.ebpName;
            //orderhead_311.ecpCode = userinfo.ecpCode;

            //orderhead_311.cbeCode = userinfo.cebCode;

            BaseTransfer_GuangZhou basetransfer = new BaseTransfer_GuangZhou();
            basetransfer.copCode = userinfo.copCode;
            basetransfer.copName = userinfo.copName;
            basetransfer.dxpMode = "DXP";
            basetransfer.dxpId = userinfo.dxpId;
            basetransfer.note = " ";
            #endregion

            int count = 0;
            for (int i = 0; i < order.OrderItems.Count; i++)
            {
                OrderItem item = order.OrderItems[i];
                //orderhead_311.ciqcurrency = item.CiqCurrency;
                //orderhead_311.bizType = item.TradeType.ToString();
                //orderhead_311.intype = item.TradeType.ToString();

                if (item.OrderItemDetails == null)
                {
                    count++;
                    OrderList_GuangZhou orderlist = new OrderList_GuangZhou();

                    orderlist.gnum = count.ToString();
                    orderlist.itemNo = item.ProductSku;
                    orderlist.itemName = item.ItemName;
                    orderlist.gmodel = item.ItemDescribe??" ";
                    orderlist.itemDescribe = item.ItemDescribe??" ";

                    orderlist.barCode = item.BarCode=="none"?"0":item.BarCode;
                    orderlist.unit = item.Unit;
                    orderlist.qty = item.Quantity.ToString();
                    orderlist.price = item?.PriceInclTax.ToString("f2");


                    goodsValue += item.Quantity * item.PriceInclTax;//
                    discount += item.Quantity * item.OrderDiscount;//
                    taxTotal += item.Quantity * item.OrderTax;//


                    orderlist.totalPrice = item?.TotalPrice.ToString("f2");

                    orderlist.currency = "142";
                    //orderlist.ciqcountry = item.CiqCountry;
                    orderlist.country = item.Country;
                    //orderlist.ciqcurrency = item.CiqCurrency;
                    orderlist.note = " ";

                    //orderlist.shelfGoodsName = item.ShelfGoodsName;
                    //orderlist.wraptypeCode = item.WrapTypeCode;
                    //orderlist.purposeCode = item.PurposeCode;
                    //orderlist.goodsModel = "";
                    //orderlist.goodsRegNo = "";
                    orderlist_311.Add(orderlist);
                }
                else
                {
                    for (int j = 0; j < item.OrderItemDetails.Count; j++)
                    {
                        count++;
                        OrderList_GuangZhou orderlist = new OrderList_GuangZhou();

                        orderlist.gnum = count.ToString();
                        orderlist.itemNo = item?.OrderItemDetails[j]?.AttributeSku;
                        orderlist.itemName = item.ItemName;
                        orderlist.gmodel = item.ItemDescribe ?? " ";
                        orderlist.itemDescribe = item.ItemDescribe ?? " ";

                        orderlist.barCode = item?.OrderItemDetails?[j].BarCode == "none" ? "0" : item?.OrderItemDetails?[j].BarCode;
                        orderlist.unit = item.Unit;
                        orderlist.qty = item?.OrderItemDetails?[j].Quantity.ToString("f2");
                        orderlist.price = item?.OrderItemDetails?[j].Price.ToString("f2");
                        orderlist.totalPrice = (item.OrderItemDetails[j].Quantity * item.OrderItemDetails[j].Price).ToString("f2");//item.TotalPrice.ToString("f2");

                        goodsValue += (item?.OrderItemDetails?[j].Quantity ?? 0) * (item?.OrderItemDetails[j].Price ?? 0);//
                        discount += (item?.OrderItemDetails?[j].Quantity ?? 0) * (item.OrderItemDetails?[j].OrderDiscount ?? 0);//
                        taxTotal += (item?.OrderItemDetails?[j].Quantity ?? 0) * (item.OrderItemDetails?[j].OrderTax ?? 0);//


                        orderlist.currency = "142";
                        //orderlist.ciqcountry = item.CiqCountry;
                        orderlist.country = item.Country;
                        //orderlist.ciqcurrency = item.CiqCurrency;
                        orderlist.note = " ";

                        //orderlist.shelfGoodsName = item.ShelfGoodsName;
                        //orderlist.wraptypeCode = item.WrapTypeCode;
                        //orderlist.purposeCode = item.PurposeCode;
                        //orderlist.goodsModel = "";
                        //orderlist.goodsRegNo = "";
                        orderlist_311.Add(orderlist);
                    }
                }
            }
            orderhead_311.goodsValue = goodsValue.ToString("f2");
            orderhead_311.freight = freight.ToString("f2");
            orderhead_311.discount = discount.ToString("f2");
            orderhead_311.taxTotal = taxTotal.ToString("f2");
            orderhead_311.acturalPaid = (goodsValue+freight+taxTotal-discount).ToString("f2");



            order_311.OrderHead = orderhead_311;
            order_311.OrderList = orderlist_311;

            message_311.Order = order_311;
            message_311.BaseTransfer = basetransfer;
            message_311.guid = "D188F4BC-F072-449B-BA90-496CCAF7C33A";
            message_311.version = "v1.0";
            //message_311.sendCode = "Q120000201706151205";
            //message_311.reciptCode = "121500";

            XmlSerializer xsOrder = new XmlSerializer(typeof(ENT311Message_GuangZhou));
            using (var stream = new MemoryStream())
            {
                try
                {
                    XmlWriterSettings setting = new XmlWriterSettings();
                    setting.Encoding = Encoding.GetEncoding("UTF-8");

                    setting.Indent = true;
                    setting.IndentChars = "    ";
                    setting.NewLineChars = "\r\n";
                    setting.OmitXmlDeclaration = false;

                    XmlWriter wrint = XmlWriter.Create(stream, setting);
                    var n = new XmlSerializerNamespaces();
                    //n.Add("", "http://www.chinaport.gov.cn/ENT");


                    n.Add("ceb", "http://www.chinaport.gov.cn/ceb");
                    n.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                    wrint.WriteStartDocument(false);
                    xsOrder.Serialize(wrint, message_311, n);
                    wrint.Close();
                }
                catch (Exception ex)
                {

                }
                stream.Position = 0;
                StreamReader sr = new StreamReader(stream);
                reStr = sr.ReadToEnd();
                sr.Dispose();
                stream.Dispose();
                _IRabbitMQHelper.Publish<ENT311Message_GuangZhou>(reStr);
            }
            return reStr;
        }
    }
}
