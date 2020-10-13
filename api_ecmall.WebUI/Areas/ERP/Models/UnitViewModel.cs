using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_ecmall.WebUI.Areas.ERP.Models
{
    /// <summary>
    /// 销售单位代码表
    /// </summary>
    public class UnitViewModel
    {
        /// <summary>
        /// 销售单位代码
        /// </summary>
        public string UnitId { get; set; }
        /// <summary>
        /// 销售单位名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int SortId { get; set; }
    }
}