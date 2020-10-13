using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace api_ecmall.WebUI.Areas.ERP.Models
{
    /// <summary>
    /// 库存
    /// </summary>
    public class StockViewModel:ClientViewModel
    {
        /// <summary>
        /// 库存内容
        /// </summary>
        public virtual StockInERP StockIn { get; set; }
    }
    /// <summary>
    /// 库存详情
    /// </summary>
    public class StockInERP
    {
        /// <summary>
        /// 出入库类型
        /// </summary>
        public int InOutType { get; set; }
        /// <summary>
        /// 供应商id
        /// </summary>
        public int SupplierId { get; set; }
        /// <summary>
        /// 来源仓库id
        /// </summary>
        public int FromWareHoseId { get; set; }
        /// <summary>
        /// 仓库id
        /// </summary>
        public int WareHoseId { get; set; }
        /// <summary>
        /// 发货人id
        /// </summary>
        public int ConsignorId { get; set; }
        /// <summary>
        /// 库存更新详情-lstStock
        /// </summary>
        public virtual List<StockInOutDetailERP> StockInOutDetail { get; set; }
    }
    /// <summary>
    /// 库存更新详情-stock
    /// </summary>
    public class StockInOutDetailERP
    {
        /// <summary>
        /// 商品sku -stock
        /// </summary>
        //[Required(ErrorMessage = "{0}必须字段")]
        public string Sku { get; set; }
        /// <summary>
        /// 可用库存  - stock
        /// </summary>
        public int Num { get; set; }
        /// <summary>
        /// 上下架状态
        /// </summary>
        [EnumDataType(typeof(enumGoodsShelvessStatus))]
        public int? GoodsOnShelvesStatus { get; set; }
    }
}