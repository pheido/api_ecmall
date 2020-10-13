using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_ecmall.WebUI.Areas.ERP.Models
{
    /// <summary>
    /// 国家地区表提
    /// </summary>
    public class CountryInfoItemViewModel
    {
        /// <summary>
        /// 海关编码
        /// </summary>
        public int CustomsId { get; set; }
        /// <summary>
        /// 国家地区名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 国家地区英文名称
        /// </summary>
        public string EnName { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int SortId { get; set; }
        /// <summary>
        /// 国检代码
        /// </summary>
        public int CiqId { get; set; }
    }
}