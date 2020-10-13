using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using api_ecmall.Domain.Abstract;
using api_ecmall.Domain.Entities;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using System.Data.Entity;
using api_ecmall.WebUI.Infrastructure;
using System.Web.Mvc;
using api_ecmall.Domain.Concrete;
using api_ecmall.WebUI.Models;

namespace api_ecmall.WebUI.Controllers
{
    /// <summary>
    /// 日志
    /// </summary>
    //[EnableCors("http://localhost:5000", "*","*")]
    //[HiddenApi]
    public class LogsController : Controller
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="updatetime"></param>
        /// <param name="page"></param>
        /// <param name="count"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public ViewResult Index(DateTime? updatetime,int? page=0, int? count=10,int? index=0)
        {
            logsRspository _ilogsRspository = new logsRspository();
            updatetime = updatetime??DateTime.Now;
            List<LoggerInfo> lstLog = new List<LoggerInfo>();
            lstLog = _ilogsRspository.GetLogs(page??0,count??0,index??0).ToList();
            foreach (var item in lstLog)
            {
                switch(item.Logger)
                {
                    case "InventoryPushController":
                        item.Logger = "推送库存 oms-ecnall";
                        break;
                    case "InventoryController":
                        item.Logger = "推送商品档案 oms-ecnall";
                        break;
                    default:
                        break;
                }
            }
            LogsViewModel model = new LogsViewModel()
            {
                page = 0,
                count = 10,
                info = lstLog,
                index = lstLog?[0].Id??0
            };
            return View(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="updatetime"></param>
        /// <param name="page"></param>
        /// <param name="count"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public JsonResult GetData(DateTime? updatetime, int? page = 0, int? count = 10, int? index = 0)
        {
            logsRspository _ilogsRspository = new logsRspository();
            updatetime = updatetime ?? DateTime.Now;
            List<LoggerInfo> lstLog = new List<LoggerInfo>();
            lstLog = _ilogsRspository.GetLogs(page ?? 0, count ?? 0, index ?? 0).ToList();
            if(lstLog?[0].Id==index)
            {
                lstLog = new List<LoggerInfo>();
            }
            else
            {
                index = lstLog[0].Id;
            }
            foreach (var item in lstLog)
            {
                switch (item.Logger)
                {
                    case "InventoryPushController":
                        item.Logger = "推送库存 oms-ecnall";
                        break;
                    case "InventoryController":
                        item.Logger = "推送商品档案 oms-ecnall";
                        break;
                    default:
                        break;
                }
            }
            LogsViewModel model = new LogsViewModel()
            {
                page = 0,
                count = 10,
                info = lstLog,
                index = index ?? 0
            };
            var res = new JsonResult();
            res.Data = model;
            res.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return res;
        }
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="str"></param>
        ///// <param name="startTime"></param>
        ///// <param name="endTime"></param>
        ///// <param name="page"></param>
        ///// <param name="count"></param>
        ///// <returns></returns>
        //public JsonResult GetData_1(string str, DateTime? startTime, DateTime? endTime, int page = 0, int count = 10)
        //{
        //    logsRspository _ilogsRspository = new logsRspository();
        //    startTime = startTime ?? DateTime.Now;
        //    endTime = endTime == null ? ((DateTime)startTime).AddDays(1) : endTime;
        //    List<LoggerInfo> lstLog = new List<LoggerInfo>();
        //    lstLog = _ilogsRspository.GetLogs((DateTime)startTime, (DateTime)endTime, str).ToList();
        //    foreach (var item in lstLog)
        //    {
        //        switch (item.Logger)
        //        {
        //            case "InventoryPushController":
        //                item.Logger = "推送库存 oms-ecnall";
        //                break;
        //            case "InventoryController":
        //                item.Logger = "推送商品档案 oms-ecnall";
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    LogsAntViewModel model = new LogsAntViewModel()
        //    {
        //        list = lstLog.Skip(page * count).Take(count).ToList(),
        //        pagination = new Pagination
        //        {
        //            total = lstLog.Count,
        //            pageSize = count,
        //            current = page
        //        }
        //    };
        //    var res = new JsonResult();
        //    res.Data = model;
        //    res.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        //    return res;
        //}
    }
}
