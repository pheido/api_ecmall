using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using api_ecmall.Domain.Entities._110Model;
using Newtonsoft.Json;
using System.Text;
using api_ecmall.Domain.Abstract;
using api_ecmall.WebUI.Settings;
using api_ecmall.Domain.Entities;

namespace api_ecmall.WebUI.Areas.Customs.Controllers
{
    /// <summary>
    /// 商品档案备案  
    /// </summary>
    public class customgoodsController : ApiController
    {
        private ISetting _ISetting;
        private ILog4netHelper _logger;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ISetting"></param>
        /// <param name="logger"></param>
        public customgoodsController(ISetting ISetting, ILog4netHelper logger)
        {
            _ISetting = ISetting;
            _logger = logger;
        }

        /// <summary>
        /// 商品档案备案  接受OMS请求
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Route("api/customs/goods")]
        public IHttpActionResult Post([FromBody]GoodsRegDocument value)
        {
            API_Message message = new API_Message();
            message.MessageCode = "1";
            string reStr = "";
            _logger.WriteLog_Info<customgoodsController>(JsonConvert.SerializeObject(value), null, null, null);
            if (ModelState.IsValid)
            {
                try
                {
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json");
                    string body = JsonConvert.SerializeObject(value);
                    byte[] reByte = client.UploadData(_ISetting.custom.Base_Url + "/api/Custom/goods", Encoding.UTF8.GetBytes(body));
                    reStr = Encoding.UTF8.GetString(reByte);
                    _logger.WriteLog_Info<customgoodsController>(reStr, null, null, null);
                }
                catch(Exception ex)
                {
                    message.MessageCode = "2";
                    _logger.WriteLog_Error<customgoodsController>(reStr, null, null, ex);
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
                _logger.WriteLog_Error<customgoodsController>(JsonConvert.SerializeObject(message), null, null, null);
            }
            return Json(message);
        }
    }
}
