using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_ecmall.Domain.Abstract
{
    public interface ILog4netHelper
    {
        /// <summary>
        /// 日志：事件
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="Message">内容</param>
        /// <param name="timespan">时间戳</param>
        /// <param name="username">用户</param>
        /// <param name="ex">报错</param>
        void WriteLog_Info<T>(string Message, string timespan, string username, Exception ex) where T : class;
        /// <summary>
        /// 日志：错误
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="Message">内容</param>
        /// <param name="timespan">时间戳</param>
        /// <param name="username">用户</param>
        /// <param name="ex">报错</param>
        void WriteLog_Error<T>(string Message, string timespan, string username, Exception ex) where T : class;
        /// <summary>
        /// 日志：调试
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="Message">内容</param>
        /// <param name="timespan">时间戳</param>
        /// <param name="username">用户</param>
        /// <param name="ex">报错</param>
        void WriteLog_Debug<T>(string Message, string timespan, string username, Exception ex) where T : class;
        /// <summary>
        /// 日志：警告
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="Message">内容</param>
        /// <param name="timespan">时间戳</param>
        /// <param name="username">用户</param>
        /// <param name="ex">报错</param>
        void WriteLog_Waring<T>(string Message, string timespan, string username,Exception ex) where T : class;






        /// <summary>
        /// 日志：事件
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="Message">内容</param>
        /// <param name="timespan">时间戳</param>
        /// <param name="username">用户</param>
        /// <param name="ex">报错</param>
        void WriteLog_Info<T>(string Message, string timespan, string username, string clientguid, string clientname, Exception ex) where T : class;
        /// <summary>
        /// 日志：错误
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="Message">内容</param>
        /// <param name="timespan">时间戳</param>
        /// <param name="username">用户</param>
        /// <param name="ex">报错</param>
        void WriteLog_Error<T>(string Message, string timespan, string username, string clientguid, string clientname, Exception ex) where T : class;
        /// <summary>
        /// 日志：调试
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="Message">内容</param>
        /// <param name="timespan">时间戳</param>
        /// <param name="username">用户</param>
        /// <param name="ex">报错</param>
        void WriteLog_Debug<T>(string Message, string timespan, string username, string clientguid, string clientname, Exception ex) where T : class;
        /// <summary>
        /// 日志：警告
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="Message">内容</param>
        /// <param name="timespan">时间戳</param>
        /// <param name="username">用户</param>
        /// <param name="ex">报错</param>
        void WriteLog_Waring<T>(string Message, string timespan, string username, string clientguid, string clientname, Exception ex) where T : class;
    }
}
