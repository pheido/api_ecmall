using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_ecmall.Domain.Abstract;
using log4net;
using api_ecmall.Domain.Entities;
using api_ecmall.Domain.Concrete.Log4net;
using Newtonsoft.Json;

namespace api_ecmall.Domain.Concrete
{
    public class Log4netHelper: ILog4netHelper
    {
        ILog _log;


        public void WriteLog_Info<T>(string Message, string timespan, string username,Exception ex) where T : class
        {
            try
            {
                LoggerInfo info = new LoggerInfo();
                info.TimeSpan = timespan;
                info.UserName = username;
                info.Message = Message;
                _log = log4net.LogManager.GetLogger(typeof(T).Name.ToString());
                _log.Info(info, ex);
            }
            catch (Exception exe)
            {
                LoggerInfo info = new LoggerInfo();
                info.TimeSpan = timespan;
                info.UserName = username;
                info.Message = Message;
                _log = log4net.LogManager.GetLogger(typeof(T).Name.ToString());
                _log.Error(info, exe);
            }
        }
        public void WriteLog_Error<T>(string Message, string timespan, string username, Exception ex) where T : class
        {
            try
            {
                LoggerInfo info = new LoggerInfo();
                info.TimeSpan = timespan;
                info.UserName = username;
                info.Message = Message;
                _log = log4net.LogManager.GetLogger(typeof(T).Name.ToString());
                _log.Error(info, ex);
            }
            catch (Exception exe)
            {
                LoggerInfo info = new LoggerInfo();
                info.TimeSpan = timespan;
                info.UserName = username;
                info.Message = Message;
                _log = log4net.LogManager.GetLogger(typeof(T).Name.ToString());
                _log.Error(info, exe);
            }
        }
        public void WriteLog_Debug<T>(string Message, string timespan, string username, Exception ex) where T : class
        {
            try
            {
                LoggerInfo info = new LoggerInfo();
                info.TimeSpan = timespan;
                info.UserName = username;
                info.Message = Message;
                _log = log4net.LogManager.GetLogger(typeof(T).Name.ToString());
                _log.Debug(info, ex);
            }
            catch (Exception exe)
            {
                LoggerInfo info = new LoggerInfo();
                info.TimeSpan = timespan;
                info.UserName = username;
                info.Message = Message;
                _log = log4net.LogManager.GetLogger(typeof(T).Name.ToString());
                _log.Error(info, exe);
            }
        }
        public void WriteLog_Waring<T>(string Message, string timespan, string username, Exception ex) where T : class
        {
            try
            {
                LoggerInfo info = new LoggerInfo();
                info.TimeSpan = timespan;
                info.UserName = username;
                info.Message = Message;
                _log = log4net.LogManager.GetLogger(typeof(T).Name.ToString());
                _log.Warn(info, ex);
            }
            catch (Exception exe)
            {
                LoggerInfo info = new LoggerInfo();
                info.TimeSpan = timespan;
                info.UserName = username;
                info.Message = Message;
                _log = log4net.LogManager.GetLogger(typeof(T).Name.ToString());
                _log.Error(info, exe);
            }
        }






        public void WriteLog_Info<T>(string Message, string timespan,string username,string clientguid, string clientname, Exception ex) where T : class
        {
            try
            {
                LoggerInfo info = new LoggerInfo();
                info.TimeSpan = timespan;
                info.UserName = username;
                info.Message = Message;
                info.ClientGuid = clientguid;
                info.ClientName = clientname;
                _log = log4net.LogManager.GetLogger(typeof(T).Name.ToString());
                _log.Info(info, ex);
            }
            catch(Exception exe)
            {
                LoggerInfo info = new LoggerInfo();
                info.TimeSpan = timespan;
                info.UserName = username;
                info.Message = Message;
                info.ClientGuid = clientguid;
                info.ClientName = clientname;
                _log = log4net.LogManager.GetLogger(typeof(T).Name.ToString());
                _log.Error(info, exe);
            }
        }
        public void WriteLog_Error<T>(string Message, string timespan, string username, string clientguid, string clientname, Exception ex) where T : class
        {
            try
            {
                LoggerInfo info = new LoggerInfo();
                info.TimeSpan = timespan;
                info.UserName = username;
                info.Message = Message;
                info.ClientGuid = clientguid;
                info.ClientName = clientname;
                _log = log4net.LogManager.GetLogger(typeof(T).Name.ToString());
                _log.Error(info, ex);
            }
            catch (Exception exe)
            {
                LoggerInfo info = new LoggerInfo();
                info.TimeSpan = timespan;
                info.UserName = username;
                info.Message = Message;
                info.ClientGuid = clientguid;
                info.ClientName = clientname;
                _log = log4net.LogManager.GetLogger(typeof(T).Name.ToString());
                _log.Error(info, exe);
            }
        }
        public void WriteLog_Debug<T>(string Message, string timespan, string username, string clientguid, string clientname, Exception ex) where T : class
        {
            try
            {
                LoggerInfo info = new LoggerInfo();
                info.TimeSpan = timespan;
                info.UserName = username;
                info.Message = Message;
                info.ClientGuid = clientguid;
                info.ClientName = clientname;
                _log = log4net.LogManager.GetLogger(typeof(T).Name.ToString());
                _log.Debug(info, ex);
            }
            catch (Exception exe)
            {
                LoggerInfo info = new LoggerInfo();
                info.TimeSpan = timespan;
                info.UserName = username;
                info.Message = Message;
                info.ClientGuid = clientguid;
                info.ClientName = clientname;
                _log = log4net.LogManager.GetLogger(typeof(T).Name.ToString());
                _log.Error(info, exe);
            }
        }
        public void WriteLog_Waring<T>(string Message, string timespan, string username, string clientguid, string clientname, Exception ex) where T : class
        {
            try
            {
                LoggerInfo info = new LoggerInfo();
                info.TimeSpan = timespan;
                info.UserName = username;
                info.Message = Message;
                info.ClientGuid = clientguid;
                info.ClientName = clientname;
                _log = log4net.LogManager.GetLogger(typeof(T).Name.ToString());
                _log.Warn(info, ex);
            }
            catch (Exception exe)
            {
                LoggerInfo info = new LoggerInfo();
                info.TimeSpan = timespan;
                info.UserName = username;
                info.Message = Message;
                info.ClientGuid = clientguid;
                info.ClientName = clientname;
                _log = log4net.LogManager.GetLogger(typeof(T).Name.ToString());
                _log.Error(info, exe);
            }
        }
    }
}
