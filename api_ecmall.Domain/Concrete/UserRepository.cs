using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_ecmall.Domain.Abstract;
using api_ecmall.Domain.Entities;
using System.Data.Entity;

namespace api_ecmall.Domain.Concrete
{
    public class UserRepository:IUserRepository
    {
        private ILog4netHelper _logger;
        public UserRepository(ILog4netHelper logger)
        {
            _logger = logger;
        }
        EFDbContext context = new EFDbContext();
        public IEnumerable<UserInfo> UserInfos { get { return context.UserInfoes; } }
        public AspNetClient GetClient(string Id, string ClientGuid)
        {
            AspNetClient client = new AspNetClient();
            try
            {
                client = context.AspNetClients.Where(t => t.Id == Id && t.ClientGuid == ClientGuid).FirstOrDefault();
            }
            catch
            {

            }
            return client;
        }
        public bool Save_UserInfos(UserInfo info)
        {
            bool flag = false;
            if(info!=null)
            {
                try
                {
                    UserInfo _info = context.UserInfoes.Where(t => t.UserName == info.UserName).FirstOrDefault();
                    if (_info!=null&&info.UserName!=null)
                    {
                        _info.alipayAppId = info.alipayAppId;
                        _info.alipaySec = info.alipaySec;
                        _info.cebCode = info.cebCode;
                        _info.copCode = info.copCode;
                        _info.copName = info.copName;

                        _info.customsApiUrl = info.customsApiUrl;
                        _info.customsType = info.customsType;
                        _info.dxpId = info.dxpId;
                        _info.ebcCode = info.ebcCode;
                        _info.ebcName = info.ebcName;

                        _info.ebpCode = info.ebpCode;
                        _info.ebpName = info.ebpName;
                        _info.ecpCode = info.ecpCode;
                        _info.isActive = info.isActive;
                        _info.SysCode = info.SysCode;

                        _info.wxappId = info.wxappId;
                        _info.wxpayCode = info.wxpayCode;
                        _info.wxshopId = info.wxshopId;
                        _info.WarehouseId = info.WarehouseId;
                        _info.PortCode = info.PortCode;
                        _info.AlipayPortCode = info.AlipayPortCode;
                        _info.WxpayPortCode = info.WxpayPortCode;
                    }
                    else
                    {
                        context.UserInfoes.Add(info);
                    }
                    if(context.SaveChanges()>0)
                    {
                        _logger.WriteLog_Debug<UserRepository>("保存报关通道成功", null, null, null);
                        flag = true;
                    }
                }
                catch(Exception ex)
                {
                    flag = false;
                    _logger.WriteLog_Error<UserRepository>("保存报关通道失败", null, null, ex);
                }
            }
            return flag;
        }
    }
}
