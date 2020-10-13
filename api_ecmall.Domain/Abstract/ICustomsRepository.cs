using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_ecmall.Domain.Entities;

namespace api_ecmall.Domain.Abstract
{
    public interface ICustomsRepository
    {
        IEnumerable<custom_order> custom_orders { get; }
        void Save_Custom(custom_order value);
        void Save_Custom_Re(custom_order_re value);
    }
}
