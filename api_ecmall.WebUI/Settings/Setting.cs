using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using api_ecmall.Domain.Abstract;

namespace api_ecmall.WebUI.Settings
{
    /// <summary>
    /// 
    /// </summary>
    public class Setting:ISetting
    {
        JObject jObject=new JObject();
        private ILog4netHelper _ILog4netHelper;
        /// <summary>
        /// 
        /// </summary>
        public Setting(ILog4netHelper ILog4netHelper)
        {
            try
            {
                _ILog4netHelper = ILog4netHelper;
                using (StreamReader stream = File.OpenText(AppDomain.CurrentDomain.BaseDirectory + "appsetting.json"))
                {
                    using (JsonTextReader reader = new JsonTextReader(stream))
                    {
                        jObject = JObject.Load(reader);
                    }
                }
                _ILog4netHelper.WriteLog_Debug<Setting>("读取配置文件成功!", null, null, null);
            }
            catch(Exception ex)
            {
                _ILog4netHelper.WriteLog_Error<Setting>("读取配置文件失败!", null, null, ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public OMS_Setting oms {
            get
            {
                try
                {
                    return JsonConvert.DeserializeObject<OMS_Setting>(jObject.SelectToken("oms").ToString());
                }
                catch(Exception ex)
                {
                    _ILog4netHelper.WriteLog_Error<OMS_Setting>("读取配置文件失败!", null, null, ex);
                    return new OMS_Setting();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public Ecmall_Setting ecmall {
            get
            {
                try
                {
                    return JsonConvert.DeserializeObject<Ecmall_Setting>(jObject.SelectToken("ecmall").ToString());
                }
                catch (Exception ex)
                {
                    _ILog4netHelper.WriteLog_Error<Ecmall_Setting>("读取配置文件失败!", null, null, ex);
                    return new Ecmall_Setting();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public Customs_Server_Setting custom
        {
            get
            {
                try
                {
                    return JsonConvert.DeserializeObject<Customs_Server_Setting>(jObject.SelectToken("custom").ToString());
                }
                catch(Exception ex)
                {
                    _ILog4netHelper.WriteLog_Error<Customs_Server_Setting>("读取配置文件失败!", null, null, ex);
                    return new Customs_Server_Setting();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public Wms_Server_Setting wms
        {
            get
            {
                try
                {
                    return JsonConvert.DeserializeObject<Wms_Server_Setting>(jObject.SelectToken("wms").ToString());
                }
                catch (Exception ex)
                {
                    _ILog4netHelper.WriteLog_Error<Wms_Server_Setting>("读取配置文件失败!", null, null, ex);
                    return new Wms_Server_Setting();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public Erp_Setting erp
        {
            get
            {
                try
                {
                    return JsonConvert.DeserializeObject<Erp_Setting>(jObject.SelectToken("erp").ToString());
                }
                catch (Exception ex)
                {
                    _ILog4netHelper.WriteLog_Error<Erp_Setting>("读取配置文件失败!", null, null, ex);
                    return new Erp_Setting();
                }
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class OMS_Setting
    {
        /// <summary>
        /// url
        /// </summary>
        public string Base_Url { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class Ecmall_Setting
    {
        /// <summary>
        /// url
        /// </summary>
        public string Base_Url { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class Customs_Server_Setting
    {
        /// <summary>
        /// 
        /// </summary>
        public string Base_Url { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class Wms_Server_Setting
    {
        /// <summary>
        /// 
        /// </summary>
        public string Base_Url { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class Erp_Setting
    {
        /// <summary>
        /// 
        /// </summary>
        public List<kv> kvs { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class kv
    {
        public string k { get; set; }
        public string v { get; set; }
    }
}