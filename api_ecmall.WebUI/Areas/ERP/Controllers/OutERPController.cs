using api_ecmall.Domain.Abstract;
using api_ecmall.WebUI.Areas.ERP.Models;
using api_ecmall.WebUI.Areas.WMS.Models;
using api_ecmall.WebUI.Settings;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace api_ecmall.WebUI.Areas.ERP.Controllers
{
    /// <summary>
    /// 主动访问外部ERP接口  下订单/查询订单/查询物流
    /// </summary>
    public class OutERPController : ApiController
    {
        private ILog4netHelper _ilog4netHelper;
        private ISetting _ISetting;
        private IUserRepository _iUserRepository;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ilog4netHelper"></param>
        /// <param name="ISetting"></param>
        /// <param name="iUserRepository"></param>
        public OutERPController(ILog4netHelper ilog4netHelper, ISetting ISetting, IUserRepository iUserRepository)
        {
            _ilog4netHelper = ilog4netHelper;
            _ISetting = ISetting;
            _iUserRepository = iUserRepository;
        }
        /// <summary>
        /// 向第三方erp接口下订单
        /// </summary>
        /// <param name="value">订单实体</param>
        /// <returns>确认消息</returns>
        [Route("api/order/ExternalOrder")]
        [HttpPost]
        public HttpResponseMessage PlanceOrder(OutOrderViewModel value)
        {
            ApiJsonResult<object> message = new ApiJsonResult<object>();
            string restr = "";
            if (ModelState.IsValid)
            {
                try
                {
                    _ilog4netHelper.WriteLog_Info<OMS向第三方ERP下单>(JsonConvert.SerializeObject(value), null, "请求", value?.ClientGuid, null, null);
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json");
                    IsoDateTimeConverter iso = new IsoDateTimeConverter();
                    iso.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
                    string update = JsonConvert.SerializeObject(value, iso);
                    string url = _ISetting.erp.kvs.Where(t => t.k == value.ClientGuid).FirstOrDefault().v;
                    if(string.IsNullOrEmpty(url))
                    {
                        message.success = false;
                        message.code = 200;
                        message.msg = "未查询到指定的供应商erp地址";
                        return new HttpResponseMessage { Content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8) };
                    }
                    byte[] reByte_Api = client.UploadData(url + "/api/order", "Post", Encoding.UTF8.GetBytes(update));
                    restr = Encoding.UTF8.GetString(reByte_Api);
                    _ilog4netHelper.WriteLog_Info<OMS向第三方ERP下单>(restr, null, "return", null);
                }
                catch (Exception ex)
                {
                    _ilog4netHelper.WriteLog_Error<OMS向第三方ERP下单>(JsonConvert.SerializeObject(value), null, "2", value?.ClientGuid, null, ex);
                    //api_message.MessageCode = ((int)m_Code.Faile).ToString();
                    message.success = false;
                    message.msg = "查询到指定的供应商erp地址连接错误";
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
                _ilog4netHelper.WriteLog_Error<OMS向第三方ERP下单>(JsonConvert.SerializeObject(value), null, "3", value?.ClientGuid, null, null);
                _ilog4netHelper.WriteLog_Error<OMS向第三方ERP下单>(JsonConvert.SerializeObject(message), "4", null, value?.ClientGuid, null, null);
            }
            return new HttpResponseMessage { Content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8) };
        }
        /// <summary>
        /// 
        /// </summary>
        public class OMS向第三方ERP下单
        {

        }
    }
}
