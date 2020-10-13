using api_ecmall.Domain.Abstract;
using api_ecmall.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using api_ecmall.WebUI.Areas.WMS.Models;
using System.Text;
using api_ecmall.WebUI.Settings;

namespace api_ecmall.WebUI.Areas.WMS.Controllers
{
    /// <summary>
    /// WMS-商品分类接口集合
    /// </summary>
    public class WMSSyncCategoryController : ApiController
    {
        private ILog4netHelper _logger;
        private ISetting _ISetting;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="logger"></param>
        public WMSSyncCategoryController(ILog4netHelper logger, ISetting ISetting)
        {
            _logger = logger;
            _ISetting = ISetting;
        }
        /// <summary>
        /// 商品分类同步接口
        /// </summary>
        /// <param name="value"></param>
        [Route("api/Category/SyncCategory")]
        public IHttpActionResult Post([FromBody]CategoryViewModel value)
        {
            API_Message api_message = new API_Message();
            api_message.MessageCode = ((int)m_Code.Success).ToString();
            string restr = "";
            if (ModelState.IsValid)
            {
                try
                {
                    _logger.WriteLog_Info<WMSSyncCategoryController>(JsonConvert.SerializeObject(value), null, "update", null);

                    string update = JsonConvert.SerializeObject(value);
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json");

                    byte[] reByte_Api = client.UploadData(_ISetting.wms.Base_Url + "?parm=Category", "Post", Encoding.UTF8.GetBytes(update));
                    restr = Encoding.UTF8.GetString(reByte_Api);
                    _logger.WriteLog_Info<WMSSyncCategoryController>(restr, null, "return", null);
                    api_message = JsonConvert.DeserializeObject<API_Message>(restr);
                }
                catch (Exception ex)
                {
                    _logger.WriteLog_Error<WMSSyncCategoryController>(JsonConvert.SerializeObject(value), null, null, ex);
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
                _logger.WriteLog_Error<WMSSyncCategoryController>(JsonConvert.SerializeObject(value), null, null, null);
                _logger.WriteLog_Error<WMSSyncCategoryController>(JsonConvert.SerializeObject(api_message), null, null, null);
            }
            return Json(api_message);
        }
        /// <summary>
        /// 商品分类同步接口 oms-ecmall
        /// </summary>
        /// <param name="value"></param>
        [Route("api/Category/Category")]
        public IHttpActionResult Post_Ecmall([FromBody]CategoryViewModel value)
        {
            API_Message api_message = new API_Message();
            api_message.MessageCode = ((int)m_Code.Success).ToString();
            string restr = "";
            if (ModelState.IsValid)
            {
                try
                {
                    _logger.WriteLog_Info<WMSSyncCategoryController>(JsonConvert.SerializeObject(value), null, "ecmall", null);

                    string update = JsonConvert.SerializeObject(value);
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json");

                    byte[] reByte_Api = client.UploadData(_ISetting.ecmall.Base_Url + "/appserver/index.php?m=Api&c=Goods&a=addCategory", "Post", Encoding.UTF8.GetBytes(update));
                    restr = Encoding.UTF8.GetString(reByte_Api);
                    _logger.WriteLog_Info<WMSSyncCategoryController>(restr, null, "ecmall-return", null);
                    api_message = JsonConvert.DeserializeObject<API_Message>(restr);
                }
                catch (Exception ex)
                {
                    _logger.WriteLog_Error<WMSSyncCategoryController>(JsonConvert.SerializeObject(value), null, "ecmall", ex);
                    restr = ex.Message.ToString();
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
                _logger.WriteLog_Error<WMSSyncCategoryController>(JsonConvert.SerializeObject(value), null, "ecmall", null);
                _logger.WriteLog_Error<WMSSyncCategoryController>(JsonConvert.SerializeObject(api_message), null, "ecmall", null);
            }
            return Json(api_message);
        }
    }
}
