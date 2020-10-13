using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using api_ecmall.Domain.Entities;
using api_ecmall.Domain.Abstract;
using Newtonsoft.Json;

namespace api_ecmall.WebUI.Areas.User.Controllers
{
    /// <summary>
    /// 用户管理API
    /// </summary>
    //[Authorize]
    [Route("api/User/UserManager")]
    public class UserManagerController : ApiController
    {
        private IRabbitMQHelper _iRabbitMQHelper;
        private IUserRepository _iUserRepository;
        private ILog4netHelper _iLog4netHelper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iRabbitMQHelper"></param>
        /// <param name="iUserRepository"></param>
        /// <param name="iLog4netHelper"></param>
        public UserManagerController(IRabbitMQHelper iRabbitMQHelper, IUserRepository iUserRepository, ILog4netHelper iLog4netHelper)
        {
            _iRabbitMQHelper = iRabbitMQHelper;
            _iUserRepository = iUserRepository;
            _iLog4netHelper = iLog4netHelper;
        }
        /// <summary>
        /// 提交用户报关信息
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public IHttpActionResult Post([FromBody]UserInfo value)
        {
            API_Message message = new API_Message();
            message.MessageCode = "1";
            string name = User.Identity.Name;
            if (ModelState.IsValid)
            {
                try
                {
                    //value.UserName = name;
                    _iUserRepository.Save_UserInfos(value);
                    _iLog4netHelper.WriteLog_Info<UserManagerController>(JsonConvert.SerializeObject(value), "", name, null);
                    _iLog4netHelper.WriteLog_Info<UserManagerController>(JsonConvert.SerializeObject(message), "", name, null);
                }
                catch(Exception ex)
                {
                    message.MessageCode = "2";
                    _iLog4netHelper.WriteLog_Error<UserManagerController>(JsonConvert.SerializeObject(value), "", name, ex);
                    _iLog4netHelper.WriteLog_Error<UserManagerController>(JsonConvert.SerializeObject(message), "", name, ex);
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
                message.MessageCode = "2";
                message.ErrorMsg = returestr;
                _iLog4netHelper.WriteLog_Error<UserManagerController>(JsonConvert.SerializeObject(value), "", name, null);
                _iLog4netHelper.WriteLog_Error<UserManagerController>(JsonConvert.SerializeObject(message), "", name, null);
            }
            return Json(message);
        }
    }
}
