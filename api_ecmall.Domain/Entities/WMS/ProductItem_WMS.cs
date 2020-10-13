using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_ecmall.Domain.Entities.WMS
{
    [JsonObject(MemberSerialization.OptOut)]
    public class ProductItem_WMS
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Spu { get; set; }
        public decimal Price { get; set; }
        public string Manufacturer { get; set; }



        public int Published { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? UpdateOnUtc { get; set; }
        public string CreatedTimeStamp { get; set; }
        public string UpdateTimeStamp { get; set; }



        public string HsCode { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string UnitId { get; set; }
        public string UnitName { get; set; }



        public string WrapId { get; set; }
        public string WrapName { get; set; }
        public decimal VATRate { get; set; }
        public decimal ConsumptionTaxRate { get; set; }
        public int TradeType { get; set; }




        public int CiqCountry { get; set; }
        public string Gtin { get; set; }
        public int CategoryId { get; set; }
        public string SwiftNumber { get; set; }
    }
}
