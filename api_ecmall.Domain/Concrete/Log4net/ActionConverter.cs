using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Layout;
using log4net.Layout.Pattern;
using log4net.Core;
using System.IO;
using api_ecmall.Domain.Entities;

namespace api_ecmall.Domain.Concrete.Log4net
{
    public class ActionConverter:PatternLayoutConverter
    {
        protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
        {
            var actionInfo = loggingEvent.MessageObject as LoggerInfo;
            if(actionInfo==null)
            {
                writer.Write("");
            }
            else
            {
                switch(this.Option.ToLower())
                {
                    case "username":
                        writer.Write(actionInfo.UserName);
                        break;
                    case "timespan":
                        writer.Write(actionInfo.TimeSpan);
                        break;
                    case "message":
                        writer.Write(actionInfo.Message);
                        break;
                    case "clientguid":
                        writer.Write(actionInfo.ClientGuid);
                        break;
                    case "clientname":
                        writer.Write(actionInfo.ClientName);
                        break;
                }
            }
            //throw new NotImplementedException();
        }
    }
}
