using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using api_ecmall.Domain.Abstract;
using api_ecmall.Domain.Entities;
using Newtonsoft.Json;
using System.Text;
using api_ecmall.WebUI.Areas.Pay.Models;

namespace api_ecmall.WebUI.Areas.Pay.Controllers
{
    /// <summary>
    /// 支付信息接口集合  来自ecmall
    /// </summary>
    public class PayController : ApiController
    {
        private ILog4netHelper _ILog4netHelper;
        private IRabbitMQHelper _IRabbitMQHelper;
        private ICustomsRepository _ICustomsRepository;
        private IpayExInfoRepository _IpayExInfoRepository;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="IRabbitMQHelper"></param>
        /// <param name="ILog4netHelper"></param>
        /// <param name="ICustomsRepository"></param>
        /// <param name="IpayExInfoRepository"></param>
        public PayController(
            IRabbitMQHelper IRabbitMQHelper,
            ILog4netHelper ILog4netHelper,
            ICustomsRepository ICustomsRepository,
            IpayExInfoRepository IpayExInfoRepository)
        {
            _IRabbitMQHelper = IRabbitMQHelper;
            _ILog4netHelper = ILog4netHelper;
            _ICustomsRepository = ICustomsRepository;
            _IpayExInfoRepository = IpayExInfoRepository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="payExInfoStr"></param>
        /// <returns></returns>
        [Route("api/pay/testpost")]
        [HttpPost]
        public IEnumerable<string> Post(string payExInfoStr)
        {
            int i = payExInfoStr.Length;
            return new string[] { payExInfoStr, "value2" };
        }

        /// <summary>
        /// ECMALL提交的支付内容
        /// </summary>
        /// <param name="value"></param>
        [Route("api/pay/payreal")]
        public IHttpActionResult payreal([FromBody]payExInfo_DTO value)
        {
            API_Message message = new API_Message();
            payExInfo_DTO dto = new payExInfo_DTO();
            dto = value;
            Guid payguid = Guid.NewGuid();
            
            message.MessageCode = "1";
            //string test = JsonConvert.SerializeObject(value);
            //int len = test.Length;
            string reStr = "";

            if (ModelState.IsValid)
            {
                try
                {
                    //WebClient client = new WebClient();
                    //client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                    //byte[] reByte = client.UploadData("https://swapptest.singlewindow.cn/ceb2grab/grab/realTimeDataUpload", Encoding.UTF8.GetBytes("payExInfoStr=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(value))));
                    //reStr = Encoding.UTF8.GetString(reByte);
                    //_ILog4netHelper.WriteLog_Info<PayController>(reStr, null, "payreal", null);
                    //message.ErrorMsg = reStr;

                    dto.payguid = payguid;
                    //value.payExchangeInfoHead.guid = payguid;
                    //dto.payExchangeInfoHead = new List<payExchangeInfoHead>() { value.payExchangeInfoHead };
                    dto.payExchangeInfoHead = value.payExchangeInfoHead;
                    dto.payExchangeInfoHead.ForEach(t=>t.guid=payguid);
                    dto.payExchangeInfoLists = value.payExchangeInfoLists;
                    dto.serviceTime = value.serviceTime;
                    dto.payExchangeInfoLists.ForEach(t => t.listguid = payguid);
                    dto.sessionID = value.sessionID;
                    dto.certNo = value.certNo;
                    dto.signValue = value.signValue;
                    dto.is_success = value.is_success;
                    dto.type = 1;
                    _ILog4netHelper.WriteLog_Info<PayController>(JsonConvert.SerializeObject(dto), null, "支付信息-from ecmall", null);
                    _IpayExInfoRepository.payExInfo_Save(dto);
                    if(value.is_success=="1")
                    {
                        payExInfoOmsViewModel model = new payExInfoOmsViewModel();
                        model.Orderno = dto.payExchangeInfoLists!=null ? dto.payExchangeInfoLists[0].orderNo:"";
                        model.PaymentMethodSystemName = value.payment_type;
                        model.PayTransactionId = dto.payExchangeInfoHead[0].payTransactionId;
                        _IRabbitMQHelper.Publish<PayController>(JsonConvert.SerializeObject(model));
                    }
                }
                catch (Exception ex)
                {
                    message.MessageCode = "2";
                    _ILog4netHelper.WriteLog_Info<PayController>(reStr, null, "支付信息-from ecmall", ex);
                }
            }
            else
            {
                message.MessageCode = "2";
                _ILog4netHelper.WriteLog_Waring<PayController>(reStr, null, "支付信息-from ecmall", null);
            }
            return Json(message);
        }
    }
}
