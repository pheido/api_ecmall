using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace api_ecmall.WebUI.Areas.ERP.Models
{
    /// <summary>
    /// ERP订单实体
    /// </summary>
    public class QueryOrderErp: ClientViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public QueryOrdersErp QueryOrders { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class QueryOrdersErp
    {
        /// <summary>
        /// 
        /// </summary>
        public int VendorId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage ="{0}必须字段")]
        public string VendorGuid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? OrderCreateStartTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? OrderCreateEndTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? OrderUpdateStartTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? OrderUpdateEndTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? OrderStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? PageIndex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? PageSize { get; set; }
    }
}