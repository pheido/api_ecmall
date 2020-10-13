using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using api_ecmall.WebUI.Areas.WMS.Models;
using api_ecmall.Domain.Abstract;
using api_ecmall.WebUI.Settings;
using api_ecmall.Domain.Entities;
using Newtonsoft.Json;
using System.Text;

namespace api_ecmall.WebUI.Areas.WMS.Controllers
{
    /// <summary>
    /// WMS-发货人接口集合
    /// </summary>
    public class WMSSyncConsignorsController : ApiController
    {


        private ILog4netHelper _logger;
        private ISetting _ISetting;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="ISetting"></param>
        public WMSSyncConsignorsController(ILog4netHelper logger, ISetting ISetting)
        {
            _logger = logger;
            _ISetting = ISetting;
        }
        /// <summary>
        /// 发货人同步接口
        /// </summary>
        /// <param name="value"></param>
        [Route("api/Consignors/SyncConsignors")]
        public IHttpActionResult Post([FromBody]ConsignorViewModel value)
        {
            API_Message api_message = new API_Message();
            api_message.MessageCode = ((int)m_Code.Success).ToString();
            string restr = "";
            if (ModelState.IsValid)
            {
                try
                {
                    _logger.WriteLog_Info<WMSSyncConsignorsController>(JsonConvert.SerializeObject(value), null, "update", null);

                    string update = JsonConvert.SerializeObject(value);
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json");

                    byte[] reByte_Api = client.UploadData(_ISetting.wms.Base_Url + "?parm=Consignor", "Post", Encoding.UTF8.GetBytes(update));
                    restr = Encoding.UTF8.GetString(reByte_Api);
                    _logger.WriteLog_Info<WMSSyncConsignorsController>(restr, null, "return", null);
                    api_message = JsonConvert.DeserializeObject<API_Message>(restr);
                }
                catch (Exception ex)
                {
                    _logger.WriteLog_Error<WMSSyncConsignorsController>(JsonConvert.SerializeObject(value), null, null, ex);
                    api_message.ErrorMsg = restr;
                    api_message.MessageCode = ((int)m_Code.Faile).ToString();
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
                api_message.ErrorMsg = returestr;
                api_message.MessageCode = ((int)m_Code.Faile).ToString();
                _logger.WriteLog_Error<WMSSyncConsignorsController>(JsonConvert.SerializeObject(value), null, null, null);
                _logger.WriteLog_Error<WMSSyncConsignorsController>(JsonConvert.SerializeObject(api_message), null, null, null);
            }
            _logger.WriteLog_Info<WMSSyncConsignorsController>(JsonConvert.SerializeObject(api_message), null, null, null);
            return Json(api_message);
        }
    }
}
