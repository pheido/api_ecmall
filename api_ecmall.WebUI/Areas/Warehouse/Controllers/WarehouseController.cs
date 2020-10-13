using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using api_ecmall.Domain.Entities.WareHouse;
using api_ecmall.Domain.Abstract;
using api_ecmall.WebUI.Areas.Warehouse.Models;
using api_ecmall.Domain.Entities;
using Newtonsoft.Json;
using System.Text;
using api_ecmall.WebUI.Settings;

namespace api_ecmall.WebUI.Areas.Warehouse.Controllers
{
    /// <summary>
    /// 仓库信息接口
    /// </summary>
    public class WarehouseController : ApiController
    {
        private ILog4netHelper _ILog4netHelper;
        private IWarehouseRepository _IWarehouseRepository;
        private ISetting _ISetting;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ILog4netHelper"></param>
        /// <param name="IWarehouseRepository"></param>
        /// <param name="ISetting"></param>
        public WarehouseController(ILog4netHelper ILog4netHelper,IWarehouseRepository IWarehouseRepository,ISetting ISetting)
        {
            _ILog4netHelper = ILog4netHelper;
            _IWarehouseRepository = IWarehouseRepository;
            _ISetting = ISetting;
        }
        /// <summary>
        /// 新增仓库信息接口
        /// </summary>
        /// <param name="value"></param>
        [Route("api/Warehouse/ReceiveWarehouse")]
        public IHttpActionResult Post([FromBody]WarehouseViewModel value)
        {
            API_Message api_message = new API_Message();
            api_message.Method = "ReceiveWarehouse";
            _ILog4netHelper.WriteLog_Info<WarehouseController>(JsonConvert.SerializeObject(value), null, null, value.ClientGuid.ToString(), value.ClientName, null);
            if (ModelState.IsValid)
            {
                try
                {
                    _ILog4netHelper.WriteLog_Info<WarehouseController>(JsonConvert.SerializeObject(value), null, null,value.ClientGuid.ToString(),value.ClientName, null);
                    string post = JsonConvert.SerializeObject(value);
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json");
                    byte[] reByte = client.UploadData(_ISetting.ecmall.Base_Url+"/appserver/index.php?m=api&c=stock&a=addStock", Encoding.UTF8.GetBytes(post));//http://192.0.1.188:15536/api/vendor/receivevendor
                    string reStr = Encoding.UTF8.GetString(reByte);

                    value.Warehouse.ClientGuid = value.ClientGuid;
                    value.Warehouse.ClientName = value.ClientName;
                    _IWarehouseRepository.SaveWarehouse(value.Warehouse);
                    _ILog4netHelper.WriteLog_Info<WarehouseController>(reStr, null, null, null);
                    api_message = JsonConvert.DeserializeObject<API_Message>(reStr);
                }
                catch (Exception ex)
                {
                    api_message.MessageCode = "2";
                    api_message.ErrorMsg = ex?.Message==null?ex?.TargetSite.ToString():ex?.Message;
                    _ILog4netHelper.WriteLog_Error<WarehouseController>(JsonConvert.SerializeObject(api_message), null, null, value.ClientGuid.ToString(), value.ClientName, ex);
                }
            }
            else
            {
                var modelstate = BadRequest(ModelState);
                string returestr = "";
                foreach (var item in modelstate.ModelState.Values)
                {
                    //item.
                    //item.Value.Value.RawValue.ToString()
                    returestr += item.Errors != null ? item.Errors[0].ErrorMessage + "\r\n" : "";
                }
                foreach (var item in modelstate.ModelState.Keys)
                {
                    //item.
                    //item.Value.Value.RawValue.ToString()
                    returestr += item != null ? item.ToString() + "\r\n" : "";
                }
                api_message.MessageCode = "2";
                api_message.ErrorMsg = returestr;
                _ILog4netHelper.WriteLog_Waring<WarehouseController>(JsonConvert.SerializeObject(api_message), null, null, value.ClientGuid.ToString(), value.ClientName, null);
            }
            return Json(api_message);
        }
    }
}
