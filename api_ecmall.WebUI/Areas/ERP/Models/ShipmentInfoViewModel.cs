using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace api_ecmall.WebUI.Areas.ERP.Models
{
    /// <summary>
    /// ERP发货实体
    /// </summary>
    public class ShipmentInfoViewModel:ClientViewModel
    {
        /// <summary>
        /// 确认发货详情
        /// </summary>
        public ShipmentInfoModel ShipmentInfo { get; set; }
    }
    /// <summary>
    /// 确认发货详情
    /// </summary>
    public class ShipmentInfoModel
    {
        /// <summary>
        /// 供应商Id
        /// </summary>
        public int VendorId { get; set; }
        /// <summary>
        /// 供应商Guid
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string VendorGuid { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        [Required(ErrorMessage = "{0}必须字段")]
        public string OrderNo { get; set; }
        /// <summary>
        /// 快递公司代码
        /// </summary>
        public string ShipmentCopCode { get; set; }
        /// <summary>
        /// 快递单号
        /// </summary>
        public string TrackingNumber { get; set; }
        /// <summary>
        /// 是否拒绝发货0：正常发货1：拒绝发货
        /// </summary>
        [EnumDataType(typeof(enmuRefuse))]
        public int IsRefuse { get; set; }
        /// <summary>
        /// 是否无需物流0：正常发货1：自行送货
        /// </summary>
        [EnumDataType(typeof(enmuExpress))]
        public int IsNoExpress { get; set; }
        /// <summary>
        /// 备注，拒绝发货和无需物流，必传此字段，说明拒绝原因或发货方式
        /// </summary>
        public string Note { get; set; }
    }
    /// <summary>
    /// 是否拒绝发货0：正常发货1：拒绝发货
    /// </summary>
    enum enmuRefuse
    {
        Is = 0,
        NoIs = 1
    }
    /// <summary>
    /// 是否无需物流0：正常发货1：自行送货
    /// </summary>
    enum enmuExpress
    {
        Is=0,
        NoIs=1
    }
}