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
    /// 
    /// </summary>
    [Authorize]
    public class PriceController : ApiController
    {
        private ILog4netHelper _ilog4netHelper;
        private ISetting _ISetting;
        private IUserRepository _iUserRepository;
        private IRabbitMQHelper _IRabbitMQHelper;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="IRabbitMQHelper"></param>
        /// <param name="ilog4netHelper"></param>
        /// <param name="ISetting"></param>
        /// <param name="iUserRepository"></param>
        public PriceController(IRabbitMQHelper IRabbitMQHelper, ILog4netHelper ilog4netHelper, ISetting ISetting, IUserRepository iUserRepository)
        {
            _ilog4netHelper = ilog4netHelper;
            _ISetting = ISetting;
            _iUserRepository = iUserRepository;
            _IRabbitMQHelper = IRabbitMQHelper;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Route("api/Product/AsaUpdatePriceList")]
        [HttpPost]
        public HttpResponseMessage AsaUpdatePriceList(PriceViewModel value)
        {
            ApiJsonResult<List<PriceModel>> message = new ApiJsonResult<List<PriceModel>>();
            PriceViewModel model = new PriceViewModel();
            model.ClientGuid = value.ClientGuid;
            model.ClientName = value.ClientName;
            message.data = new List<PriceModel>();
            string restr = "";
            if (ModelState.IsValid)
            {
                try
                {
                    _ilog4netHelper.WriteLog_Info<Asa修改价格>(JsonConvert.SerializeObject(value), null, "请求", value?.ClientGuid, null, null);
                    message.success = true;
                    message.msg = "api接收成功";
                    foreach (var item in value.PriceListCollection)
                    {
                        try
                        {
                            if(item.Price==0)
                            {
                                continue;
                            }
                            model.PriceListCollection = new List<PriceModel>() { item};
                            _IRabbitMQHelper.Publish<Asa修改价格>(JsonConvert.SerializeObject(model));
                            item.IsAvailable = true;
                            message.data.Add(item);
                        }
                        catch(Exception ex)
                        {
                            item.IsAvailable = false;
                            _ilog4netHelper.WriteLog_Error<Asa修改价格>(JsonConvert.SerializeObject(item), null, "2", value?.ClientGuid, null, ex);                            
                            message.data.Add(item);
                        }
                    }
                    _ilog4netHelper.WriteLog_Info<Asa修改价格>(JsonConvert.SerializeObject(message), null, "return", null);
                }
                catch (Exception ex)
                {
                    _ilog4netHelper.WriteLog_Error<Asa修改价格>(JsonConvert.SerializeObject(value), null, "2", value?.ClientGuid, null, ex);
                    message.success = false;
                    message.msg = "查询erp地址连接错误";
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
                _ilog4netHelper.WriteLog_Error<Asa修改价格>(JsonConvert.SerializeObject(value), null, "3", value?.ClientGuid, null, null);
                _ilog4netHelper.WriteLog_Error<Asa修改价格>(JsonConvert.SerializeObject(message), "4", null, value?.ClientGuid, null, null);
            }


            return new HttpResponseMessage { Content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8) };
        }
        /// <summary>
        /// ERP修改价格
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Route("api/product/pricelist")]
        public HttpResponseMessage pricelist(PriceViewModel value)
        {
            ApiJsonResult<List<PriceModel>> message = new ApiJsonResult<List<PriceModel>>();
            PriceViewModel model = new PriceViewModel();
            model.ClientGuid = value.ClientGuid;
            model.ClientName = value.ClientName;
            message.data = new List<PriceModel>();
            string restr = "";
            if (ModelState.IsValid)
            {
                try
                {
                    _ilog4netHelper.WriteLog_Info<ERP修改价格>(JsonConvert.SerializeObject(value), null, "请求", value?.ClientGuid, null, null);
                    message.success = true;
                    message.msg = "api接收成功";
                    foreach (var item in value.PriceListCollection)
                    {
                        try
                        {
                            if (item.Price == 0)
                            {
                                continue;
                            }
                            model.PriceListCollection = new List<PriceModel>() { item };
                            _IRabbitMQHelper.Publish<ERP修改价格>(JsonConvert.SerializeObject(model));
                            item.IsAvailable = true;
                            message.data.Add(item);
                        }
                        catch (Exception ex)
                        {
                            item.IsAvailable = false;
                            _ilog4netHelper.WriteLog_Error<ERP修改价格>(JsonConvert.SerializeObject(item), null, "2", value?.ClientGuid, null, ex);
                            message.data.Add(item);
                        }
                    }
                    _ilog4netHelper.WriteLog_Info<ERP修改价格>(JsonConvert.SerializeObject(message), null, "return", null);
                }
                catch (Exception ex)
                {
                    _ilog4netHelper.WriteLog_Error<ERP修改价格>(JsonConvert.SerializeObject(value), null, "2", value?.ClientGuid, null, ex);
                    message.success = false;
                    message.msg = "查询erp地址连接错误";
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
                _ilog4netHelper.WriteLog_Error<ERP修改价格>(JsonConvert.SerializeObject(value), null, "3", value?.ClientGuid, null, null);
                _ilog4netHelper.WriteLog_Error<ERP修改价格>(JsonConvert.SerializeObject(message), "4", null, value?.ClientGuid, null, null);
            }


            return new HttpResponseMessage { Content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8) };
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class Asa修改价格
    {

    }
    /// <summary>
    /// ERP修改价格
    /// </summary>
    public class ERP修改价格
    {

    }
}