using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using api_ecmall.Domain.Entities.Pay;
using api_ecmall.Domain.Abstract;
using api_ecmall.WebUI.Areas.Orders.Models;
using Newtonsoft.Json;
using api_ecmall.Domain.Entities.Orders;
using api_ecmall.Domain.Entities;
using XML311.XmlModel;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Text;
using api_ecmall.WebUI.Settings;
using api_ecmall.WebUI.Areas.WMS.Models;

namespace api_ecmall.WebUI.Areas.Orders.Controllers
{
    /// <summary>
    /// 订单接口集合
    /// </summary>
    public class OrdersController : ApiController
    {
        private IRabbitMQHelper _IRabbitMQHelper;
        private IEcmOrderRepository _iEcmOrder;
        private ILog4netHelper _logger;
        private IUserRepository _IUserRepository;
        private IPayOrderRepository _IPayOrderRepository;
        private ISetting _ISetting;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="IRabbitMQHelper"></param>
        /// <param name="iEcmOrder"></param>
        /// <param name="logger"></param>
        /// <param name="IUserRepository"></param>
        /// <param name="IPayOrderRepository"></param>
        public OrdersController(IRabbitMQHelper IRabbitMQHelper, IEcmOrderRepository iEcmOrder, ILog4netHelper logger, IUserRepository IUserRepository, IPayOrderRepository IPayOrderRepository, ISetting ISetting)
        {
            _IRabbitMQHelper = IRabbitMQHelper;
            _iEcmOrder = iEcmOrder;
            _logger = logger;
            _IUserRepository = IUserRepository;
            _IPayOrderRepository = IPayOrderRepository;
            _ISetting = ISetting;
        }
        /// <summary>
        /// 支付报关提交订单
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Route("api/order/PaymentOrder")]
        public IHttpActionResult Post([FromBody]PayOrder value)
        {
            string UserName = User.Identity.Name;
            PayOrder_Re response = new PayOrder_Re();
            PayOrderViewModel viewmodel = new PayOrderViewModel();
            try
            {
                if (ModelState.IsValid)
                {
                    if (!string.IsNullOrEmpty(UserName))
                    {
                        var userinfo = _IUserRepository.UserInfos.Where(t => t.UserName == UserName).FirstOrDefault();
                        if (userinfo == null)
                        {
                            response.success = "fail";
                            response.code = PayCode.fail;
                            response.msg = "未查询到用户信息";
                        }
                        else
                        {
                            viewmodel.payorder = value;
                            viewmodel.userinfo = userinfo;
                            _IRabbitMQHelper.Publish<OrdersController>(JsonConvert.SerializeObject(viewmodel));
                            _IPayOrderRepository.Save_PayOrder(value);
                            _logger.WriteLog_Info<OrdersController>(JsonConvert.SerializeObject(viewmodel), null, null, null);
                        }
                    }
                    else
                    {
                        _logger.WriteLog_Waring<OrdersController>(JsonConvert.SerializeObject(viewmodel), null, null, null);
                    }
                }
                else
                {
                    _logger.WriteLog_Error<OrdersController>(JsonConvert.SerializeObject(viewmodel), null, null, null);
                }
            }
            catch (Exception ex)
            {
                _logger.WriteLog_Error<OrdersController>(JsonConvert.SerializeObject(viewmodel), null, null, ex);
            }
            return Json(response);
        }


        #region///作废311订单接口

        ///// <summary>
        ///// 311订单接受接口
        ///// </summary>
        ///// <param name="value">Order订单</param>
        ///// <returns></returns>
        //[Route("api/order/Receive311Order")]
        //public string Post([FromBody]Order value)
        //{
        //    string reStr = "";
        //    if (ModelState.IsValid)
        //    {
        //        string username = User.Identity.Name;
        //        UserInfo userinfo = new UserInfo();//   _IUserRepository.UserInfos.Where(t => t.UserName == username).FirstOrDefault();
        //        userinfo = _IUserRepository.UserInfos.Where(t => t.userId == value.OrderItems[0].CustomsChannelId.ToString()).FirstOrDefault();


        //        value.OrderGuid = Guid.NewGuid();
        //        value.api_type = 1;

        //        ENT311Message message_311 = new ENT311Message();



        //        Order_311 order_311 = new Order_311();
        //        OrderHead orderhead_311 = new OrderHead();
        //        List<OrderList> orderlist_311 = new List<OrderList>();


        //        #region ///311报关头部
        //        orderhead_311.guid = value.OrderGuid.ToString();
        //        orderhead_311.appType = "1";
        //        orderhead_311.appTime = DateTime.Now.ToString("yyyyMMDDHHmmss");
        //        orderhead_311.appStatus = "2";
        //        orderhead_311.orderType = "I";

        //        orderhead_311.orderNo = value.SubOrderNo;
        //        orderhead_311.freight = "0";
        //        orderhead_311.discount = "0";
        //        orderhead_311.acturalPaid = value.OrderTotal.ToString();
        //        orderhead_311.currency = "142";

        //        orderhead_311.buyerRegNo = value.BuyerRegNo;
        //        orderhead_311.buyerName = value.BuyerName;
        //        orderhead_311.buyerTelephone = value.BuyerTelephone;
        //        orderhead_311.buyerIdType = value.BuyerIdType;
        //        orderhead_311.buyerIdNumber = value.BuyerIdNumber;

        //        orderhead_311.payCode = value.PayCode;
        //        orderhead_311.payName = value.PayName;
        //        orderhead_311.payTrCsactionId = value.PayTransactionId;
        //        orderhead_311.batchNumbers = "";
        //        orderhead_311.consignee = value.Consignee;

        //        orderhead_311.consigneeTelephone = value.ConsigneeTelephone;
        //        orderhead_311.consignorAddress = value.ConsigneeAddress;
        //        orderhead_311.consigneeDitrict = value.ConsigneeDitrict;
        //        orderhead_311.note = "";
        //        orderhead_311.agentCode = "";

        //        orderhead_311.consigneeCountryCode = value.EtradeCountryCode;
        //        orderhead_311.idCard = "";
        //        orderhead_311.idType = "";
        //        orderhead_311.etradeCountryCode = value.EtradeCountryCode;
        //        orderhead_311.orderSerialNo = userinfo.ecpCode + value.SubOrderNo;


        //        orderhead_311.ebcCode = userinfo.ebcCode;
        //        orderhead_311.ebcName = userinfo.ebcName;
        //        orderhead_311.ebpCode = userinfo.ebpCode;
        //        orderhead_311.ebpName = userinfo.ebpName;
        //        orderhead_311.ecpCode = userinfo.ecpCode;

        //        orderhead_311.cbeCode = userinfo.cebCode;

        //        BaseTransfer basetransfer = new BaseTransfer();
        //        basetransfer.copCode = userinfo.copCode;
        //        basetransfer.copName = userinfo.copName;
        //        basetransfer.dxpMode = "DXP";
        //        basetransfer.dxpId = userinfo.dxpId;
        //        basetransfer.note = " ";
        //        #endregion

        //        int count = 0;
        //        for (int i = 0; i < value.OrderItems.Count; i++)
        //        {
        //            OrderItem item = value.OrderItems[i];
        //            orderhead_311.ciqcurrency = item.CiqCurrency;
        //            orderhead_311.bizType = item.TradeType.ToString();
        //            orderhead_311.intype = item.TradeType.ToString();

        //            if (item.OrderItemDetails != null)
        //            {
        //                count++;
        //                OrderList orderlist = new OrderList();

        //                orderlist.gnum = count.ToString();
        //                orderlist.itemNo = item.ProductSku;
        //                orderlist.itemName = item.ItemName;
        //                orderlist.gmodel = item.ItemDescribe;
        //                orderlist.itemDescribe = item.ItemDescribe;

        //                orderlist.barCode = item.BarCode;
        //                orderlist.unit = item.Unit;
        //                orderlist.qty = item.Quantity.ToString();
        //                orderlist.price = item.PriceInclTax.ToString();
        //                orderlist.totalPrice = item.TotalPrice.ToString();

        //                orderlist.currency = "142";
        //                orderlist.ciqcountry = item.CiqCountry;
        //                orderlist.country = item.Country;
        //                orderlist.ciqcurrency = item.CiqCurrency;
        //                orderlist.note = " ";

        //                orderlist.shelfGoodsName = item.ShelfGoodsName;
        //                orderlist.wraptypeCode = item.WrapTypeCode;
        //                orderlist.purposeCode = item.PurposeCode;
        //                orderlist.goodsModel = "";
        //                orderlist.goodsRegNo = "";
        //                orderlist_311.Add(orderlist);
        //            }
        //            else
        //            {
        //                for (int j = 0; j < item.OrderItemDetails.Count; j++)
        //                {
        //                    count++;
        //                    OrderList orderlist = new OrderList();

        //                    orderlist.gnum = count.ToString();
        //                    orderlist.itemNo = item.OrderItemDetails[j].AttributeSku;
        //                    orderlist.itemName = item.ItemName;
        //                    orderlist.gmodel = item.ItemDescribe;
        //                    orderlist.itemDescribe = item.ItemDescribe;

        //                    orderlist.barCode = item.OrderItemDetails[j].BarCode;
        //                    orderlist.unit = item.Unit;
        //                    orderlist.qty = item.OrderItemDetails[j].Quantity.ToString();
        //                    orderlist.price = item.OrderItemDetails[j].Price.ToString();
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
        //            }
        //        }

        //        order_311.OrderHead = orderhead_311;
        //        order_311.OrderList = orderlist_311;

        //        message_311.Order = order_311;
        //        message_311.BaseTransfer = basetransfer;
        //        message_311.guid = "FBF24A92-B66D-4EE3-8A5B-1007C2A39777";
        //        message_311.version = "v1.0";
        //        message_311.sendCode = "Q120000201706151205";
        //        message_311.reciptCode = "121500";

        //        XmlSerializer xsOrder = new XmlSerializer(typeof(ENT311Message));
        //        using (var stream = new MemoryStream())
        //        {
        //            try
        //            {
        //                XmlWriterSettings setting = new XmlWriterSettings();
        //                setting.Encoding = Encoding.GetEncoding("UTF-8");

        //                setting.Indent = true;
        //                setting.IndentChars = "    ";
        //                setting.NewLineChars = "\r\n";
        //                setting.OmitXmlDeclaration = false;

        //                XmlWriter wrint = XmlWriter.Create(stream, setting);
        //                var n = new XmlSerializerNamespaces();
        //                n.Add("", "http://www.chinaport.gov.cn/ENT");
        //                xsOrder.Serialize(wrint, message_311, n);
        //                wrint.Close();
        //            }
        //            catch (Exception ex)
        //            {

        //            }
        //            stream.Position = 0;
        //            StreamReader sr = new StreamReader(stream);
        //            reStr = sr.ReadToEnd();
        //            sr.Dispose();
        //            stream.Dispose();
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest(ModelState).ToString();
        //    }
        //    return reStr;
        //}

        #endregion

        /// <summary>
        /// 接受订单提交，把订单添加到MQ中，异步返回订单状态，
        /// (ECMALL-API矩阵-OMS-WMS)
        /// </summary>
        /// <param name="order">Order订单实体</param>
        /// <returns>提交验证结果 API_Message</returns>
        [Route("api/order/ReceiveOrder")]
        public IHttpActionResult ReceiveOrder([FromBody] Order order)
        {
            API_Message api_message = new API_Message();
            api_message.MessageCode = ((int)m_Code.Success).ToString();
            if (ModelState.IsValid)
            {
                try
                {
                    order.OrderGuid = Guid.NewGuid();
                    order.api_type = 1;
                    for (int i = 0; i < order.OrderItems.Count; i++)
                    {
                        order.OrderItems[i].ItemGuid = Guid.NewGuid();
                    }
                    _iEcmOrder.Save_Orders(order);
                    _IRabbitMQHelper.Publish<OrdersController>(JsonConvert.SerializeObject(order));
                    _logger.WriteLog_Info<OrdersController>(JsonConvert.SerializeObject(order), null, null, null);
                }
                catch (Exception ex)
                {
                    _logger.WriteLog_Error<OrdersController>(JsonConvert.SerializeObject(order), null, null, ex);
                }
                //return Json(api_message);
            }
            else
            {
                var modelstate = BadRequest(ModelState);
                string returestr = "";
                foreach (var item in modelstate.ModelState.Values)
                {
                    returestr += item.Errors != null ? item.Errors[0].ErrorMessage + "\r\n" : "";
                }
                api_message.ErrorMsg = returestr;
                api_message.MessageCode = ((int)m_Code.Faile).ToString();
                _logger.WriteLog_Error<OrdersController>(JsonConvert.SerializeObject(order), null, null, null);
                _logger.WriteLog_Error<OrdersController>(JsonConvert.SerializeObject(api_message), null, null, null);
            }
            return Json(api_message);
        }



        /// <summary>
        /// 订单状态的更改，通知ECMALL订单状态的更改，
        /// (OMS-API矩阵-ECMALL)
        /// </summary>
        /// <param name="value">order_status</param>
        /// <returns>API_Message</returns>
        [Route("api/order/status_update")]
        public IHttpActionResult Post([FromBody]order_status value)
        {
            API_Message message = new API_Message();
            try
            {
                if (ModelState.IsValid)
                {
                    message.MessageCode = ((int)m_Code.Success).ToString();
                    _IRabbitMQHelper.Publish<status_updateController>(JsonConvert.SerializeObject(value));
                    _logger.WriteLog_Info<status_updateController>(JsonConvert.SerializeObject(value), null, null, null);
                }
                else
                {
                    var modelstate = BadRequest(ModelState);
                    string returestr = "";
                    foreach (var item in modelstate.ModelState.Values)
                    {
                        returestr += item.Errors != null ? item.Errors[0].ErrorMessage + " \r\n" : "";
                    }
                    message.ErrorMsg = returestr;
                    message.MessageCode = ((int)m_Code.Faile).ToString();// m_Code.Faile.ToString();
                    _logger.WriteLog_Error<status_updateController>(JsonConvert.SerializeObject(value), null, null, null);
                    _logger.WriteLog_Error<status_updateController>(JsonConvert.SerializeObject(message), null, null, null);
                }
            }
            catch (Exception ex)
            {
                _logger.WriteLog_Error<status_updateController>(JsonConvert.SerializeObject(message), null, null, ex);
            }
            return Json(message);
        }
        /// <summary>
        /// 订单状态的更改，通知OMS订单状态的更改(取消)，
        /// (ECMALL-API矩阵-OMS)
        /// </summary>
        /// <param name="value">order_status</param>
        /// <returns>API_Message</returns>
        [Route("api/order/UpdateOrderStatus")]
        public IHttpActionResult UpdateOrderStatus([FromBody]Orders.Models.OrderStatusViewModel value)
        {
            string reStr = "";
            API_Message message = new API_Message();
            try
            {
                if (ModelState.IsValid)
                {
                    message.MessageCode = ((int)m_Code.Success).ToString();
                    string post = JsonConvert.SerializeObject(value);
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json");
                    byte[] reByte = client.UploadData(_ISetting.oms.Base_Url + "/API/Order/UpdateOrderStatus", Encoding.UTF8.GetBytes(post));
                    reStr = Encoding.UTF8.GetString(reByte);
                    message = JsonConvert.DeserializeObject<API_Message>(reStr);
                    _logger.WriteLog_Info<UpdateOrderStatus>(reStr, null, "ecmall返回", null);
                    _logger.WriteLog_Info<UpdateOrderStatus>(JsonConvert.SerializeObject(value), null, null, null);
                }
                else
                {
                    var modelstate = BadRequest(ModelState);
                    string returestr = "";
                    foreach (var item in modelstate.ModelState.Values)
                    {
                        returestr += item.Errors != null ? item.Errors[0].ErrorMessage + " \r\n" : "";
                    }
                    message.ErrorMsg = returestr;
                    message.MessageCode = ((int)m_Code.Faile).ToString();// m_Code.Faile.ToString();
                    _logger.WriteLog_Error<UpdateOrderStatus>(JsonConvert.SerializeObject(value), null, null, null);
                    _logger.WriteLog_Error<UpdateOrderStatus>(JsonConvert.SerializeObject(message), null, null, null);
                }
            }
            catch (Exception ex)
            {
                message.MessageCode = ((int)m_Code.Faile).ToString();
                message.ErrorMsg = reStr;
                _logger.WriteLog_Error<UpdateOrderStatus>(JsonConvert.SerializeObject(message), null, null, ex);
            }
            return Json(message);
        }
        /// <summary>
        /// OMS顾客退货
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Route("api/order/CustomerRefunds")]
        public HttpResponseMessage CustomerRefunds([FromBody]CustomerRefundsInfoViewModel value)
        {
            string reStr = "";
            ApiJsonResult<object> message = new ApiJsonResult<object>();
            try
            {
                if (ModelState.IsValid)
                {
                    message.success = true;
                    message.code = 200;
                    string post = JsonConvert.SerializeObject(value);
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json");
                    byte[] reByte = client.UploadData(_ISetting.oms.Base_Url + "/api/Order/CustomerRefunds", Encoding.UTF8.GetBytes(post));
                    reStr = Encoding.UTF8.GetString(reByte);
                    //message = JsonConvert.DeserializeObject<ApiJsonResult<object>>(reStr);
                    _logger.WriteLog_Info<OMS顾客退货>(reStr, null, "ecmall返回", null);
                    _logger.WriteLog_Info<OMS顾客退货>(JsonConvert.SerializeObject(value), null, null, null);
                }
                else
                {
                    var modelstate = BadRequest(ModelState);
                    string returestr = "";
                    foreach (var item in modelstate.ModelState.Values)
                    {
                        returestr += item.Errors != null ? item.Errors[0].ErrorMessage + " \r\n" : "";
                    }
                    message.msg = returestr;
                    message.success = false;// m_Code.Faile.ToString();
                    reStr = JsonConvert.SerializeObject(message);
                    _logger.WriteLog_Error<OMS顾客退货>(JsonConvert.SerializeObject(value), null, null, null);
                    _logger.WriteLog_Error<OMS顾客退货>(JsonConvert.SerializeObject(message), null, null, null);
                }
            }
            catch (Exception ex)
            {
                message.success = false;
                message.msg = ex.Message.ToString();
                reStr = JsonConvert.SerializeObject(message);
                _logger.WriteLog_Error<OMS顾客退货>(JsonConvert.SerializeObject(message), null, null, ex);
            }
            return new HttpResponseMessage { Content = new StringContent(reStr, Encoding.UTF8) };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Route("api/order/QueryRefundStatus")]
        public HttpResponseMessage QueryRefundStatus([FromBody]QueryRefundViewModel value)
        {
            string reStr = "";
            ApiJsonResult<List<RefundRe>> message = new ApiJsonResult<List<RefundRe>>();
            try
            {
                if (ModelState.IsValid)
                {
                    message.success = true;
                    message.code = 200;
                    string post = JsonConvert.SerializeObject(value);
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json");
                    byte[] reByte = client.UploadData(_ISetting.oms.Base_Url + "/api/Order/QueryRefundStatus", Encoding.UTF8.GetBytes(post));
                    reStr = Encoding.UTF8.GetString(reByte);
                    //message = JsonConvert.DeserializeObject<ApiJsonResult<object>>(reStr);
                    _logger.WriteLog_Info<Ecmall退款>(reStr, null, "oms返回", null);
                    _logger.WriteLog_Info<Ecmall退款>(JsonConvert.SerializeObject(value), null, null, null);
                }
                else
                {
                    var modelstate = BadRequest(ModelState);
                    string returestr = "";
                    foreach (var item in modelstate.ModelState.Values)
                    {
                        returestr += item.Errors != null ? item.Errors[0].ErrorMessage + " \r\n" : "";
                    }
                    message.msg = returestr;
                    message.success = false;// m_Code.Faile.ToString();
                    reStr = JsonConvert.SerializeObject(message);
                    _logger.WriteLog_Error<Ecmall退款>(JsonConvert.SerializeObject(value), null, null, null);
                    _logger.WriteLog_Error<Ecmall退款>(JsonConvert.SerializeObject(message), null, null, null);
                }
            }
            catch (Exception ex)
            {
                message.success = false;
                message.msg = ex.Message.ToString();
                reStr = JsonConvert.SerializeObject(message);
                _logger.WriteLog_Error<Ecmall退款>(JsonConvert.SerializeObject(message), null, null, ex);
            }
            return new HttpResponseMessage { Content = new StringContent(reStr, Encoding.UTF8) };
        }
        /// <summary>
        /// OMS顾客退款
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Route("api/order/Financial")]
        public HttpResponseMessage OMSFinancial([FromBody]RefundsOrderViewModel value)
        {
            string reStr = "";
            ApiJsonResult<RefundQueryOrderViewModel> message = new ApiJsonResult<RefundQueryOrderViewModel>();
            try
            {
                if (ModelState.IsValid)
                {
                    message.success = true;
                    message.code = 200;
                    string post = JsonConvert.SerializeObject(value);
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json");
                    byte[] reByte = client.UploadData(_ISetting.ecmall.Base_Url + "/appserver/index.php?m=api&c=Financial&a=omsFinancial", Encoding.UTF8.GetBytes(post));
                    reStr = Encoding.UTF8.GetString(reByte);
                    //message = JsonConvert.DeserializeObject<ApiJsonResult<object>>(reStr);
                    _logger.WriteLog_Info<OMS顾客退款>(reStr, null, "ecmall返回", null);
                    _logger.WriteLog_Info<OMS顾客退款>(JsonConvert.SerializeObject(value), null, null, null);
                }
                else
                {
                    var modelstate = BadRequest(ModelState);
                    string returestr = "";
                    foreach (var item in modelstate.ModelState.Values)
                    {
                        returestr += item.Errors != null ? item.Errors[0].ErrorMessage + " \r\n" : "";
                    }
                    message.msg = returestr;
                    message.success = false;// m_Code.Faile.ToString();
                    reStr = JsonConvert.SerializeObject(message);
                    _logger.WriteLog_Error<OMS顾客退款>(JsonConvert.SerializeObject(value), null, null, null);
                    _logger.WriteLog_Error<OMS顾客退款>(JsonConvert.SerializeObject(message), null, null, null);
                }
            }
            catch (Exception ex)
            {
                message.success = false;
                message.msg = ex.Message.ToString() + "ecmall连接错误";
                reStr = JsonConvert.SerializeObject(message);
                _logger.WriteLog_Error<OMS顾客退款>(JsonConvert.SerializeObject(message), null, null, ex);
            }
            return new HttpResponseMessage { Content = new StringContent(reStr, Encoding.UTF8) };
        }
        /// <summary>
        /// ECMALL顾客退款(Ecmall--OMS)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Route("api/order/OrderRefund")]
        public HttpResponseMessage EcmallOrderRefund([FromBody] EcmallRefundsOrderViewModel value)
        {
            string reStr = "";
            ApiJsonResult<object> message = new ApiJsonResult<object>();
            try
            {
                if (ModelState.IsValid)
                {
                    message.success = true;
                    message.code = 200;
                    string post = JsonConvert.SerializeObject(value);
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json");
                    byte[] reByte = client.UploadData(_ISetting.oms.Base_Url + "/API/Order/OrderRefund", Encoding.UTF8.GetBytes(post));
                    reStr = Encoding.UTF8.GetString(reByte);
                    //message = JsonConvert.DeserializeObject<ApiJsonResult<object>>(reStr);
                    _logger.WriteLog_Info<Ecmall顾客退款>(reStr, null, "ecmall返回", null);
                    _logger.WriteLog_Info<Ecmall顾客退款>(JsonConvert.SerializeObject(value), null, null, null);
                }
                else
                {
                    var modelstate = BadRequest(ModelState);
                    string returestr = "";
                    foreach (var item in modelstate.ModelState.Values)
                    {
                        returestr += item.Errors != null ? item.Errors[0].ErrorMessage + " \r\n" : "";
                    }
                    message.msg = returestr;
                    message.success = false;// m_Code.Faile.ToString();
                    reStr = JsonConvert.SerializeObject(message);
                    _logger.WriteLog_Error<Ecmall顾客退款>(JsonConvert.SerializeObject(value), null, null, null);
                    _logger.WriteLog_Error<Ecmall顾客退款>(JsonConvert.SerializeObject(message), null, null, null);
                }
            }
            catch (Exception ex)
            {
                message.success = false;
                message.msg = ex.Message.ToString() + "oms连接错误";
                reStr = JsonConvert.SerializeObject(message);
                _logger.WriteLog_Error<Ecmall顾客退款>(JsonConvert.SerializeObject(message), null, null, ex);
            }
            return new HttpResponseMessage { Content = new StringContent(reStr, Encoding.UTF8) };
        }
        /// <summary>
        /// Ecmall创建心愿单接口(Ecmall--OMS)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Route("api/order/CreateWish")]
        public HttpResponseMessage EcmallCreateWish([FromBody] EcmallRefundsOrderViewModel value)
        {
            string reStr = "";
            ApiJsonResult<object> message = new ApiJsonResult<object>();
            try
            {
                if (ModelState.IsValid)
                {
                    message.success = true;
                    message.code = 200;
                    string post = JsonConvert.SerializeObject(value);
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json");
                    byte[] reByte = client.UploadData(_ISetting.oms.Base_Url + "/API/Order/CreateWish", Encoding.UTF8.GetBytes(post));
                    reStr = Encoding.UTF8.GetString(reByte);
                    //message = JsonConvert.DeserializeObject<ApiJsonResult<object>>(reStr);
                    _logger.WriteLog_Info<Ecmall顾客退款>(reStr, null, "ecmall返回", null);
                    _logger.WriteLog_Info<Ecmall顾客退款>(JsonConvert.SerializeObject(value), null, null, null);
                }
                else
                {
                    var modelstate = BadRequest(ModelState);
                    string returestr = "";
                    foreach (var item in modelstate.ModelState.Values)
                    {
                        returestr += item.Errors != null ? item.Errors[0].ErrorMessage + " \r\n" : "";
                    }
                    message.msg = returestr;
                    message.success = false;// m_Code.Faile.ToString();
                    reStr = JsonConvert.SerializeObject(message);
                    _logger.WriteLog_Error<Ecmall顾客退款>(JsonConvert.SerializeObject(value), null, null, null);
                    _logger.WriteLog_Error<Ecmall顾客退款>(JsonConvert.SerializeObject(message), null, null, null);
                }
            }
            catch (Exception ex)
            {
                message.success = false;
                message.msg = ex.Message.ToString() + "oms连接错误";
                reStr = JsonConvert.SerializeObject(message);
                _logger.WriteLog_Error<Ecmall顾客退款>(JsonConvert.SerializeObject(message), null, null, ex);
            }
            return new HttpResponseMessage { Content = new StringContent(reStr, Encoding.UTF8) };
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class status_updateController
    {

    }
    /// <summary>
    /// 
    /// </summary>
    public class UpdateOrderStatus
    {

    }
    /// <summary>
    /// 
    /// </summary>
    public class OMS顾客退货
    {

    }
    /// <summary>
    /// 
    /// </summary>
    public class Ecmall退款
    {

    }
    /// <summary>
    /// 
    /// </summary>
    public class OMS顾客退款
    {

    }
    /// <summary>
    /// 
    /// </summary>
    public class Ecmall顾客退款
    {

    }
    /// <summary>
    /// 
    /// </summary>
    public class Ecmall创建心愿单接口
    {

    }
}
