using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_ecmall.WebUI.Areas.WMS.Models
{
    public class SpuResultViewModel
    {
        public string Spu { get; set; }
        public string Fileld { get; set; }
        public string Msg { get; set; }
        public int Result { get; set; }
    }
}