using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using api_ecmall.Domain.Entities;
using api_ecmall.Domain.Abstract;
using Newtonsoft.Json;

namespace api_ecmall.WebUI.Areas.Orders.Controllers
{
    ///// <summary>
    ///// 订单状态更新API
    ///// </summary>
    ////[Authorize]
    //[Route("api/order/status_update")]
    //public class status_updateController : ApiController
    //{
    //    private IRabbitMQHelper _iRabbitMQHelper;
    //    private ILog4netHelper _ILog4netHelper;
    //    /// <summary>
    //    /// 构造函数
    //    /// </summary>
    //    /// <param name="iRabbitMQHelper"></param>
    //    /// <param name="ILog4netHelper"></param>
    //    public status_updateController(IRabbitMQHelper iRabbitMQHelper, ILog4netHelper ILog4netHelper)
    //    {
    //        _iRabbitMQHelper = iRabbitMQHelper;
    //        _ILog4netHelper = ILog4netHelper;
    //    }
    //    /// <summary>
    //    /// 调用者（OMS）
    //    /// </summary>
    //    /// <param name="value">API_Message</param>
    //    public IHttpActionResult Post([FromBody]order_status value)
    //    {
    //        API_Message message = new API_Message();
    //        try
    //        {
    //            if (ModelState.IsValid)
    //            {
    //                message.MessageCode = ((int)m_Code.Success).ToString();
    //                _iRabbitMQHelper.Publish<status_updateController>(JsonConvert.SerializeObject(value));
    //                _ILog4netHelper.WriteLog_Info<status_updateController>(JsonConvert.SerializeObject(value), null, null, null);
    //            }
    //            else
    //            {
    //                var modelstate = BadRequest(ModelState);
    //                string returestr = "";
    //                foreach (var item in modelstate.ModelState.Values)
    //                {
    //                    returestr += item.Errors != null ? item.Errors[0].ErrorMessage + " \r\n" : "";
    //                }
    //                message.ErrorMsg = returestr;
    //                message.MessageCode = ((int)m_Code.Faile).ToString();// m_Code.Faile.ToString();
    //                _ILog4netHelper.WriteLog_Error<status_updateController>(JsonConvert.SerializeObject(value), null, null, null);
    //                _ILog4netHelper.WriteLog_Error<status_updateController>(JsonConvert.SerializeObject(message), null, null, null);
    //            }
    //        }
    //        catch(Exception ex)
    //        {
    //            _ILog4netHelper.WriteLog_Error<status_updateController>(JsonConvert.SerializeObject(message), null, null, ex);
    //        }
    //        return Json(message);
    //    }
    //}
}
