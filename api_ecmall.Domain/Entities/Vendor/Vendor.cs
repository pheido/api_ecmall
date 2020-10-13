using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace api_ecmall.Domain.Entities.Vendor
{
    public class Vendor
    {
        [Required(ErrorMessage = "{0}必须字段")]
        [RegularExpression(@"\d+")]
        public string ExternId { get; set; }
        [Required(ErrorMessage = "{0}必须字段")]
        [EnumDataType(typeof(enum_IsBounded))]
        public string IsBounded { get; set; }
    }
    public enum enum_IsBounded
    {
        isBound=1,
        noBound=2,
    }
}
