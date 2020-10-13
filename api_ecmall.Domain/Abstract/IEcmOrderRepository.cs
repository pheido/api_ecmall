using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_ecmall.Domain.Entities.Orders;

namespace api_ecmall.Domain.Abstract
{
    public interface IEcmOrderRepository
    {
        IEnumerable<Order> Orders { get;}
        bool Save_Orders(Order order);
    }
}
