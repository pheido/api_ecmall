using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_ecmall.Domain.Abstract;
using api_ecmall.Domain.Entities;

namespace api_ecmall.Domain.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Product> Products { get { return context.Products; } }
        public void Save_Product(Product product)
        {
            try
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
