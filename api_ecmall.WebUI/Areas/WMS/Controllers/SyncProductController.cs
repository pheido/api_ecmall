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
using api_ecmall.Domain.Entities.WMS;

namespace api_ecmall.WebUI.Areas.WMS.Controllers
{
    /// <summary>
    /// WMS-商品档案更新接口集合
    /// </summary>
    public class WMSSyncProductController : ApiController
    {

        private ILog4netHelper _logger;
        private ISetting _ISetting;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="logger"></param>
        public WMSSyncProductController(ILog4netHelper logger, ISetting ISetting)
        {
            _logger = logger;
            _ISetting = ISetting;
        }
        /// <summary>
        /// 商品档案同步接口
        /// </summary>
        /// <param name="value"></param>
        [Route("api/ProductWMS/SyncProduct")]
        public IHttpActionResult Post([FromBody]ProductOmsViewModel value)
        {
            API_Message api_message = new API_Message();
            api_message.MessageCode = ((int)m_Code.Success).ToString();
            Product_Message message = new Product_Message();
            ProductWmsViewModel product = new ProductWmsViewModel();
            string restr = "";
            if (ModelState.IsValid)
            {
                try
                {
                    _logger.WriteLog_Info<WMSSyncProductController>(JsonConvert.SerializeObject(value), null, "update", null);

                    product.ClientGuid = value.ClientGuid;
                    product.ClientName = value.ClientName;
                    //product.ProductItems = new List<ProductItem_WMS>();
                    List<ProductItem_WMS> lstPro = new List<ProductItem_WMS>();
                    foreach (var item in value.ProductItems)
                    {
                        ProductItem_WMS item_wms = new ProductItem_WMS();
                        //item_wms.Id = item.id;
                        item_wms.Name = item.Name;
                        item_wms.Spu = item.Sku;
                        item_wms.Price = item.Price;
                        item_wms.Manufacturer = item.Manufacturer;


                        item_wms.Published = item.Published;
                        item_wms.CreatedOnUtc = item.CreatedOnUtc;
                        item_wms.UpdateOnUtc = item.UpdateOnUtc;
                        item_wms.CreatedTimeStamp = item.CreatedTimeStamp;
                        item_wms.UpdateTimeStamp = item.UpdateTimeStamp;



                        item_wms.HsCode = item.HsCode;
                        item_wms.CountryId = item.CountryId;
                        item_wms.CountryName = item.CountryName;
                        item_wms.UnitId = item.UnitId;
                        item_wms.UnitName = item.UnitName;



                        item_wms.WrapId = item.WrapId;
                        item_wms.WrapName = item.WrapName;
                        item_wms.VATRate = item.VATRate;
                        item_wms.ConsumptionTaxRate = item.ConsumptionTaxRate;
                        item_wms.TradeType = item.TradeType;



                        item_wms.CiqCountry = item.CiqCountry;
                        item_wms.Gtin = item.Gtin;
                        item_wms.CategoryId = item.CategoryId;
                        item_wms.SwiftNumber = item.SwiftNumber;



                        lstPro.Add(item_wms);
                    }
                    product.ProductItems = lstPro;





                    string update = JsonConvert.SerializeObject(product);
                    _logger.WriteLog_Info<WMSSyncProductController>(update, null, "return", null);
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json;charset=utf8");

                    byte[] reByte_Api = client.UploadData(_ISetting.wms.Base_Url + "?parm=Product", "Post", Encoding.UTF8.GetBytes(update));
                    restr = Encoding.UTF8.GetString(reByte_Api);
                    _logger.WriteLog_Info<WMSSyncProductController>(restr, null, "return", null);
                    message = JsonConvert.DeserializeObject<Product_Message>(restr);
                    if(message.success=="true")
                    {
                        //api_message.
                    }
                    else
                    {
                        api_message.ErrorMsg = restr;
                        api_message.MessageCode = "2";
                    }
                }
                catch (Exception ex)
                {
                    _logger.WriteLog_Error<WMSSyncProductController>(JsonConvert.SerializeObject(value), null, null, ex);
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
                _logger.WriteLog_Error<WMSSyncProductController>(JsonConvert.SerializeObject(value), null, null, null);
                _logger.WriteLog_Error<WMSSyncProductController>(JsonConvert.SerializeObject(api_message), null, null, null);
            }
            return Json(api_message);
        }
        /// <summary>
        /// 异步返回接口
        /// </summary>
        /// <param name="lstSpuResult"></param>
        /// <returns></returns>
        [Route("api/ProductWMS/SyncResult")]
        public IHttpActionResult SpuResult(List<SpuResultViewModel> lstSpuResult)
        {

            API_Message api_message = new API_Message();
            api_message.MessageCode = ((int)m_Code.Success).ToString();
            string restr = "";
            if (ModelState.IsValid)
            {
                try
                {
                    _logger.WriteLog_Info<WMSSyncSpuResult>(JsonConvert.SerializeObject(lstSpuResult), null, "update", null);

                    string update = JsonConvert.SerializeObject(lstSpuResult);
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json");

                    byte[] reByte_Api = client.UploadData(_ISetting.oms.Base_Url + "/api/ProductPush/UpdateProductPushStatus", "Post", Encoding.UTF8.GetBytes(update));
                    //byte[] reByte_Api = client.UploadData("http://xinqing19830730.xicp.vip:58769/api/ProductPush/UpdateProductPushStatus", "Post", Encoding.UTF8.GetBytes(update));
                    restr = Encoding.UTF8.GetString(reByte_Api);
                    _logger.WriteLog_Info<WMSSyncSpuResult>(restr, null, "return", null);
                    api_message = JsonConvert.DeserializeObject<API_Message>(restr);
                }
                catch (Exception ex)
                {
                    _logger.WriteLog_Error<WMSSyncSpuResult>(JsonConvert.SerializeObject(lstSpuResult), null, null, ex);
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
                _logger.WriteLog_Error<WMSSyncSpuResult>(JsonConvert.SerializeObject(lstSpuResult), null, null, null);
                _logger.WriteLog_Error<WMSSyncSpuResult>(JsonConvert.SerializeObject(api_message), null, null, null);
            }

            return Json(api_message);
        }
    }
    public class WMSSyncSpuResult
    {

    }
}
