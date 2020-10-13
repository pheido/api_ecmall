using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_ecmall.Domain.Entities;

namespace api_ecmall.Domain.Abstract
{
    public interface IpayExInfoRepository
    {
        IEnumerable<payExInfo_DTO> payExInfoes { get; }
        void payExInfo_Save(payExInfo_DTO info);
    }
}
