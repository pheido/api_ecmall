using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace api_ecmall.Domain.Entities
{
    /// <summary>
    /// 库存更新表头				
    /// </summary>
    public class sku_update
    {
        /// <summary>
        /// 自增id
        /// </summary>
        [Required]
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// 终端id
        /// </summary>
        [Required]
        public string ClientGuid { get; set; }
        /// <summary>
        /// 终端名称
        /// </summary>
        [Required]
        public string ClientName { get; set; }
    }
}
