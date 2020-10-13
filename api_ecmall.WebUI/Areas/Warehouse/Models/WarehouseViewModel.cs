using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using api_ecmall.Domain.Entities.WareHouse;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_ecmall.WebUI.Areas.Warehouse.Models
{
    /// <summary>
    /// 新增仓库实体
    /// </summary>
    [JsonObject(MemberSerialization.OptOut)]
    [Table("ClientsLog")]
    public class WarehouseViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public int id { get; set; }
        /// <summary>
        /// 客户端id
        /// </summary>
        public Guid ClientGuid { get; set; }
        /// <summary>
        /// 客户端名称
        /// </summary>
        public string ClientName { get; set; }
        /// <summary>
        /// 仓库信息
        /// </summary>
        public WarehouseInfo Warehouse { get; set; }
    }
}