using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_ecmall.Domain.Entities.WMS
{
    public class Product_WMS
    {
        public string ClientGuid { get; set; }
        public string ClientName { get; set; }
        public List<ProductItem_WMS> ProductItems { get; set; }
    }
    public class Product_Message
    {
        public string success { get; set; }
        public string code { get; set; }
        public string msg { get; set; }
    }
}
