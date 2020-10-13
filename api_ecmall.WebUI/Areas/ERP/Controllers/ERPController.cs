using System;
using System.Collections.Generic;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using api_ecmall.WebUI.Areas.ERP.Models;
using Newtonsoft.Json;
using System.Text;
using System.Net;
using api_ecmall.Domain.Abstract;
using api_ecmall.WebUI.Settings;
using System.Net.Http;
using api_ecmall.WebUI.Areas.WMS.Models;
using Newtonsoft.Json.Converters;
using api_ecmall.Domain.Entities.Orders;

namespace api_ecmall.WebUI.Areas.ERP.Controllers
{
    /// <summary>
    /// 三方ERP统一接口
    /// </summary>
    [Authorize]
    public class ERPController : ApiController
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
        public ERPController(ILog4netHelper ilog4netHelper, ISetting ISetting, IUserRepository iUserRepository)
        {
            _ilog4netHelper = ilog4netHelper;
            _ISetting = ISetting;
            _iUserRepository = iUserRepository;
        }
        /// <summary>
        /// 包装代码
        /// </summary>
        /// <param name="value">客户端信息</param>
        /// <returns></returns>
        [Route("api/basedata/GetWrap")]
        [HttpPost]
        public IHttpActionResult GetWrap([FromBody]ClientViewModel value)
        {
            List<WrapInfoItemsViewModel> model = new List<WrapInfoItemsViewModel>();
            string post = "";
            if (ModelState.IsValid)
            {
                try
                {
                    post = JsonConvert.SerializeObject(value);
                    _ilog4netHelper.WriteLog_Info<ERP包装代码>(post, null, null, value?.ClientGuid, value?.ClientName, null);
                    string id = User.Identity.GetUserId();
                    if (string.IsNullOrEmpty(id) || _iUserRepository.GetClient(id, value.ClientGuid) == null)
                    {
                        return Json(model);
                    }
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json");
                    byte[] reByte = client.UploadData(_ISetting.oms.Base_Url + "/api/basedata/GetWrap", Encoding.UTF8.GetBytes(post));//http://192.0.1.188:15536/api/vendor/receivevendor
                    string reStr = Encoding.UTF8.GetString(reByte);
                    _ilog4netHelper.WriteLog_Info<ERP包装代码>(post, null, null, value?.ClientGuid, value?.ClientName, null);
                    _ilog4netHelper.WriteLog_Info<ERP包装代码>(reStr, null, null, value?.ClientGuid, value?.ClientName, null);
                    model = JsonConvert.DeserializeObject<List<WrapInfoItemsViewModel>>(reStr);
                }
                catch (Exception ex)
                {
                    _ilog4netHelper.WriteLog_Error<ERP包装代码>(post, null, null, value?.ClientGuid, value?.ClientName, ex);
                }
            }
            else
            {
                //re.code = 0;
                //re.msg = "ERP包装代码数据格式错误";
                //var modelstate = BadRequest(ModelState);
                //string returestr = "";
                //foreach (var item in modelstate.ModelState.Values)
                //{
                //    //item.
                //    //item.Value.Value.RawValue.ToString()
                //    returestr += item.Errors != null ? item.Errors[0].ErrorMessage + item.Errors[0].Exception.Message + "\r\n" : "";
                //}
                //re.success = false;
                //re.data = returestr;
                _ilog4netHelper.WriteLog_Waring<ERP包装代码>(JsonConvert.SerializeObject(post), null, null, value.ClientGuid?.ToString(), value.ClientName, null);
            }
            return Json(model);
        }
        /// <summary>
        /// 
        /// </summary>
        public class ERP包装代码
        {

        }
        /// <summary>
        /// 国家地区代码
        /// </summary>
        /// <param name="value">客户端信息</param>
        /// <returns></returns>
        [Route("api/basedata/GetCountryInfo")]
        [HttpPost]
        public IHttpActionResult GetCountryInfo([FromBody]ClientViewModel value)
        {
            List<CountryInfoItemViewModel> model = new List<CountryInfoItemViewModel>();
            string post = "";
            if (ModelState.IsValid)
            {
                try
                {
                    post = JsonConvert.SerializeObject(value);
                    _ilog4netHelper.WriteLog_Info<ERP国家地区代码>(post, null, null, value?.ClientGuid, value?.ClientName, null);
                    string id = User.Identity.GetUserId();
                    if (string.IsNullOrEmpty(id) || _iUserRepository.GetClient(id, value.ClientGuid) == null)
                    {
                        return Json(model);
                    }
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json");
                    byte[] reByte = client.UploadData(_ISetting.oms.Base_Url + "/api/basedata/GetCountryInfo", Encoding.UTF8.GetBytes(post));//http://192.0.1.188:15536/api/vendor/receivevendor
                    string reStr = Encoding.UTF8.GetString(reByte);
                    _ilog4netHelper.WriteLog_Info<ERP国家地区代码>(post, null, null, value?.ClientGuid, value?.ClientName, null);
                    _ilog4netHelper.WriteLog_Info<ERP国家地区代码>(reStr, null, null, value?.ClientGuid, value?.ClientName, null);
                    model = JsonConvert.DeserializeObject<List<CountryInfoItemViewModel>>(reStr);
                }
                catch (Exception ex)
                {
                    _ilog4netHelper.WriteLog_Error<ERP国家地区代码>(post, null, null, value?.ClientGuid, value?.ClientName, ex);
                }
            }
            else
            {
                //re.code = 0;
                //re.msg = "ERP包装代码数据格式错误";
                //var modelstate = BadRequest(ModelState);
                //string returestr = "";
                //foreach (var item in modelstate.ModelState.Values)
                //{
                //    //item.
                //    //item.Value.Value.RawValue.ToString()
                //    returestr += item.Errors != null ? item.Errors[0].ErrorMessage + item.Errors[0].Exception.Message + "\r\n" : "";
                //}
                //re.success = false;
                //re.data = returestr;
                _ilog4netHelper.WriteLog_Waring<ERP国家地区代码>(JsonConvert.SerializeObject(post), null, null, value?.ClientGuid?.ToString(), value.ClientName, null);
            }
            return Json(model);
        }
        /// <summary>
        /// 
        /// </summary>
        public class ERP国家地区代码
        {

        }
        /// <summary>
        /// 商品分类   api/category/getcategory
        /// </summary>
        /// <param name="value">客户端信息</param>
        /// <returns></returns>
        [Route("api/category/getcategory")]
        [HttpPost]
        public IHttpActionResult GetCategory([FromBody]ClientViewModel value)
        {
            List<CategoryItemViewModel> model = new List<CategoryItemViewModel>();
            string post = "";
            if (ModelState.IsValid)
            {
                try
                {
                    post = JsonConvert.SerializeObject(value);
                    _ilog4netHelper.WriteLog_Info<ERP商品分类>(post, null, null, value?.ClientGuid, value?.ClientName, null);
                    string id = User.Identity.GetUserId();
                    if (string.IsNullOrEmpty(id) || _iUserRepository.GetClient(id, value.ClientGuid) == null)
                    {
                        return Json(model);
                    }
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json");
                    byte[] reByte = client.UploadData(_ISetting.oms.Base_Url + "/api/BaseData/getcategory", Encoding.UTF8.GetBytes(post));//http://192.0.1.188:15536/api/vendor/receivevendor
                    string reStr = Encoding.UTF8.GetString(reByte);
                    _ilog4netHelper.WriteLog_Info<ERP商品分类>(post, null, null, value?.ClientGuid, value?.ClientName, null);
                    _ilog4netHelper.WriteLog_Info<ERP商品分类>(reStr, null, null, value?.ClientGuid, value?.ClientName, null);
                    model = JsonConvert.DeserializeObject<List<CategoryItemViewModel>>(reStr);
                }
                catch (Exception ex)
                {
                    _ilog4netHelper.WriteLog_Error<ERP商品分类>(post, null, null, value?.ClientGuid, value?.ClientName, ex);
                }
            }
            else
            {
                //re.code = 0;
                //re.msg = "ERP包装代码数据格式错误";
                //var modelstate = BadRequest(ModelState);
                //string returestr = "";
                //foreach (var item in modelstate.ModelState.Values)
                //{
                //    //item.
                //    //item.Value.Value.RawValue.ToString()
                //    returestr += item.Errors != null ? item.Errors[0].ErrorMessage + item.Errors[0].Exception.Message + "\r\n" : "";
                //}
                //re.success = false;
                //re.data = returestr;
                _ilog4netHelper.WriteLog_Waring<ERP商品分类>(JsonConvert.SerializeObject(post), null, null, value?.ClientGuid?.ToString(), value.ClientName, null);
            }
            return Json(model);
        }
        /// <summary>
        /// 
        /// </summary>
        public class ERP商品分类
        {

        }
        /// <summary>
        /// 销售单位代码
        /// </summary>
        /// <param name="value">客户端信息</param>
        /// <returns></returns>
        [Route("api/basedata/GetUnit")]
        [HttpPost]
        public IHttpActionResult GetUnit([FromBody]ClientViewModel value)
        {
            List<UnitViewModel> model = new List<UnitViewModel>();
            string post = "";
            if (ModelState.IsValid)
            {
                try
                {
                    post = JsonConvert.SerializeObject(value);
                    _ilog4netHelper.WriteLog_Info<ERP销售单位代码>(post, null, null, value?.ClientGuid, value?.ClientName, null);
                    string id = User.Identity.GetUserId();
                    if (string.IsNullOrEmpty(id) || _iUserRepository.GetClient(id, value.ClientGuid) == null)
                    {
                        return Json(model);
                    }
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json");
                    byte[] reByte = client.UploadData(_ISetting.oms.Base_Url + "/api/basedata/GetUnit", Encoding.UTF8.GetBytes(post));//http://192.0.1.188:15536/api/vendor/receivevendor
                    string reStr = Encoding.UTF8.GetString(reByte);
                    _ilog4netHelper.WriteLog_Info<ERP销售单位代码>(post, null, null, value?.ClientGuid, value?.ClientName, null);
                    _ilog4netHelper.WriteLog_Info<ERP销售单位代码>(reStr, null, null, value?.ClientGuid, value?.ClientName, null);
                    model = JsonConvert.DeserializeObject<List<UnitViewModel>>(reStr);
                }
                catch (Exception ex)
                {
                    _ilog4netHelper.WriteLog_Error<ERP销售单位代码>(post, null, null, value?.ClientGuid, value?.ClientName, ex);
                }
            }
            else
            {
                //re.code = 0;
                //re.msg = "ERP包装代码数据格式错误";
                //var modelstate = BadRequest(ModelState);
                //string returestr = "";
                //foreach (var item in modelstate.ModelState.Values)
                //{
                //    //item.
                //    //item.Value.Value.RawValue.ToString()
                //    returestr += item.Errors != null ? item.Errors[0].ErrorMessage + item.Errors[0].Exception.Message + "\r\n" : "";
                //}
                //re.success = false;
                //re.data = returestr;
                _ilog4netHelper.WriteLog_Waring<ERP销售单位代码>(JsonConvert.SerializeObject(post), null, null, value?.ClientGuid?.ToString(), value.ClientName, null);
            }
            return Json(model);
        }
        /// <summary>
        /// 
        /// </summary>
        public class ERP获取品牌列表
        {

        }
        /// <summary>
        /// ERP获取品牌列表
        /// </summary>
        /// <returns></returns>
        [Route("api/product/GetAllManufacturer")]
        [HttpGet]
        public IHttpActionResult GetAllManufacturer()
        {
            List<Manufacturer> model = new List<Manufacturer>();
            ApiJsonResult<List<Manufacturer>> lstManufacturer = new ApiJsonResult<List<Manufacturer>>();
            string post = "";
            if (ModelState.IsValid)
            {
                try
                {
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json");
                    string reStr = client.DownloadString(_ISetting.oms.Base_Url + "/api/product/GetAllManufacturer");
                    _ilog4netHelper.WriteLog_Info<ERP获取品牌列表>(post, null, null, "", "", null);
                    _ilog4netHelper.WriteLog_Info<ERP获取品牌列表>(reStr, null, null, "", "", null);
                    lstManufacturer = JsonConvert.DeserializeObject<ApiJsonResult<List<Manufacturer>>>(reStr);
                    model = lstManufacturer.data;
                }
                catch (Exception ex)
                {
                    _ilog4netHelper.WriteLog_Error<ERP获取品牌列表>(post, null, null, "", "", ex);
                }
            }
            else
            {
                _ilog4netHelper.WriteLog_Waring<ERP销售单位代码>(JsonConvert.SerializeObject(post), null, null, "", "", null);
            }
            return Json(model);
        }
        /// <summary>
        /// 
        /// </summary>
        public class ERP销售单位代码
        {

        }
        /// <summary>
        /// ERP商品档案更新
        /// </summary>
        /// <param name="value">客户端信息</param>
        /// <returns></returns>
        [Route("api/Inventory/update")]
        [HttpPost]
        public IHttpActionResult updateInventory([FromBody]ProductViewModel value)
        {

            ProductViewModel model = new ProductViewModel();
            ApiJsonResult re = new ApiJsonResult();
            string post = "";
            if (ModelState.IsValid)
            {
                try
                {
                    foreach (var items in value.ProductItems)
                    {
                        List<UrlModel> urlModels = new List<UrlModel>();
                        urlModels = JsonConvert.DeserializeObject<List<UrlModel>>(items.ProductImgs);
                        foreach (var item in urlModels)
                        {
                            if (string.IsNullOrEmpty(item.InternationalCode))
                            {
                                item.InternationalCode = items.InternationalCode;
                            }
                        }
                        items.ProductImgs = JsonConvert.SerializeObject(urlModels);




                        List<UrlModel> urlModelDetail = new List<UrlModel>();
                        urlModelDetail = JsonConvert.DeserializeObject<List<UrlModel>>(items.DetailsImgs);
                        foreach (var item in urlModelDetail)
                        {
                            if (string.IsNullOrEmpty(item.InternationalCode))
                            {
                                item.InternationalCode = items.InternationalCode;
                            }
                        }
                        items.DetailsImgs = JsonConvert.SerializeObject(urlModelDetail);
                    }
                    post = JsonConvert.SerializeObject(value);
                    _ilog4netHelper.WriteLog_Info<ERP商品档案>(post, null, null, value?.ClientGuid, value?.ClientName, null);
                    string id = User.Identity.GetUserId();
                    if (string.IsNullOrEmpty(id) || _iUserRepository.GetClient(id, value.ClientGuid) == null)
                    {
                        re.data = "用户名错误";
                        _ilog4netHelper.WriteLog_Waring<ERP商品档案>(JsonConvert.SerializeObject(re), null, null, value?.ClientGuid, value?.ClientName, null);
                        return Json(re);
                    }
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json");
                    byte[] reByte = client.UploadData(_ISetting.oms.Base_Url + "/api/product/ReceiveProduct", Encoding.UTF8.GetBytes(post));//http://192.0.1.188:15536/api/vendor/receivevendor
                    string reStr = Encoding.UTF8.GetString(reByte);
                    _ilog4netHelper.WriteLog_Info<ERP商品档案>(post, null, null, value?.ClientGuid, value?.ClientName, null);
                    _ilog4netHelper.WriteLog_Info<ERP商品档案>(reStr, null, null, value?.ClientGuid, value?.ClientName, null);
                    re = JsonConvert.DeserializeObject<ApiJsonResult>(reStr);
                }
                catch (Exception ex)
                {
                    _ilog4netHelper.WriteLog_Error<ERP商品档案>(post, null, null, value?.ClientGuid, value?.ClientName, ex);
                    re.code = 0;
                    re.msg = ex.Message?.ToString();
                }
            }
            else
            {
                re.code = 0;
                re.msg = "ERP商品档案数据格式错误";
                var modelstate = BadRequest(ModelState);
                string returestr = "";
                foreach (var item in modelstate.ModelState.Keys)
                {
                    //item.
                    //item.Value.Value.RawValue.ToString()
                    //returestr += item.Errors != null ? item.Errors[0].ErrorMessage + "\r\n" : "";
                    returestr += "Key:" + item + "value:" + (modelstate.ModelState?[item].Errors != null ? (modelstate.ModelState?[item].Errors?[0].ErrorMessage + "   " + modelstate.ModelState?[item].Errors?[0].Exception?.Message) : "");// item.Errors != null ? item.Errors[0].ErrorMessage + "\r\n" : "";
                }
                re.success = false;
                re.data = returestr;
            }
            return Json(re);
        }
        /// <summary>
        /// ERP库存更新
        /// </summary>
        /// <param name="value">库存更新</param>
        /// <returns></returns>
        [Route("api/stock/stockupdate")]
        [HttpPost]
        public IHttpActionResult stockupdate([FromBody]StockViewModel value)
        {
            StockViewModel model = new StockViewModel();
            ApiJsonResult re = new ApiJsonResult();
            string post = "";
            if (ModelState.IsValid)
            {
                try
                {
                    post = JsonConvert.SerializeObject(value);
                    _ilog4netHelper.WriteLog_Info<ERP库存更新>(post, null, null, value?.ClientGuid, value?.ClientName, null);
                    string id = User.Identity.GetUserId();
                    if (string.IsNullOrEmpty(id) || _iUserRepository.GetClient(id, value.ClientGuid) == null)
                    {
                        re.data = "用户名错误";
                        return Json(re);
                    }
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json");
                    byte[] reByte = client.UploadData(_ISetting.oms.Base_Url + "/api/stock/receiveasaerpstock", Encoding.UTF8.GetBytes(post));//http://192.0.1.188:15536/api/vendor/receivevendor
                    string reStr = Encoding.UTF8.GetString(reByte);
                    _ilog4netHelper.WriteLog_Info<ERP库存更新>(post, null, null, value?.ClientGuid, value?.ClientName, null);
                    _ilog4netHelper.WriteLog_Info<ERP库存更新>(reStr, null, null, value?.ClientGuid, value?.ClientName, null);
                    re = JsonConvert.DeserializeObject<ApiJsonResult>(reStr);
                }
                catch (Exception ex)
                {
                    _ilog4netHelper.WriteLog_Error<ERP库存更新>(post, null, null, value?.ClientGuid, value?.ClientName, ex);
                }
            }
            else
            {
                re.code = 0;
                re.msg = "ERP库存更新数据格式错误";
                var modelstate = BadRequest(ModelState);
                string returestr = "";
                foreach (var item in modelstate.ModelState.Keys)
                {
                    //item.
                    //item.Value.Value.RawValue.ToString()
                    //returestr += item.Errors != null ? item.Errors[0].ErrorMessage + "\r\n" : "";
                    returestr += "Key:" + item + "value:" + (modelstate.ModelState?[item].Errors != null ? (modelstate.ModelState?[item].Errors?[0].ErrorMessage + "   " + modelstate.ModelState?[item].Errors?[0].Exception?.Message) : "");// item.Errors != null ? item.Errors[0].ErrorMessage + "\r\n" : "";
                }
                //foreach (var item in modelstate.ModelState.Keys)
                //{
                //    //item.
                //    //item.Value.Value.RawValue.ToString()
                //    returestr += item != null ? item.ToString() + "\r\n" : "";
                //}
                re.success = false;
                re.data = returestr;
                _ilog4netHelper.WriteLog_Waring<ERP库存更新>(JsonConvert.SerializeObject(re), null, null, value?.ClientGuid?.ToString(), value.ClientName, null);
            }
            return Json(re);
        }
        /// <summary>
        /// 订单查询
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Route("api/order/getorderlist")]
        [HttpPost]
        public HttpResponseMessage GetOrders(QueryOrderErp value)
        {
            ApiJsonResult<List<Order>> message = new ApiJsonResult<List<Order>>();
            string restr = "";
            if (ModelState.IsValid)
            {
                try
                {
                    _ilog4netHelper.WriteLog_Info<ERP订单查询>(JsonConvert.SerializeObject(value), null, "请求", value?.ClientGuid, value?.ClientName, null);
                    string id = User.Identity.GetUserId();
                    if (string.IsNullOrEmpty(id) || _iUserRepository.GetClient(id, value.ClientGuid) == null)
                    {
                        message.msg = "用户名错误";
                        message.success = false;
                        _ilog4netHelper.WriteLog_Error<ERP订单查询>(JsonConvert.SerializeObject(message), null, "3", value?.ClientGuid, value?.ClientName, null);
                        restr = JsonConvert.SerializeObject(message);
                    }
                    else
                    {
                        WebClient client = new WebClient();
                        client.Headers.Add("Content-Type", "application/json;charset=utf8");
                        IsoDateTimeConverter iso = new IsoDateTimeConverter();
                        iso.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
                        string update = JsonConvert.SerializeObject(value, iso);
                        byte[] reByte_Api = client.UploadData(_ISetting.oms.Base_Url + "/api/order/getorderlist", "Post", Encoding.UTF8.GetBytes(update));
                        restr = Encoding.UTF8.GetString(reByte_Api);
                        _ilog4netHelper.WriteLog_Info<ERP订单查询>(restr, null, "return", null);
                    }
                }
                catch (Exception ex)
                {
                    _ilog4netHelper.WriteLog_Error<ERP订单查询>(JsonConvert.SerializeObject(value), null, "2", value?.ClientGuid, value?.ClientName, ex);
                    //api_message.MessageCode = ((int)m_Code.Faile).ToString();
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
                //api_message.ErrorMsg = returestr;
                //api_message.MessageCode = ((int)m_Code.Faile).ToString();
                message.msg = returestr;
                message.success = false;
                restr = JsonConvert.SerializeObject(message);
                _ilog4netHelper.WriteLog_Error<ERP订单查询>(JsonConvert.SerializeObject(value), null, "3", value?.ClientGuid, value?.ClientName, null);
                _ilog4netHelper.WriteLog_Error<ERP订单查询>(JsonConvert.SerializeObject(message), "4", null, value?.ClientGuid, value?.ClientName, null);
            }
            return new HttpResponseMessage { Content = new StringContent(restr, Encoding.UTF8) };
        }



        /// <summary>
        /// 发货确认接口
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Route("api/order/delivery")]
        [HttpPost]
        public HttpResponseMessage UpdateExpress(ShipmentInfoViewModel value)
        {
            ApiJsonResult<object> message = new ApiJsonResult<object>();
            string restr = "";
            if (ModelState.IsValid)
            {
                try
                {
                    _ilog4netHelper.WriteLog_Info<ERP发货确认>(JsonConvert.SerializeObject(value), null, "请求", value?.ClientGuid, value?.ClientName, null);
                    string id = User.Identity.GetUserId();
                    if (string.IsNullOrEmpty(id) || _iUserRepository.GetClient(id, value.ClientGuid) == null)
                    {
                        message.msg = "用户名错误";
                        message.success = false;
                        _ilog4netHelper.WriteLog_Error<ERP发货确认>(JsonConvert.SerializeObject(message), null, "3", value?.ClientGuid, value?.ClientName, null);
                        restr = JsonConvert.SerializeObject(message);
                    }
                    else
                    {
                        WebClient client = new WebClient();
                        client.Headers.Add("Content-Type", "application/json;charset=utf8");
                        IsoDateTimeConverter iso = new IsoDateTimeConverter();
                        iso.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
                        string update = JsonConvert.SerializeObject(value, iso);
                        byte[] reByte_Api = client.UploadData(_ISetting.oms.Base_Url + "/api/order/delivery", "Post", Encoding.UTF8.GetBytes(update));
                        restr = Encoding.UTF8.GetString(reByte_Api);
                        _ilog4netHelper.WriteLog_Info<ERP发货确认>(restr, null, "return", null);
                    }
                }
                catch (Exception ex)
                {
                    _ilog4netHelper.WriteLog_Error<ERP发货确认>(JsonConvert.SerializeObject(value), null, "2", value?.ClientGuid, value?.ClientName, ex);
                    //api_message.MessageCode = ((int)m_Code.Faile).ToString();
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
                //api_message.ErrorMsg = returestr;
                //api_message.MessageCode = ((int)m_Code.Faile).ToString();
                message.msg = returestr;
                message.success = false;
                restr = JsonConvert.SerializeObject(message);
                _ilog4netHelper.WriteLog_Error<ERP发货确认>(JsonConvert.SerializeObject(value), null, "3", value?.ClientGuid, value?.ClientName, null);
                _ilog4netHelper.WriteLog_Error<ERP发货确认>(JsonConvert.SerializeObject(message), "4", null, value?.ClientGuid, value?.ClientName, null);
            }
            return new HttpResponseMessage { Content = new StringContent(restr, Encoding.UTF8) };
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class ERP商品档案
    {

    }
    /// <summary>
    /// 
    /// </summary>
    public class ERP库存更新
    {

    }
    /// <summary>
    /// 
    /// </summary>
    public class ERP订单查询
    {

    }
    /// <summary>
    /// 
    /// </summary>
    public class ERP发货确认
    {

    }
}
