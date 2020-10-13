using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using api_ecmall.Domain.Abstract;
using Newtonsoft.Json.Linq;
using XML311.XmlModel;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Text;
using System.Web;
using api_ecmall.WebUI.Settings;

namespace api_ecmall.WebUI.Areas.Customs.Controllers
{
    /// <summary>
    /// 广州报关回执推送接口
    /// </summary>
    public class customguangzhouController : ApiController
    {
        private ILog4netHelper _ILog4netHelper;
        private ISetting _ISetting;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ILog4netHelper"></param>
        /// <param name="ISetting"></param>
        public customguangzhouController(ILog4netHelper ILog4netHelper, ISetting ISetting)
        {
            _ILog4netHelper = ILog4netHelper;
            _ISetting = ISetting;
        }
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="clientid"></param>
        /// <param name="key"></param>
        /// <param name="messageType"></param>
        /// <returns></returns>
        [Route("api/custom/custom_guangzhou")]
        public string Get(string clientid,string key,string messageType)
        {
            //try
            //{
            //    Request.Content.ReadAsStreamAsync().Result.Seek(0, System.IO.SeekOrigin.Begin);
            //    string content = Request.Content.ReadAsStringAsync().Result;
            //    _ILog4netHelper.WriteLog_Info<customguangzhouController>(clientid + "---" + key + "---" + messageType + "---" , null, "get", null);
            //    _ILog4netHelper.WriteLog_Info<customguangzhouController>(content, null, "get", null);
            //}
            //catch(Exception ex)
            //{
            //    _ILog4netHelper.WriteLog_Error<customguangzhouController>("get", null, "get", ex);
            //}
            return "SUCCESS";
        }
        /// <summary>
        /// POST
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [Route("api/custom/custom_guangzhou")]
        public HttpResponseMessage Post([FromBody]OpenReq_Data obj)
        {
            try
            {
                string[] _str;
                CEB312Message message = new CEB312Message();
                Dictionary<string, string> dic = new Dictionary<string, string>();
                Request.Content.ReadAsStreamAsync().Result.Seek(0, System.IO.SeekOrigin.Begin);
                string content = Request.Content.ReadAsStringAsync().Result;
                _ILog4netHelper.WriteLog_Info<customguangzhouController>(content, "1", "post", null);
                if (content.Contains("&"))
                {
                    _str = content.Split('&');
                    foreach (var item in _str)
                    {
                        if (item.Contains("="))
                        {
                            string[] str = item.Split('=');
                            dic.Add(str[0], str[1]);
                        }
                    }

                }
                if(dic.Keys.Contains("messageText"))
                {
                    using (StringReader sr=new StringReader(HttpUtility.UrlDecode(dic["messageText"])))
                    {
                        try
                        {
                            XmlSerializer xmldes = new XmlSerializer(typeof(CEB312Message));
                            message = (CEB312Message)xmldes.Deserialize(sr);


                            DeclarationReceipt ret_info = new DeclarationReceipt();
                            ret_info.OrderNo = message.OrderReturn?.orderNo == null ? message.OrderReturn?.orderSerialNode.Substring(19) : message.OrderReturn?.orderNo;
                            if (!string.IsNullOrEmpty(message.OrderReturn?.returnStatus))
                            {
                                ret_info.Result = "T";
                                string status = message.OrderReturn.returnStatus;
                                if (status == "2" || status == "3" || status == "120")
                                {
                                    ret_info.Result = "T";
                                }
                                else
                                {
                                    ret_info.Result = "F";
                                }
                            }
                            ret_info.ResultMessage = message?.OrderReturn?.returnInfo;

                            string request = "";
                            try
                            {
                                request = JsonConvert.SerializeObject(ret_info);
                                WebClient client = new WebClient();
                                client.Headers.Add("Content-Type", "application/json");
                                //Uri _uri = new Uri("https://oms.jingjing.shop/api/Order/CustomsDeclarationReceipt");
                                Uri _uri = new Uri(_ISetting.oms.Base_Url + "/api/Order/CustomsDeclarationReceipt");
                                _ILog4netHelper.WriteLog_Info<customguangzhouController>(request, "3", null, null);
                                string respone = Encoding.UTF8.GetString(client.UploadData(_uri, Encoding.UTF8.GetBytes(request)));//_uri.UploadData(Encoding.UTF8.GetBytes(request));
                                _ILog4netHelper.WriteLog_Info<customguangzhouController>(respone, "4", null, null);
                            }
                            catch (Exception ex)
                            {
                                _ILog4netHelper.WriteLog_Info<customguangzhouController>(request, "5", null, ex);
                            }
                        }
                        catch(Exception ex)
                        {
                            _ILog4netHelper.WriteLog_Error<customguangzhouController>(content, "2", "post", ex);
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                _ILog4netHelper.WriteLog_Error<customguangzhouController>("post", "6", "post", ex);
            }
            return new HttpResponseMessage { Content=new StringContent("SUCCESS",Encoding.UTF8)} ;// Json("SUCCESS");
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class OpenReq_Data
    {
        /// <summary>
        /// 
        /// </summary>
        public string clientid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string messageText { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string messageType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string key { get; set; }
    }
}
