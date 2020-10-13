using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_ecmall.Domain.Entities.Inventory
{
    public class InventoryPushRe
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Field { get; set; }
        public string Msg { get; set; }
        public int Result { get; set; }
    }
}
