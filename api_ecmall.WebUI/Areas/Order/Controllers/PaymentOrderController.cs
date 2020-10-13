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

namespace api_ecmall.WebUI.Areas.Orders.Controllers
{
    ///// <summary>
    ///// 支付报关
    ///// </summary>
    //[Route("api/order/PaymentOrder")]
    //public class PaymentOrderController : ApiController
    //{
    //    private IRabbitMQHelper _IRabbitMQHelper;
    //    private IEcmOrderRepository _iEcmOrder;
    //    private ILog4netHelper _logger;
    //    private IUserRepository _IUserRepository;
    //    private IPayOrderRepository _IPayOrderRepository;
    //    /// <summary>
    //    /// 构造函数
    //    /// </summary>
    //    /// <param name="IRabbitMQHelper"></param>
    //    /// <param name="iEcmOrder"></param>
    //    /// <param name="logger"></param>
    //    /// <param name="IUserRepository"></param>
    //    /// <param name="IPayOrderRepository"></param>
    //    public PaymentOrderController(IRabbitMQHelper IRabbitMQHelper, IEcmOrderRepository iEcmOrder, ILog4netHelper logger, IUserRepository IUserRepository, IPayOrderRepository IPayOrderRepository)
    //    {
    //        _IRabbitMQHelper = IRabbitMQHelper;
    //        _iEcmOrder = iEcmOrder;
    //        _logger = logger;
    //        _IUserRepository = IUserRepository;
    //        _IPayOrderRepository = IPayOrderRepository;
    //    }
    //    /// <summary>
    //    /// 支付报关提交订单
    //    /// </summary>
    //    /// <param name="value"></param>
    //    /// <returns></returns>
    //    public IHttpActionResult Post([FromBody]PayOrder value)
    //    {
    //        string UserName = User.Identity.Name;
    //        PayOrder_Re response = new PayOrder_Re();
    //        PayOrderViewModel viewmodel = new PayOrderViewModel();
    //        try
    //        {
    //            if (ModelState.IsValid)
    //            {
    //                if (!string.IsNullOrEmpty(UserName))
    //                {
    //                    var userinfo = _IUserRepository.UserInfos.Where(t => t.UserName == UserName).FirstOrDefault();
    //                    if (userinfo == null)
    //                    {
    //                        response.success = "fail";
    //                        response.code = PayCode.fail;
    //                        response.msg = "未查询到用户信息";
    //                    }
    //                    else
    //                    {
    //                        viewmodel.payorder = value;
    //                        viewmodel.userinfo = userinfo;
    //                        _IRabbitMQHelper.Publish<PaymentOrderController>(JsonConvert.SerializeObject(viewmodel));
    //                        _IPayOrderRepository.Save_PayOrder(value);
    //                        _logger.WriteLog_Info<PaymentOrderController>(JsonConvert.SerializeObject(viewmodel), null, null, null);
    //                    }
    //                }
    //                else
    //                {
    //                    _logger.WriteLog_Waring<PaymentOrderController>(JsonConvert.SerializeObject(viewmodel), null, null, null);
    //                }
    //            }
    //            else
    //            {
    //                _logger.WriteLog_Error<PaymentOrderController>(JsonConvert.SerializeObject(viewmodel), null, null, null);
    //            }
    //        }
    //        catch(Exception ex)
    //        {
    //            _logger.WriteLog_Error<PaymentOrderController>(JsonConvert.SerializeObject(viewmodel), null, null, ex);
    //        }
    //        return Json(response);
    //    }
    //}
}
