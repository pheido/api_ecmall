using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_ecmall.Domain.Abstract;
using api_ecmall.Domain.Entities;

namespace api_ecmall.Domain.Concrete
{
    public class logsRspository:IlogsRspository
    {
        EFDbContext context = new EFDbContext();
        public IEnumerable<LoggerInfo> LoggerInfos { get {
                return context.LoggerInfoes; } }
        public IEnumerable<LoggerInfo> GetLogs(int page, int count, int index)
        {
            if (index > 0)
            {
                return context.LoggerInfoes.OrderByDescending(t => t.Id).Where(t => t.Level != "DEBUG"&&t.Id>(index-10));
            }
            else
            {
                return context.LoggerInfoes.OrderByDescending(t => t.Id).Where(t => t.Level != "DEBUG").Take(10);
            }
        }
        public IEnumerable<LoggerInfo> GetLogs(DateTime startTime,DateTime endTime, string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return context.LoggerInfoes.OrderByDescending(t => t.Id).Where(t => t.Level != "DEBUG" && t.Date > startTime && t.Date < endTime);
            }
            else
            {
                return context.LoggerInfoes.OrderByDescending(t => t.Id).Where(t => t.Level != "DEBUG" && t.Date>startTime && t.Date<endTime && t.Message.Contains(str));
            }
        }
    }
}
