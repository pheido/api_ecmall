using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_ecmall.Domain.Entities
{
    public class AspNetClient
    {
        public string Id { get; set; }
        [Key]
        public string ClientGuid { get; set; }
        public string ClientName { get; set; }
        public string Description { get; set; }
    }
}
