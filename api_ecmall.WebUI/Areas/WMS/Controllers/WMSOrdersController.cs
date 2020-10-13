using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using api_ecmall.WebUI.Areas.WMS.Models;
using api_ecmall.Domain.Entities;
using api_ecmall.Domain.Abstract;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace api_ecmall.WebUI.Areas.WMS.Controllers
{
    /// <summary>
    /// WMS
    /// </summary>
    public class WMSOrdersController : ApiController
    {
        private ILog4netHelper _logger;
        private IEcmOrderRepository _iEcmOrder;
        private IRabbitMQHelper _IRabbitMQHelper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="iEcmOrder"></param>
        /// <param name="IRabbitMQHelper"></param>
        public WMSOrdersController(ILog4netHelper logger, IEcmOrderRepository iEcmOrder,IRabbitMQHelper IRabbitMQHelper)
        {
            _logger = logger;
            _iEcmOrder = iEcmOrder;
            _IRabbitMQHelper = IRabbitMQHelper;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        [Route("api/Order/WMSOrder",Name ="WMSOrder")]
        public void Post([FromBody]OrderViewModel order)
        {
            API_Message api_message = new API_Message();
            api_message.MessageCode = ((int)m_Code.Success).ToString();

            IsoDateTimeConverter iso = new IsoDateTimeConverter();
            iso.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

            if (ModelState.IsValid)
            {
                try
                {
                    order.OrderGuid = Guid.NewGuid();
                    order.api_type = 5;
                    for (int i = 0; i < order.OrderItems.Count; i++)
                    {
                        order.OrderItems[i].ItemGuid = Guid.NewGuid();
                    }
                    _iEcmOrder.Save_Orders(order);
                    _IRabbitMQHelper.Publish<OrdersController_WMS>(JsonConvert.SerializeObject(order,iso));
                    _logger.WriteLog_Info<OrdersController_WMS>(JsonConvert.SerializeObject(order), null, null, null);
                }
                catch (Exception ex)
                {
                    _logger.WriteLog_Error<OrdersController_WMS>(JsonConvert.SerializeObject(order), null, null, ex);
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
                _logger.WriteLog_Error<OrdersController_WMS>(JsonConvert.SerializeObject(order), null, null, null);
                _logger.WriteLog_Error<OrdersController_WMS>(JsonConvert.SerializeObject(api_message), null, null, null);
            }
        }

        //// PUT: api/Orders/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Orders/5
        //public void Delete(int id)
        //{
        //}
    }
    public class OrdersController_WMS
    {

    }
}
