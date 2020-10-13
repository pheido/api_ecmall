using api_ecmall.Domain.Abstract;
using api_ecmall.Domain.Entities;
using api_ecmall.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Com.Alipay;
using api_ecmall.Domain.Entities.Pay;
using Newtonsoft.Json;
using api_ecmall.WebUI.Areas.Customs.Models;

namespace api_ecmall.WebUI.Areas.Customs.Controllers
{
    /// <summary>
    /// 支付报关接口集合
    /// </summary>
    public class custompayController : ApiController
    {
        private IRabbitMQHelper _IRabbitMQHelper;
        private ILog4netHelper _ILog4netHelper;
        private IEcmOrderRepository _iEcmOrder;
        private IAlipayRepository _IAlipayRepository;
        private IUserRepository _IUserRepository;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="IRabbitMQHelper"></param>
        /// <param name="ILog4netHelper"></param>
        /// <param name="iEcmOrder"></param>
        /// <param name="IAlipayRepository"></param>
        /// <param name="IUserRepository"></param>
        public custompayController(IRabbitMQHelper IRabbitMQHelper, ILog4netHelper ILog4netHelper, IEcmOrderRepository iEcmOrder, IAlipayRepository IAlipayRepository, IUserRepository IUserRepository)
        {
            _IRabbitMQHelper = IRabbitMQHelper;
            _ILog4netHelper = ILog4netHelper;
            _iEcmOrder = iEcmOrder;
            _IAlipayRepository = IAlipayRepository;
            _IUserRepository = IUserRepository;
        }
        /// <summary>
        /// 支付报关api
        /// </summary>
        /// <param name="order">订单</param>
        /// <returns>API_Message</returns>
        [Route("api/pay/paycustom")]
        public IHttpActionResult paycustom([FromBody]Order order)
        {
            UserInfo user = new UserInfo();//报关通道实体
            AliPayOrder aliorder = new AliPayOrder();//支付报关实体
            alipay alipay_reponse = new alipay();


            wxpay wxpay = new wxpay();
            wxpay_re wxpay_re = new wxpay_re();
            WxpayViewModel wxpayviewmodel = new WxpayViewModel();

            API_Message message = new API_Message();
            message.MessageCode = "1";
            if (ModelState.IsValid)
            {
                try
                {
                    string userid = order.OrderItems?[0].OrderItemDetails?[0].CustomsChannelId.ToString();
                    user = _IUserRepository.UserInfos.Where(t => t.userId == (order.OrderItems?[0].OrderItemDetails?[0].CustomsChannelId.ToString()??order.OrderItems[0].CustomsChannelId.ToString())).FirstOrDefault();
                    if(user!=null && userid!=null)
                    {
                        order.OrderGuid = Guid.NewGuid();
                        order.api_type = 3;//类型:支付报关
                        for (int i = 0; i < order.OrderItems.Count; i++)
                        {
                            order.OrderItems[i].ItemGuid = Guid.NewGuid();
                        }
                        _iEcmOrder.Save_Orders(order);//保存接收order信息

                        if ((order?.PaymentMethodSystemName).Contains("支付宝"))
                        {

                            aliorder.partner = user.alipayAppId;
                            aliorder.out_request_no = order.SubOrderNo ?? "" + order.OrderNo.ToString();
                            //aliorder.trade_no = "2019052222001497581037471813";// order.PayTransactionId;
                            aliorder.trade_no = order.PayTransactionId; //"2019052322001491491036394115";// order.PayTransactionId;
                            aliorder.merchant_customs_code = user.ebpCode;// user.cebCode;
                            aliorder.amount = order.OrderTotal.ToString("f2"); //"0.01";// order.OrderTotal.ToString(".00");
                            aliorder.alipaySec = user.alipaySec;

                            aliorder.customs_place = user?.AlipayPortCode;// user.PortCode;// "tianjin";
                            aliorder.merchant_customs_name = user.copName;
                            aliorder.is_split = "F";
                            aliorder.buyer_name = order.BuyerName; // "李晨";// order.BuyerName;
                            aliorder.buyer_id_no = order.BuyerIdNumber; ;// "120102199966552141";// order.BuyerIdNumber;
                            _IRabbitMQHelper.Publish<custompayController>(JsonConvert.SerializeObject(aliorder));
                            if((user?.AlipayPortCode).ToLower().Contains("tianjin")|| (user?.AlipayPortCode).ToLower().Contains("guangzhou"))
                            {
                                aliorder.customs_place = "zongshu";// user?.AlipayPortCode;// user.PortCode;// "tianjin";
                                _IRabbitMQHelper.Publish_Delay<custompay_zongshuController>(JsonConvert.SerializeObject(aliorder), "custompayController");
                            }
                            _ILog4netHelper.WriteLog_Info<custompayController>(JsonConvert.SerializeObject(aliorder), null, "aliorder", null);
                            //alipay_reponse = _IAlipayRepository.alipay_update(aliorder, "ujsidc9esjszyov0fc0trsveq733ttvd");
                        }
                        else if((order?.PaymentMethodSystemName).Contains("财付通"))
                        {
                            wxpay.appid = user.wxappId;// "wx75732915fa967aca";
                            wxpay.mch_id = user.wxshopId;// "1536978981";
                            wxpay.out_trade_no = order.OrderNo;
                            wxpay.transaction_id = order.PayTransactionId;
                            wxpay.customs = user?.WxpayPortCode;// user.PortCode;//"GUANGZHOU_ZS";
                            wxpay.mch_customs_no =  user.copCode;
                            wxpay.cert_type = "IDCARD";
                            wxpay.cert_id = order?.BuyerIdNumber.ToUpper();
                            wxpay.name = order.BuyerName;

                            wxpayviewmodel.wxshopId = user.wxshopId;
                            wxpayviewmodel.wxpayCode = user.wxpayCode;
                            wxpayviewmodel.wxappId = user.wxappId;
                            wxpayviewmodel.wxpay = wxpay;

                            _IRabbitMQHelper.Publish<custompayController_wx>(JsonConvert.SerializeObject(wxpayviewmodel));
                            _ILog4netHelper.WriteLog_Info<custompayController>(JsonConvert.SerializeObject(wxpayviewmodel), null, "wxpayviewmodel", null);
                        }
                        _ILog4netHelper.WriteLog_Info<custompayController>(JsonConvert.SerializeObject(order), null, null, null);
                    }
                    else
                    {
                        message.MessageCode = "2";
                        message.ErrorMsg = "没有对应的报关通道";
                    }
                }
                catch (Exception ex)
                {
                    _ILog4netHelper.WriteLog_Error<custompayController>(JsonConvert.SerializeObject(order), null, null, ex);
                }
            }
            else
            {
                var modelstate = BadRequest(ModelState);
                string returestr = "";
                foreach (var item in modelstate.ModelState.Values)
                {
                    returestr += item.Errors != null ? item.Errors[0].ErrorMessage + "\r\n" : "";
                }
                message.MessageCode = "2";
                message.ErrorMsg = returestr;
            }
            return Json(message);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [Route("api/pay/paycustom_get")]
        public IHttpActionResult paycustom_get([FromBody]Order order)
        {
            UserInfo user = new UserInfo();//报关通道实体
            AliPayOrder aliorder = new AliPayOrder();//支付报关实体
            alipay alipay_reponse = new alipay();


            API_Message message = new API_Message();
            message.MessageCode = "1";
            if (ModelState.IsValid)
            {
                try
                {
                    user = _IUserRepository.UserInfos.Where(t => t.userId == order.OrderItems[0].CustomsChannelId.ToString()).FirstOrDefault();
                    if (user != null)
                    {
                        aliorder.partner = user.alipayAppId;
                        aliorder.out_request_no = order.SubOrderNo??"" +order.OrderNo.ToString();
                        aliorder.trade_no = order.PayTransactionId; //"2019052222001497581037471813";// order.PayTransactionId;
                        aliorder.merchant_customs_code = user.cebCode;
                        aliorder.amount = order.OrderTotal.ToString("f2"); //"0.01";// order.OrderTotal.ToString(".00");

                        aliorder.customs_place = "tianjin";
                        aliorder.merchant_customs_name = user.copName;
                        aliorder.is_split = "F";
                        aliorder.buyer_name = order.BuyerName; //"王江";// order.BuyerName;
                        aliorder.buyer_id_no = order.BuyerIdNumber; //"360403197708222712";// order.BuyerIdNumber;

                        //alipay_reponse = _IAlipayRepository.alipay_update(aliorder, "ujsidc9esjszyov0fc0trsveq733ttvd");
                        var a = _IAlipayRepository.alipay_get(aliorder, "ujsidc9esjszyov0fc0trsveq733ttvd");
                    }
                    else
                    {
                        message.MessageCode = "2";
                        message.ErrorMsg = "没有对应的报关通道";
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                var modelstate = BadRequest(ModelState);
                string returestr = "";
                foreach (var item in modelstate.ModelState.Values)
                {
                    returestr += item.Errors != null ? item.Errors[0].ErrorMessage + "\r\n" : "";
                }
                message.MessageCode = "2";
                message.ErrorMsg = returestr;
            }
            return Json(message);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class custompayController_wx
    {

    }
    /// <summary>
    /// 
    /// </summary>
    public class custompay_zongshuController
    {

    }
}
