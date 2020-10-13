using api_ecmall.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using api_ecmall.WebUI.Areas.WMS.Models;
using api_ecmall.Domain.Entities;
using Newtonsoft.Json;
using api_ecmall.WebUI.Settings;
using System.Text;
using Newtonsoft.Json.Converters;

namespace api_ecmall.WebUI.Areas.WMS.Controllers
{
    /// <summary>
    /// WMS-出入库通知单接口集合
    /// </summary>
    public class WMSStockNoticeController : ApiController
    {
        private ILog4netHelper _logger;
        private IEcmOrderRepository _iEcmOrder;
        private ISetting _ISetting;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="iEcmOrder"></param>
        public WMSStockNoticeController(ILog4netHelper logger, IEcmOrderRepository iEcmOrder, ISetting ISetting)
        {
            _logger = logger;
            _iEcmOrder = iEcmOrder;
            _ISetting = ISetting;
        }
        /// <summary>
        /// 同步出入库通知单 请求来源OMS  目的地 WMS
        /// </summary>
        /// <param name="value"></param>
        [Route("api/StockNotice/ReviceStockNotice")]
        public HttpResponseMessage Post([FromBody]StockNoticeViewModel value)
        {
            ApiJsonResult<object> message = new ApiJsonResult<object>();
            API_Message api_message = new API_Message();
            api_message.MessageCode = ((int)m_Code.Success).ToString();
            string restr = "";
            if (ModelState.IsValid)
            {
                try
                {
                    _logger.WriteLog_Info<WMSStockNoticeController>(JsonConvert.SerializeObject(value), null, "1", null);
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json;charset=utf8");
                    IsoDateTimeConverter iso = new IsoDateTimeConverter();
                    iso.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
                    string update = JsonConvert.SerializeObject(value, iso);
                    byte[] reByte_Api = client.UploadData(_ISetting.wms.Base_Url + "?parm=StockNotice", "Post", Encoding.UTF8.GetBytes(update));
                    restr = Encoding.UTF8.GetString(reByte_Api);
                    _logger.WriteLog_Info<WMSStockNoticeController>(restr, null, "return", null);
                    //message = JsonConvert.DeserializeObject<ApiJsonResult<object>>(restr);
                    //if (message.success)
                    //{
                    //    //api_message.
                    //    api_message.ErrorMsg = restr;
                    //}
                    //else
                    //{
                    //    api_message.ErrorMsg = restr;
                    //    api_message.MessageCode = "2";
                    //}

                }
                catch (Exception ex)
                {
                    _logger.WriteLog_Error<WMSStockNoticeController>(JsonConvert.SerializeObject(value), null, "2", ex);
                    //api_message.MessageCode = ((int)m_Code.Faile).ToString();
                    message.success = false;
                    message.msg = "wms连接错误";
                    restr = JsonConvert.SerializeObject(message);
                }
            }
            else
            {
                var modelstate = BadRequest(ModelState);
                string returestr = "";
                foreach (var item in modelstate.ModelState.Keys)
                {
                    returestr += "Key:"+item+"value:"+(modelstate.ModelState?[item].Errors!=null?(modelstate.ModelState?[item].Errors?[0].ErrorMessage+"   "+modelstate.ModelState?[item].Errors?[0].Exception?.Message):"");// item.Errors != null ? item.Errors[0].ErrorMessage + "\r\n" : "";
                }
                //api_message.ErrorMsg = returestr;
                //api_message.MessageCode = ((int)m_Code.Faile).ToString();
                message.msg = returestr;
                message.success = false;
                restr = JsonConvert.SerializeObject(message);
                _logger.WriteLog_Error<WMSStockNoticeController>(JsonConvert.SerializeObject(value), null, "3", null);
                _logger.WriteLog_Error<WMSStockNoticeController>(JsonConvert.SerializeObject(message), "4", null, null);
            }
            return new HttpResponseMessage {Content=new StringContent(restr,Encoding.UTF8) };
        }
    }
}
