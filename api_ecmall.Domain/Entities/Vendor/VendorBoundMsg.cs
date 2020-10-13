using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace api_ecmall.Domain.Entities.Vendor
{
    public class VendorBoundMsg
    {
        //[Required(ErrorMessage = "{0}必须字段")]
        public string ClientGuid { get; set; }
        //[Required(ErrorMessage = "{0}必须字段")]
        public string ClientName { get; set; }
        public Vendor Vendor { get; set; }
    }
}
