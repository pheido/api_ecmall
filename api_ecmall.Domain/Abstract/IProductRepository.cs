using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_ecmall.Domain.Entities;

namespace api_ecmall.Domain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        void Save_Product(Product product);
    }
}
