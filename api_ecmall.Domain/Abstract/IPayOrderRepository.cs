using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_ecmall.Domain.Entities.Pay;

namespace api_ecmall.Domain.Abstract
{
    public interface IPayOrderRepository
    {
        IEnumerable<PayOrder> PayOrders { get; }
        void Save_PayOrder(PayOrder value);
    }
}
