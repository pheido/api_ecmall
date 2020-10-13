using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace api_ecmall.Domain.Entities
{
    /// <summary>
    /// 库存更新表体-Item					
    /// </summary>
    public class sku_update_item
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// 目标店铺ID
        /// </summary>
        [Required]
        public string ShopId { get; set; }
        /// <summary>
        /// 目标店铺名称
        /// </summary>
        [Required]
        public string ShopName { get; set; }
        /// <summary>
        /// Sku编号，如果开启规格则此项为必须
        /// </summary>
        public string Sku { get; set; }
        /// <summary>
        /// 1、开启规格 0、关闭规格 是否开启规格
        /// </summary>
        [Required]
        public string IsSku { get; set; }
        /// <summary>
        /// 存货编号
        /// </summary>
        [Required]
        public string InventoryCode { get; set; }
        /// <summary>
        /// 存货名称
        /// </summary>
        [Required]
        public string Inventory { get; set; }
        /// <summary>
        /// 规格属性，如果开启规格，此项必须
        /// </summary>
        public string SpecSku { get; set; }
        /// <summary>
        /// 更新数量 正数为增加，负数为减少
        /// </summary>
        [Required]
        public int Count { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        [Required]
        public int Unit { get; set; }
        /// <summary>
        /// 1、采购入库 2、销售出库 3、退货入库 4、赠品出库 5、赠品入库 6、调拨入库 7、调拨出库 8、其他出库 9、其他入库 10、盘盈 11盘亏
        /// </summary>
        [Required]
        public int StockType { get; set; }
    }
}
