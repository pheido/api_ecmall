using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_ecmall.Domain.Entities
{
    public class LoggerInfo
    {
        public string UserName { get; set; }
        public string TimeSpan { get; set; }
        public string Message { get; set; }
        public int  Id { get; set; }
        public DateTime Date { get; set; }
        public string Thread { get; set; }
        public string Level { get; set; }
        public string Exception { get; set; }
        public string ClientGuid { get; set; }
        public string ClientName { get; set; }
        public string Logger { get; set; }
        public LoggerInfo(string _UserName, string _TimeSpan)
        {
            this.UserName = _UserName;
            this.TimeSpan = _TimeSpan;
        }
        public LoggerInfo()
        {
        }
    }
}
