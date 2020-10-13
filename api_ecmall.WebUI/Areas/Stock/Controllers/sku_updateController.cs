using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using api_ecmall.Domain.Abstract;
using api_ecmall.Domain.Entities;

namespace api_ecmall.WebUI.Areas.Stock.Controllers
{
    ///// <summary>
    ///// 库存更新API
    ///// </summary>
    ////[Authorize]
    //[Route("api/Stock/sku_update")]
    //public class sku_updateController : ApiController
    //{
    //    private IRabbitMQHelper _iRabbitMQHelper;
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="iRabbitMQHelper"></param>
    //    public sku_updateController(IRabbitMQHelper iRabbitMQHelper)
    //    {
    //        _iRabbitMQHelper = iRabbitMQHelper;
    //    }
    //    public string Get(int id)
    //    {
    //        return "value";
    //    }

    //    // POST: api/sku_update
    //    public void Post([FromBody]sku_update value)
    //    {
    //        _iRabbitMQHelper.Publish<sku_update>("sku_update");
    //    }

    //    // PUT: api/sku_update/5
    //    public void Put(int id, [FromBody]string value)
    //    {
    //    }

    //    // DELETE: api/sku_update/5
    //    public void Delete(int id)
    //    {
    //    }
    //}
}
