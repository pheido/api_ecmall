using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace api_ecmall.Domain.Entities.WMS
{
    /// <summary>
    /// 出入库通知单
    /// </summary>
    public class StockNotice
    {
        //[Required(ErrorMessage = "{0}必须字段")]
        public int id { get; set; }
        /// <summary>
        /// 出入库类型：1 入库 2 出库
        /// </summary>
        //[Required(ErrorMessage = "{0}必须字段")]
        public int InOutType { get; set; }
        [Required(ErrorMessage = "{0}必须字段")]
        public string StockInBn { get; set; }
        /// <summary>
        /// 入库类型，1 采购入库2 销售入库 3退货入库 4赠品出库 5赠品入库 6调拨入库 7调拨出库 8其他出库 9其他入库 10盘盈 11盘亏
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string TypeId { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        //[Required(ErrorMessage = "{0}必须字段")]
        public int BranchId { get; set; }



        /// <summary>
        /// 店铺名称
        /// </summary>
        //[Required(ErrorMessage = "{0}必须字段")]
        public string BranchName { get; set; }
        /// <summary>
        /// 原始单据ID，如果存在则必须
        /// </summary>
        public int OriginalId { get; set; }
        /// <summary>
        /// 原始单据编号，如果存在则必须
        /// </summary>
        public string OriginalBn { get; set; }
        /// <summary>
        /// 供应商ID
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public int SupplierId { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string SupplierName { get; set; }




        /// <summary>
        /// 调入仓库ID，如果入库则必须
        /// </summary>
        public int WareHoseId { get; set; }
        /// <summary>
        /// 调入仓库名称，如果入库则必须
        /// </summary>
        public string WareHoseName { get; set; }
        /// <summary>
        /// 调出仓库ID，如果入库则必须
        /// </summary>
        public int FromWareHoseID { get; set; }
        /// <summary>
        /// 调出仓库名称，如果入库则必须
        /// </summary>
        public string FromWareHoseName { get; set; }
        /// <summary>
        /// 单据金额总计
        /// </summary>
        //[Required(ErrorMessage = "{0}必须字段")]
        public decimal StockAmount { get; set; }




        /// <summary>
        /// 实际出入库数量
        /// </summary>
        //[Required(ErrorMessage = "{0}必须字段")]
        public decimal StockNum { get; set; }
        /// <summary>
        /// 库存结余
        /// </summary>
        public int BalanceNum { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string Oper { get; set; }
        /// <summary>
        /// 创立时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime EditTime { get; set; }




        /// <summary>
        /// 作业状态：1 暂存 2 未审 3 仓库确认 4 已审 5 已取消   默认值为1
        /// </summary>
        public int OperStatus { get; set; }
        /// <summary>
        /// 结算状态 1 未结算 2 已结算 3 部分结算   默认为1
        /// </summary>
        public int SettleStatus { get; set; }
        /// <summary>
        /// 结算时间
        /// </summary>
        public DateTime SettleTime { get; set; }
        /// <summary>
        ///  结算数量
        /// </summary>
        public decimal SettleNum { get; set; }
        /// <summary>
        /// 结算金额
        /// </summary>
        public decimal SettleAmount { get; set; }




        /// <summary>
        /// 结算单号
        /// </summary>
        public string SettleBn { get; set; }
        /// <summary>
        /// 单位成本
        /// </summary>
        public decimal UnitCost { get; set; }
        /// <summary>
        /// 现存数量
        /// </summary>
        public decimal NowNum { get; set; }
        /// <summary>
        /// 库存成本
        /// </summary>
        public decimal StockCost { get; set; }
        /// <summary>
        /// 结存成本
        /// </summary>
        public decimal NowCost { get; set; }



        public int? ExtrNum1 { get; set; }
        public int? ExtrNum2 { get; set; }
        public int? ExtrNum3 { get; set; }
        public string ExtrChar1 { get; set; }
        public string ExtrChar2 { get; set; }




        public string ExtrChar3 { get; set; }
        public int IsDelete { get; set; }
        public DateTime DeleteTime { get; set; }
        public string BoxNo { get; set; }
        public string BatchNo { get; set; }





        public int SettlementMethod { get; set; }
        public DateTime ConfirmationTime { get; set; }
        public DateTime SubmissionTime { get; set; }
        public List<Transportation> Transportation { get; set; }
        //public StockInOutDetail StockInOutDetail { get; set; }
        public List<StockInOutDetail> StockItemDetail { get; set; }




        public int ConsignorId { get; set; }
    }
    public class StockInOutDetail
    {
        /// <summary>
        /// 出入库通知单明细ID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 出入库通知单ID
        /// </summary>
        public int StockDumpId { get; set; }
        /// <summary>
        /// 出入库通知单编号
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string StockDumpBn { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// 生成时间
        /// </summary>
        public DateTime StockDumpTime { get; set; }


        /// <summary>
        /// sku
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string Sku { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string ProductName { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal Num { get; set; }
        /// <summary>
        /// 已出入库数量
        /// </summary>
        public decimal InNums { get; set; }
        /// <summary>
        /// 不良品数量
        /// </summary>
        public decimal DefectiveNum { get; set; }


        /// <summary>
        /// 出入库价格
        /// </summary>
        public decimal ApproPrice { get; set; }
        [Required(ErrorMessage = "{0}必须字段")]
        public string HsCode { get; set; }
        public int CountryId { get; set; }
        public int CiqCountry { get; set; }
        [Required(ErrorMessage = "{0}必须字段")]
        public string CountryName { get; set; }
        public string UnitId { get; set; }



        public string UnitName { get; set; }
        [Required(ErrorMessage = "{0}必须字段")]
        public string WarpId { get; set; }
        public string WarpName { get; set; }
        public decimal VATRate { get; set; }
        public decimal ConsumptionTaxRate { get; set; }



        public int TradeType { get; set; }
        public string AttrComb { get; set; }
        [Required(ErrorMessage = "{0}必须字段")]
        public string InternationalCode { get; set; }
        public string Gtin { get; set; }
        public bool IsCollectiongBarcodes { get; set; }


        public bool IsMeasure { get; set; }
        [Required(ErrorMessage = "{0}必须字段")]
        public string Spu { get; set; }
        [Required(ErrorMessage = "{0}必须字段")]
        public string AttrXml { get; set; }
    }
    public class Transportation
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0}必须字段")]
        public string BillNo { get; set; }
        [Required(ErrorMessage = "{0}必须字段")]
        public string ConveyanceNo { get; set; }
        [Required(ErrorMessage = "{0}必须字段")]
        public string CabinNo { get; set; }
        [Required(ErrorMessage = "{0}必须字段")]
        public string TransportCompany { get; set; }


        public int TransportationMethod { get; set; }
        [Required(ErrorMessage = "{0}必须字段")]
        public string Contact { get; set; }
        [Required(ErrorMessage = "{0}必须字段")]
        public string TelephoneNumber { get; set; }
        public DateTime EstimatedDeliveryTime { get; set; }
        [Required(ErrorMessage = "{0}必须字段")]
        public string PlaceOfDelivery { get; set; }



        public DateTime ExpectedArrivalTime { get; set; }
        [Required(ErrorMessage = "{0}必须字段")]
        public string DestinationOfDeliverance { get; set; }
        public DateTime CreateTime { get; set; }
        public int DataSources { get; set; }
        public string LadingBillNo { get; set; }
    }
}
