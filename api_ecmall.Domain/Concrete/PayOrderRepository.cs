using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_ecmall.Domain.Abstract;
using api_ecmall.Domain.Entities.Pay;

namespace api_ecmall.Domain.Concrete
{
    public class PayOrderRepository:IPayOrderRepository
    {
        EFDbContext context = new EFDbContext();
        public IEnumerable<PayOrder> PayOrders { get { return context.PayOrders; } }
        public void Save_PayOrder(PayOrder value)
        {
            try
            {
                if (value.OrderGuid == Guid.Empty)
                {
                    value.OrderGuid = Guid.NewGuid();
                    context.PayOrders.Add(value);
                }
                else
                {
                    context.PayOrders.Add(value);
                }
                context.SaveChanges();
            }
            catch(Exception ex)
            {

            }
        }
    }
}
