using api_ecmall.Domain.Abstract;
using api_ecmall.Domain.Entities;
using api_ecmall.WebUI.Areas.WMS.Models;
using api_ecmall.WebUI.Settings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace api_ecmall.WebUI.Areas.WMS.Controllers
{
    /// <summary>
    /// WMS-供应商(委托人)接口集合
    /// </summary>
    public class WMSSyncVendorsController : ApiController
    {
        private ILog4netHelper _logger;
        private ISetting _ISetting;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="logger"></param>
        public WMSSyncVendorsController(ILog4netHelper logger, ISetting ISetting)
        {
            _logger = logger;
            _ISetting = ISetting;
        }
        /// <summary>
        /// 供应商(委托人)同步接口
        /// </summary>
        /// <param name="value"></param>
        [Route("api/Vendors/SyncVendors")]
        public IHttpActionResult Post([FromBody]VendorViewModel value)
        {
            API_Message api_message = new API_Message();
            api_message.MessageCode = ((int)m_Code.Success).ToString();
            string restr = "";
            if (ModelState.IsValid)
            {
                try
                {
                    _logger.WriteLog_Info<WMSSyncVendorsController>(JsonConvert.SerializeObject(value), null, "update", null);

                    string update = JsonConvert.SerializeObject(value);
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json");

                    byte[] reByte_Api = client.UploadData(_ISetting.wms.Base_Url + "?parm=Vendor", "Post", Encoding.UTF8.GetBytes(update));
                    restr = Encoding.UTF8.GetString(reByte_Api);
                    _logger.WriteLog_Info<WMSSyncVendorsController>(restr, null, "return", null);
                    api_message = JsonConvert.DeserializeObject<API_Message>(restr);
                }
                catch (Exception ex)
                {
                    _logger.WriteLog_Error<WMSSyncVendorsController>(JsonConvert.SerializeObject(value), null, null, ex);
                    api_message.ErrorMsg = restr+ex.Message.ToString();
                    api_message.MessageCode = ((int)m_Code.Faile).ToString();
                    _logger.WriteLog_Error<WMSSyncVendorsController>(JsonConvert.SerializeObject(api_message), null, null, null);
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
                _logger.WriteLog_Error<WMSSyncVendorsController>(JsonConvert.SerializeObject(value), null, null, null);
                _logger.WriteLog_Error<WMSSyncVendorsController>(JsonConvert.SerializeObject(api_message), null, null, null);
            }
            return Json(api_message);
        }
    }
}
