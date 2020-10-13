using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using api_ecmall.Domain.Entities.Vendor;
using api_ecmall.Domain.Entities;
using Newtonsoft.Json;
using System.Text;
using api_ecmall.Domain.Abstract;
using api_ecmall.WebUI.Settings;

namespace api_ecmall.WebUI.Areas.Vendor.Controllers
{
    /// <summary>
    /// 店铺接口
    /// </summary>
    public class VendorsController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        private ILog4netHelper _ILog4netHelper;
        private ISetting _ISetting;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ILog4netHelper"></param>
        /// <param name="ISetting"></param>
        public VendorsController(ILog4netHelper ILog4netHelper,ISetting ISetting)
        {
            _ILog4netHelper=ILog4netHelper;
            _ISetting = ISetting;
        }
        /// <summary>
        /// 更新店铺接口
        /// </summary>
        /// <param name="value"></param>
        [Route("api/Vendor/UpdateVendor")]
        public IHttpActionResult UpdateVendor([FromBody]VendorModel value)
        {
            API_Message api_message = new API_Message();
            api_message.Method = "UpdateVendor";
            if (ModelState.IsValid)
            {
                try
                {
                    _ILog4netHelper.WriteLog_Info<UpdateVendor>(JsonConvert.SerializeObject(value), null, null, null);
                    string post = JsonConvert.SerializeObject(value);
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json");
                    byte[] reByte = client.UploadData(_ISetting.oms.Base_Url + "/api/vendor/updatevendor", Encoding.UTF8.GetBytes(post));
                    string reStr = Encoding.UTF8.GetString(reByte);
                    _ILog4netHelper.WriteLog_Info<UpdateVendor>(reStr, null, null, null);
                    api_message = JsonConvert.DeserializeObject<API_Message>(reStr);
                }
                catch (Exception ex)
                {
                    api_message.MessageCode = "2";
                    api_message.ErrorMsg = ex.InnerException.Message.ToString();
                    _ILog4netHelper.WriteLog_Error<UpdateVendor>(JsonConvert.SerializeObject(api_message), null, null, null);
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
                api_message.MessageCode = "2";
                api_message.ErrorMsg = returestr;
                _ILog4netHelper.WriteLog_Waring<UpdateVendor>(JsonConvert.SerializeObject(api_message), null, null, null);
            }
            return Json(api_message);
        }
        /// <summary>
        /// 新增店铺接口
        /// </summary>
        /// <param name="value"></param>
        [Route("api/Vendor/ReceiveVendor")]
        public IHttpActionResult ReceiveVendor([FromBody]VendorModel value)
        {
            API_Message api_message = new API_Message();
            api_message.Method = "ReceiveVendor";
            if (ModelState.IsValid)
            {
                try
                {
                    _ILog4netHelper.WriteLog_Info<ReceiveVendor>(JsonConvert.SerializeObject(value), null, null, null);
                    string post = JsonConvert.SerializeObject(value);
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json");
                    byte[] reByte = client.UploadData(_ISetting.oms.Base_Url + "/api/vendor/receivevendor", Encoding.UTF8.GetBytes(post));
                    string reStr = Encoding.UTF8.GetString(reByte);
                    _ILog4netHelper.WriteLog_Info<ReceiveVendor>(reStr, null, null, null);
                    api_message = JsonConvert.DeserializeObject<API_Message>(reStr);
                }
                catch (Exception ex)
                {
                    api_message.MessageCode = "2";
                    api_message.ErrorMsg = ex.InnerException.ToString();
                    _ILog4netHelper.WriteLog_Error<ReceiveVendor>(JsonConvert.SerializeObject(api_message), null, null, null);
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
                api_message.MessageCode = "2";
                api_message.ErrorMsg = returestr;
                _ILog4netHelper.WriteLog_Waring<ReceiveVendor>(JsonConvert.SerializeObject(api_message), null, null, null);
            }
            return Json(api_message);
        }




        /// <summary>
        /// 店铺绑定接口
        /// </summary>
        /// <param name="value"></param>
        [Route("api/Vendor/BoundMsg")]
        public IHttpActionResult BoundMsg([FromBody]VendorBoundMsg value)
        {
            API_Message api_message = new API_Message();
            api_message.Method = "BoundMsg";
            if (ModelState.IsValid)
            {
                try
                {
                    _ILog4netHelper.WriteLog_Info<BoundMsg>(JsonConvert.SerializeObject(value), null, null, null);
                    string post = JsonConvert.SerializeObject(value);
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json");
                    byte[] reByte = client.UploadData(_ISetting.ecmall.Base_Url + "/appserver/index.php?m=api&c=store&a=editStoreState", Encoding.UTF8.GetBytes(post));//http://192.0.1.188:15536/api/vendor/receivevendor
                    string reStr = Encoding.UTF8.GetString(reByte);
                    _ILog4netHelper.WriteLog_Info<BoundMsg>(reStr, null, null, null);
                    api_message = JsonConvert.DeserializeObject<API_Message>(reStr);
                }
                catch (Exception ex)
                {
                    api_message.MessageCode = "2";
                    api_message.ErrorMsg = ex.InnerException.ToString();
                    _ILog4netHelper.WriteLog_Error<BoundMsg>(JsonConvert.SerializeObject(api_message), null, null, null);
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
                api_message.MessageCode = "2";
                api_message.ErrorMsg = returestr;
                _ILog4netHelper.WriteLog_Waring<BoundMsg>(JsonConvert.SerializeObject(api_message), null, null, null);
            }
            return Json(api_message);
        }
    }
    public class UpdateVendor
    {

    }
    public class ReceiveVendor
    {

    }
    public class BoundMsg
    {

    }
}
