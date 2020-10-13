using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_ecmall.WebUI.Areas.ERP.Models
{
    /// <summary>
    /// 包装代码表体
    /// </summary>
    public class WrapInfoItemsViewModel
    {
        /// <summary>
        /// 包装代码
        /// </summary>
        public string WrapId { get; set; }
        /// <summary>
        /// 包装类型名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int SortId { get; set; }
    }
}