using api_ecmall.Domain.Abstract;
using api_ecmall.WebUI.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using api_ecmall.WebUI.Areas.WMS.Models;
using Newtonsoft.Json;
using api_ecmall.Domain.Entities;
using System.Text;
using Newtonsoft.Json.Converters;

namespace api_ecmall.WebUI.Areas.WMS.Controllers
{
    /// <summary>
    /// WMS--OMS出入库库存更新
    /// </summary>
    public class WMSSyncStockController : ApiController
    {
        private ILog4netHelper _logger;
        private ISetting _ISetting;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="ISetting"></param>
        public WMSSyncStockController(ILog4netHelper logger, ISetting ISetting)
        {
            _logger = logger;
            _ISetting = ISetting;
        }
        /// <summary>
        /// WMS--OMS出入库库存更新
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        [Route("api/stock/UpdateStockInOutStatus")]
        public HttpResponseMessage Post([FromBody]WMSStockViewModel value)
        {
            ApiJsonResult<object> message = new ApiJsonResult<object>();
            string restr = "";
            if (ModelState.IsValid)
            {
                try
                {
                    _logger.WriteLog_Info<WMSSyncStockController>(JsonConvert.SerializeObject(value), null, "1", null);
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json;charset=utf8");
                    IsoDateTimeConverter iso = new IsoDateTimeConverter();
                    iso.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
                    string update = JsonConvert.SerializeObject(value, iso);
                    byte[] reByte_Api = client.UploadData(_ISetting.oms.Base_Url + "/api/stock/UpdateStockInOutStatus", "Post", Encoding.UTF8.GetBytes(update));
                    restr = Encoding.UTF8.GetString(reByte_Api);
                    _logger.WriteLog_Info<WMSSyncStockController>(restr, null, "return", null);
                }
                catch (Exception ex)
                {
                    _logger.WriteLog_Error<WMSSyncStockController>(JsonConvert.SerializeObject(value), null, "2", ex);
                    message.success = false;
                    message.msg = "oms连接错误";
                    restr = JsonConvert.SerializeObject(message);
                }
            }
            else
            {
                var modelstate = BadRequest(ModelState);
                string returestr = "";
                foreach (var item in modelstate.ModelState.Keys)
                {
                    returestr += "Key:" + item + "value:" + (modelstate.ModelState?[item].Errors != null ? (modelstate.ModelState?[item].Errors?[0].ErrorMessage + "   " + modelstate.ModelState?[item].Errors?[0].Exception?.Message) : "");// item.Errors != null ? item.Errors[0].ErrorMessage + "\r\n" : "";
                }
                message.msg = returestr;
                message.success = false;
                restr = JsonConvert.SerializeObject(message);
                _logger.WriteLog_Error<WMSSyncStockController>(JsonConvert.SerializeObject(value), null, "3", null);
                _logger.WriteLog_Error<WMSSyncStockController>(JsonConvert.SerializeObject(message), "4", null, null);
            }
            return new HttpResponseMessage { Content = new StringContent(restr, Encoding.UTF8) };
        }
    }
}
