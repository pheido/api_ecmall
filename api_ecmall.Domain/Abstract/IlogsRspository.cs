using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_ecmall.Domain.Entities;

namespace api_ecmall.Domain.Abstract
{
    public interface IlogsRspository
    {
        IEnumerable<LoggerInfo> LoggerInfos { get; }
        IEnumerable<LoggerInfo> GetLogs(int page,int count,int index);
        IEnumerable<LoggerInfo> GetLogs(DateTime startTime, DateTime endTime,string str);
    }
}
