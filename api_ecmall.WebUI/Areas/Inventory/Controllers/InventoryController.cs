using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using api_ecmall.WebUI.Areas.Inventory.Models;
using api_ecmall.Domain.Abstract;
using api_ecmall.Domain.Entities;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using api_ecmall.Domain.Entities.Inventory;
using System.Text;
using api_ecmall.WebUI.Settings;
using api_ecmall.WebUI.Areas.WMS.Models;
using Newtonsoft.Json.Converters;

namespace api_ecmall.WebUI.Areas.Inventory.Controllers
{
    /// <summary>
    /// 商品档案/库存更新接口集合
    /// </summary>
    public class InventoryController : ApiController
    {
        private IRabbitMQHelper _iRabbitMQHelper;
        private IProductRepository _IProductRepository;
        private ILog4netHelper _logger;
        private ISetting _ISetting;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="iRabbitMQHelper"></param>
        /// <param name="IProductRepository"></param>
        /// <param name="logger"></param>
        /// <param name="ISetting"></param>
        public InventoryController(IRabbitMQHelper iRabbitMQHelper, IProductRepository IProductRepository, ILog4netHelper logger, ISetting ISetting)
        {
            _iRabbitMQHelper = iRabbitMQHelper;
            _IProductRepository = IProductRepository;
            _logger = logger;
            _ISetting = ISetting;
        }
        /// <summary>
        /// 商品档案更新 OMS商品同步到WMS和ECMALL (OMS-API矩阵-ECMALL/OMS-API矩阵-WMS)
        /// </summary>
        /// <param name="value">Product</param>
        /// <returns>API_Message</returns>
        [Route("api/Inventory/item_update")]
        public IHttpActionResult item_update([FromBody]Product value)
        {
            API_Message api_message = new API_Message();
            api_message.MessageCode = ((int)m_Code.Success).ToString();
            try
            {
                if (ModelState.IsValid)
                {
                    if(value.ProductItems==null?true:value.ProductItems.Count<=0)
                    {
                        api_message.MessageCode= ((int)m_Code.Faile).ToString();
                        api_message.ErrorMsg = "商品为空";
                        _logger.WriteLog_Info<InventoryController>(JsonConvert.SerializeObject(value), null, "oms请求", null);
                        _logger.WriteLog_Waring<InventoryController>(JsonConvert.SerializeObject(api_message), null, null, null);
                        return Json(api_message);
                    }
                    for (int i = 0; i < value.ProductItems.Count; i++)
                    {
                        value.ProductItems[i].ItemGuid = Guid.NewGuid();
                        for (int j = 0; j < value.ProductItems[i].SpecItems.Count; j++)
                        {
                            value.ProductItems[i].SpecItems[j].ItemGuid = value.ProductItems[i].ItemGuid;
                        }
                    }
                    _iRabbitMQHelper.Publish<InventoryController>(JsonConvert.SerializeObject(value).ToString());

                    //_IProductRepository.Save_Product(value);
                    _logger.WriteLog_Info<InventoryController>(JsonConvert.SerializeObject(value), null, "oms请求", null);
                }
                else
                {
                    //var modelstate = BadRequest(ModelState);
                    string returestr = "";
                    string re = "";
                    string pattern = @"(?is)(\[)(.d)?(\])";
                    Regex rgx = new Regex(pattern);
                    foreach (var item in ModelState)
                    {
                        returestr += item.Key.ToString() + "--------" + item.Value.Errors[0].ErrorMessage.ToString() + "\r\n";
                        re += rgx.Match(item.Value.Errors[0].ErrorMessage.ToString());
                    }
                    api_message.ErrorMsg = returestr;
                    api_message.MessageCode = ((int)m_Code.Faile).ToString();
                    _logger.WriteLog_Waring<InventoryController>(JsonConvert.SerializeObject(api_message), null, null, null);
                    _logger.WriteLog_Waring<InventoryController>(JsonConvert.SerializeObject(value), null, "oms请求", null);
                }
            }
            catch (Exception ex)
            {

                _logger.WriteLog_Error<InventoryController>(JsonConvert.SerializeObject(value), null, "oms请求", ex);
            }
            return Json(api_message);
        }
        /// <summary>
        /// 商品下架
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Route("api/Inventory/CloseInventory")]
        public HttpResponseMessage CloseInventory(InventoryClose value)
        {
            CloseSku api_message = new CloseSku();
            api_message.Result = 1;
            string reStr = "";
            _logger.WriteLog_Info<CloseInventoryController>(JsonConvert.SerializeObject(value), null, "oms请求", null);
            try
            {
                if (ModelState.IsValid)
                {
                    //_iRabbitMQHelper.Publish<InventoryPushController>(JsonConvert.SerializeObject(value).ToString());
                    string post = JsonConvert.SerializeObject(value);
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json");
                    byte[] reByte = client.UploadData(_ISetting.ecmall.Base_Url + "/appserver/index.php?m=Api&c=Goods&a=closeGoods", Encoding.UTF8.GetBytes(post));
                    reStr = Encoding.UTF8.GetString(reByte);
                    _logger.WriteLog_Info<CloseInventoryController>(reStr, null, "ecmall返回", null);
                    //api_message = JsonConvert.DeserializeObject<API_Message>(reStr);
                    //_logger.WriteLog_Info<InventoryPushController>(JsonConvert.SerializeObject(value), null, null, null);
                }
                else
                {
                    //var modelstate = BadRequest(ModelState);
                    string returestr = "";
                    string re = "";
                    string pattern = @"(?is)(\[)(.d)?(\])";
                    Regex rgx = new Regex(pattern);
                    foreach (var item in ModelState)
                    {
                        returestr += item.Key.ToString() + "--------" + item.Value.Errors[0].ErrorMessage.ToString() + "\r\n";
                        re += rgx.Match(item.Value.Errors[0].ErrorMessage.ToString());
                    }
                    api_message.Msg = returestr;
                    api_message.Result = 2;
                    reStr = JsonConvert.SerializeObject(new List<CloseSku>() { api_message });
                    _logger.WriteLog_Waring<CloseInventoryController>(reStr, null, null, null);
                    //_logger.WriteLog_Waring<InventoryPushController>(JsonConvert.SerializeObject(value), null, null, null);
                }
            }
            catch (Exception ex)
            {
                api_message.Msg = ex.Message;
                api_message.Result = 2;
                reStr = JsonConvert.SerializeObject(new List<CloseSku>() { api_message });
                _logger.WriteLog_Error<CloseInventoryController>(JsonConvert.SerializeObject(value), "oms请求", null, ex);
            }
            return new HttpResponseMessage { Content = new StringContent(reStr, Encoding.UTF8) };
        }
        /// <summary>
        /// 库存更新 ome-ecmall
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Route("api/Inventory/InventoryPush")]
        public IHttpActionResult InventoryPush(List<InventoryPush> value)
        {
            API_Message api_message = new API_Message();
            List<InventoryPushRe> lstInventoryRe = new List<InventoryPushRe>();
            api_message.MessageCode = ((int)m_Code.Success).ToString();
            _logger.WriteLog_Info<InventoryPushController>(JsonConvert.SerializeObject(value), null, "oms请求", null);
            try
            {
                if (ModelState.IsValid)
                {
                    //_iRabbitMQHelper.Publish<InventoryPushController>(JsonConvert.SerializeObject(value).ToString());
                    string post = JsonConvert.SerializeObject(value);
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json");
                    byte[] reByte = client.UploadData(_ISetting.ecmall.Base_Url + "/appserver/index.php?m=Api&c=Stock&a=addReserve", Encoding.UTF8.GetBytes(post));
                    string reStr = Encoding.UTF8.GetString(reByte);
                    _logger.WriteLog_Info<InventoryPushController>(reStr, null, "ecmall返回", null);
                    lstInventoryRe = JsonConvert.DeserializeObject<List<InventoryPushRe>>(reStr);
                    //_logger.WriteLog_Info<InventoryPushController>(JsonConvert.SerializeObject(value), null, null, null);
                }
                else
                {
                    //var modelstate = BadRequest(ModelState);
                    string returestr = "";
                    string re = "";
                    string pattern = @"(?is)(\[)(.d)?(\])";
                    Regex rgx = new Regex(pattern);
                    foreach (var item in ModelState)
                    {
                        returestr += item.Key.ToString() + "--------" + item.Value.Errors[0].ErrorMessage.ToString() + "\r\n";
                        re += rgx.Match(item.Value.Errors[0].ErrorMessage.ToString());
                    }
                    api_message.ErrorMsg = returestr;
                    api_message.MessageCode = ((int)m_Code.Faile).ToString();
                    _logger.WriteLog_Waring<InventoryPushController>(JsonConvert.SerializeObject(api_message), null, null, null);
                    //_logger.WriteLog_Waring<InventoryPushController>(JsonConvert.SerializeObject(value), null, null, null);
                }
            }
            catch (Exception ex)
            {

                _logger.WriteLog_Error<InventoryPushController>(JsonConvert.SerializeObject(value), "oms请求", null, ex);
            }
            return Json(lstInventoryRe);
        }
        /// <summary>
        /// 库存更新 ecmall获取oms库存
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Route("api/Inventory/GetInventory")]
        [HttpPost]
        public HttpResponseMessage GetInventory(List<InventoryPushRe> value)
        {
            string restr = "";
            ApiJsonResult<object> api_message = new ApiJsonResult<object>();
            _logger.WriteLog_Info<ECMALL库存请求>(JsonConvert.SerializeObject(value), null, "ecmall请求", null);
            try
            {
                if (ModelState.IsValid)
                {
                    //_iRabbitMQHelper.Publish<InventoryPushController>(JsonConvert.SerializeObject(value).ToString());
                    string post = JsonConvert.SerializeObject(value);
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json");
                    byte[] reByte = client.UploadData(_ISetting.oms.Base_Url + "/api/ProductPush/UpdateProductPushStatus", Encoding.UTF8.GetBytes(post));
                    restr = Encoding.UTF8.GetString(reByte);
                    _logger.WriteLog_Info<ECMALL库存请求>(restr, null, "oms返回", null);
                }
                else
                {
                    //var modelstate = BadRequest(ModelState);
                    string returestr = "";
                    string re = "";
                    string pattern = @"(?is)(\[)(.d)?(\])";
                    Regex rgx = new Regex(pattern);
                    foreach (var item in ModelState)
                    {
                        returestr += item.Key.ToString() + "--------" + item.Value.Errors[0].ErrorMessage.ToString() + "\r\n";
                        re += rgx.Match(item.Value.Errors[0].ErrorMessage.ToString());
                    }
                    api_message.msg = returestr;
                    api_message.success = false;
                    restr = JsonConvert.SerializeObject(api_message);
                    _logger.WriteLog_Waring<ECMALL库存请求>(JsonConvert.SerializeObject(api_message), null, null, null);
                    //_logger.WriteLog_Waring<InventoryPushController>(JsonConvert.SerializeObject(value), null, null, null);
                }
            }
            catch (Exception ex)
            {

                _logger.WriteLog_Error<ECMALL库存请求>(JsonConvert.SerializeObject(value), "ecmall请求", null, ex);
            }
            return new HttpResponseMessage { Content = new StringContent(restr, Encoding.UTF8) };
        }
        /// <summary>
        /// OMS商品价格请求
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Route("api/Product/ProductPrice")]
        [HttpPost]
        public HttpResponseMessage ProductPrice(ProductSkus value)
        {
            API_Message message = new API_Message();
            string restr = "";
            if (ModelState.IsValid)
            {
                try
                {
                    _logger.WriteLog_Info<OMS商品价格请求>(JsonConvert.SerializeObject(value), null, "请求", null);
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json;charset=utf8");
                    //IsoDateTimeConverter iso = new IsoDateTimeConverter();
                    //iso.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
                    string update = JsonConvert.SerializeObject(value);
                    byte[] reByte_Api = client.UploadData(_ISetting.ecmall.Base_Url + "/appserver/index.php?m=Api&c=Past&a=paste", "Post", Encoding.UTF8.GetBytes(update));
                    restr = Encoding.UTF8.GetString(reByte_Api);
                    _logger.WriteLog_Info<OMS商品价格请求>(restr, null, "return", null);
                }
                catch (Exception ex)
                {
                    _logger.WriteLog_Error<OMS商品价格请求>(JsonConvert.SerializeObject(value), null, "2", ex);
                    message.MessageCode = ((int)m_Code.Faile).ToString(); ;
                    message.ErrorMsg = "ecmall连接错误";
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
                message.ErrorMsg = returestr;
                message.MessageCode = ((int)m_Code.Faile).ToString();
                restr = JsonConvert.SerializeObject(message);
                _logger.WriteLog_Error<OMS商品价格请求>(JsonConvert.SerializeObject(value), null, "3", null);
                _logger.WriteLog_Error<OMS商品价格请求>(JsonConvert.SerializeObject(message), "4", null, null);
            }
            return new HttpResponseMessage { Content = new StringContent(restr, Encoding.UTF8) };
        }



        /// <summary>
        /// OMS商品价格请求
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Route("api/Product/GetProductPrice")]
        [HttpPost]
        public HttpResponseMessage GetProductPrice(QueryProductPrice value)
        {
            ProductPriceViewModel message = new ProductPriceViewModel();
            string restr = "";
            if (ModelState.IsValid)
            {
                try
                {
                    _logger.WriteLog_Info<ECMALL商品价格请求>(JsonConvert.SerializeObject(value), null, "请求", null);
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json;charset=utf8");
                    //IsoDateTimeConverter iso = new IsoDateTimeConverter();
                    //iso.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
                    string update = JsonConvert.SerializeObject(value);
                    byte[] reByte_Api = client.UploadData(_ISetting.oms.Base_Url + "/api/Product/GetProductPrice", "Post", Encoding.UTF8.GetBytes(update));
                    restr = Encoding.UTF8.GetString(reByte_Api);
                    _logger.WriteLog_Info<ECMALL商品价格请求>(restr, null, "return", null);
                }
                catch (Exception ex)
                {
                    _logger.WriteLog_Error<ECMALL商品价格请求>(JsonConvert.SerializeObject(value), null, "2", ex);
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
                _logger.WriteLog_Error<ECMALL商品价格请求>(JsonConvert.SerializeObject(value), null, "3", null);
                _logger.WriteLog_Error<ECMALL商品价格请求>(JsonConvert.SerializeObject(message), "4", null, null);
            }
            return new HttpResponseMessage { Content = new StringContent(restr, Encoding.UTF8) };
        }
        #region
        //public IHttpActionResult InventoryPushRe(List<InventoryPush> value)
        //{
        //    API_Message api_message = new API_Message();
        //    api_message.MessageCode = ((int)m_Code.Success).ToString();
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            string post = JsonConvert.SerializeObject(value);
        //            WebClient client = new WebClient();
        //            client.Headers.Add("Content-Type", "application/json");
        //            byte[] reByte = client.UploadData(_ISetting.oms.Base_Url + "/appserver/index.php?m=api&c=stock&a=addStock", Encoding.UTF8.GetBytes(post));
        //            string reStr = Encoding.UTF8.GetString(reByte);
        //            _logger.WriteLog_Info<InventoryPushReController>(JsonConvert.SerializeObject(value), null, null, null);
        //            _logger.WriteLog_Info<InventoryPushReController>(reStr, null, null, null);
        //            api_message = JsonConvert.DeserializeObject<API_Message>(reStr);
        //        }
        //        else
        //        {
        //            //var modelstate = BadRequest(ModelState);
        //            string returestr = "";
        //            string re = "";
        //            string pattern = @"(?is)(\[)(.d)?(\])";
        //            Regex rgx = new Regex(pattern);
        //            foreach (var item in ModelState)
        //            {
        //                returestr += item.Key.ToString() + "--------" + item.Value.Errors[0].ErrorMessage.ToString() + "\r\n";
        //                re += rgx.Match(item.Value.Errors[0].ErrorMessage.ToString());
        //            }
        //            api_message.ErrorMsg = returestr;
        //            api_message.MessageCode = ((int)m_Code.Faile).ToString();
        //            _logger.WriteLog_Waring<InventoryPushReController>(JsonConvert.SerializeObject(api_message), null, null, null);
        //            _logger.WriteLog_Waring<InventoryPushReController>(JsonConvert.SerializeObject(value), null, null, null);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.WriteLog_Error<InventoryPushReController>(JsonConvert.SerializeObject(value), null, null, ex);
        //    }
        //    return Json(api_message);
        //}
        #endregion
    }
    public class InventoryPushController
    {

    }
    public class InventoryPushReController
    {

    }
    public class CloseInventoryController
    {

    }
    /// <summary>
    /// 
    /// </summary>
    public class OMS商品价格请求
    {

    }
    /// <summary>
    /// 
    /// </summary>
    public class ECMALL商品价格请求
    {

    }
    /// <summary>
    /// 
    /// </summary>
    public class ECMALL库存请求
    {

    }
}
