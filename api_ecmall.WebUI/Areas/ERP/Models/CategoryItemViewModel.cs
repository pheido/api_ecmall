using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_ecmall.WebUI.Areas.ERP.Models
{
    /// <summary>
    /// 商品分类表
    /// </summary>
    public class CategoryItemViewModel
    {
        /// <summary>
        /// 分类Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 父类id
        /// </summary>
        public int ParentId { get; set; }
    }
}