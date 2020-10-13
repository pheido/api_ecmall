using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_ecmall.Domain.Entities;

namespace api_ecmall.Domain.Abstract
{
    public interface IUserRepository
    {
        IEnumerable<UserInfo> UserInfos { get; }
        AspNetClient GetClient(string Id, string ClientGuid);
        bool Save_UserInfos(UserInfo info);
    }
}
