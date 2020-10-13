using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_ecmall.Domain.Entities.Inventory
{
    /// <summary>
    /// 库存更新实体  oms--ecmall
    /// </summary>
    public class InventoryPush
    {
        public string ProductCode { get; set; }
        public string Sku { get; set; }
        public int WarehouseId { get; set; }
        public int StoreId { get; set; }
        public decimal AvailableQuantity { get; set; }
        public int Id { get; set; }
        public decimal Price { get; set; }
    }
}
