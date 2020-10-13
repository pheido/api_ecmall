using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_ecmall.Domain.Entities.WMS
{
    /// <summary>
    /// 商品分类同步接口  请求来源OMS   转发目标WMS   
    /// </summary>
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="{0}必须字段")]
        public string Name { get; set; }
        public int ParentId { get; set; }
    }
}
