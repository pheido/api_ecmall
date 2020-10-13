using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace api_ecmall.WebUI.Areas.WMS.Models
{
    /// <summary>
    /// WMS--OMS出入库库存通知单
    /// </summary>
    public class WMSStockViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        ///[Required(ErrorMessage = "{0}必须字段")]
        public string ClientGuid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        ///[Required(ErrorMessage = "{0}必须字段")]
        public string ClientNmae { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public StockStatus StockStatus { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class StockStatus
    {
        /// <summary>
        /// 
        /// </summary>
        public string StockInOutBn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string StatusId { get; set; }
    }
}