using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace api_ecmall.Domain.Entities.WareHouse
{
    [JsonObject(MemberSerialization.OptOut)]
    public class WarehouseInfo
    {
        [Key]
        [JsonIgnore]
        public int id { get; set; }
        /// <summary>
        /// 报关通道(ECMALL称为仓库)id
        /// </summary>
        [Required(ErrorMessage ="{0}字段必须")]
        public string ChannelId { get; set; }
        /// <summary>
        /// 报关通道(ECMALL称为仓库)名称
        /// </summary>
        [Required(ErrorMessage = "{0}字段必须")]
        public string ChannelName { get; set; }
        /// <summary>
        /// 所在地
        /// </summary>
        public string Local { get; set; }
        /// <summary>
        /// 报关通道(ECMALL称为店铺)id
        /// </summary>
        [Required(ErrorMessage = "{0}字段必须")]
        public string VendorId { get; set; }
        /// <summary>
        /// 报关通道(ECMALL称为店铺)名称
        /// </summary>
        [Required(ErrorMessage = "{0}字段必须")]
        public string VendorName { get; set; }


        /// <summary>
        /// .贸易类型 1:保税备货 2：直邮 3：一般贸易
        /// </summary>
        [Required(ErrorMessage = "{0}字段必须")]
        [EnumDataType(typeof(TradeType))]
        public string TradeType { get; set; }
        /// <summary>
        /// 是否ASA自由仓库
        /// </summary>
        [Required(ErrorMessage = "{0}字段必须")]
        public string IfAdmin { get; set; }
        /// <summary>
        /// 组合吗
        /// </summary>
        [Required(ErrorMessage = "{0}字段必须")]
        public string GroupId { get; set; }
        [JsonIgnore]
        public Guid ClientGuid { get; set; }
        [JsonIgnore]
        public string ClientName { get; set; }
    }
}
