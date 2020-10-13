using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using api_ecmall.Domain.Abstract;
using api_ecmall.Domain.Entities.Orders;
using Newtonsoft.Json;
using api_ecmall.Domain.Entities;
using Microsoft.Extensions.Options;

namespace api_ecmall.WebUI.Areas.Orders.Controllers
{
    ///// <summary>
    ///// 订单接收API
    ///// </summary>
    ////[Authorize]
    //[Route("api/order/ReceiveOrder")]
    //public class ReceiveOrderController : ApiController
    //{
    //    //ILog _log = log4net.LogManager.GetLogger(typeof(order_receiveController));
    //    private IEcmOrderRepository _iEcmOrder;
    //    private IProductRepository _iProduct;
    //    private IRabbitMQHelper _RabbitMQHelper;
    //    private ILog4netHelper _logger;
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="iEcmOrder"></param>
    //    /// <param name="iProduct"></param>
    //    /// <param name="RabbitMQHelper"></param>
    //    /// <param name="logger"></param>
    //    public ReceiveOrderController(IEcmOrderRepository iEcmOrder, IProductRepository iProduct, IRabbitMQHelper RabbitMQHelper,ILog4netHelper logger)
    //    {
    //        _iEcmOrder = iEcmOrder;
    //        _iProduct = iProduct;
    //        _RabbitMQHelper = RabbitMQHelper;
    //        _logger = logger;
    //    }
    //    // GET: api/Order
    //    public IEnumerable<string> Get()
    //    {
    //        try
    //        {
    //            //var order = _iProduct.Products.ToList();
    //            //_logger.WriteLog_Info<ReceiveOrderController>("test", "123456789", null,null);
    //            #region///测试RabbitMQ 多线程
    //            //_log.Info("value1");
    //            //for (int i = 0; i < 10000; i++)
    //            //{
    //            //    _RabbitMQHelper.Publish<Product>(new Product(), "haha"+i.ToString());
    //            //}
    //            //Task.Factory.StartNew(() =>
    //            //{
    //            //    for (int i = 0; i < 100000; i++)
    //            //    {
    //            //        _RabbitMQHelper.Publish<Product>(new Product(), "haha" + i.ToString());
    //            //    }
    //            //});
    //            //Task.Factory.StartNew(() =>
    //            //{
    //            //    for (int i = 200000; i < 300000; i++)
    //            //    {
    //            //        _RabbitMQHelper.Publish<order_status>(new order_status(), "baba" + i.ToString());
    //            //    }
    //            //});
    //            //Task.Factory.StartNew(() =>
    //            //{
    //            //    for (int i = 500000; i < 600000; i++)
    //            //    {
    //            //        _RabbitMQHelper.Publish<ecm_order>(new ecm_order(), "caca" + i.ToString());
    //            //    }
    //            //});
    //            //_RabbitMQHelper.Publish<Product>(new Product(),"haha");
    //            #endregion
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception(ex.TargetSite.ToString());
    //        }
    //        return new string[] { "value1", "value2" };
    //    }
    //    /// <summary>
    //    /// Post提交 ecm_order
    //    /// </summary>
    //    /// <param name="value"></param>
    //    public IHttpActionResult Post([FromBody] Order value)
    //    {
    //        API_Message api_message = new API_Message();
    //        api_message.MessageCode = ((int)m_Code.Success).ToString();
    //        if (ModelState.IsValid)
    //        {
    //            try
    //            {
    //                value.OrderGuid = Guid.NewGuid();
    //                value.api_type = 1;
    //                for (int i = 0; i < value.OrderItems.Count; i++)
    //                {
    //                    value.OrderItems[i].ItemGuid = Guid.NewGuid();
    //                }
    //                _iEcmOrder.Save_Orders(value);
    //                _RabbitMQHelper.Publish<ReceiveOrderController>(JsonConvert.SerializeObject(value));
    //                _logger.WriteLog_Info<ReceiveOrderController>(JsonConvert.SerializeObject(value), null, null,  null);
    //            }
    //            catch(Exception ex)
    //            {
    //                _logger.WriteLog_Error<ReceiveOrderController>(JsonConvert.SerializeObject(value), null, null, ex);
    //            }
    //            //return Json(api_message);
    //        }
    //        else
    //        {
    //            var modelstate = BadRequest(ModelState);
    //            string returestr = "";
    //            foreach (var item in modelstate.ModelState.Values)
    //            {
    //                returestr += item.Errors!=null?item.Errors[0].ErrorMessage+"\r\n":"";
    //            }
    //            api_message.ErrorMsg = returestr;
    //            api_message.MessageCode =((int) m_Code.Faile).ToString();
    //            _logger.WriteLog_Error<ReceiveOrderController>(JsonConvert.SerializeObject(value), null, null, null);
    //            _logger.WriteLog_Error<ReceiveOrderController>(JsonConvert.SerializeObject(api_message), null, null, null);
    //        }
    //        return Json(api_message);
    //    }
    //}
}
