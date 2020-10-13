using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_ecmall.Domain.Entities.WareHouse;
using api_ecmall.Domain.Abstract;

namespace api_ecmall.Domain.Concrete
{
    public class WarehouseRepository: IWarehouseRepository
    {
        EFDbContext context = new EFDbContext();
        public IEnumerable<WarehouseInfo> WarehouseInfoes
        {
            get
            {
                return context.WarehouseInfoes;
            }
        }
        public void SaveWarehouse(WarehouseInfo info)
        {
            try
            {
                if (info != null)
                {
                    context.WarehouseInfoes.Add(info);
                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
