using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_ecmall.Domain.Entities.Inventory
{
    public class InventoryClose
    {
        [Required(ErrorMessage = "{0}必须字段")]
        public string Sku { get; set; }
    }
}
