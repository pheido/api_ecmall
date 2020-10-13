using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_ecmall.Domain.Abstract;
using api_ecmall.Domain.Entities;

namespace api_ecmall.Domain.Concrete
{
    public class CustomsRepository:ICustomsRepository
    {
        EFDbContext context = new EFDbContext();
        public IEnumerable<custom_order> custom_orders { get { return context.custom_orders; } }
        public void Save_Custom(custom_order value)
        {
            try
            {
                if (string.IsNullOrEmpty(value.orderNo))
                {

                }
                else
                {
                    context.custom_orders.Add(value);

                }
                context.SaveChanges();
            }
            catch(Exception ex)
            {

            }
        }
        public void Save_Custom_Re(custom_order_re value)
        {
            try
            {
                if (string.IsNullOrEmpty(value.guid.ToString()))
                {

                }
                else
                {
                    context.custom_order_res.Add(value);

                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }
        public payExInfo Get_payExInfo()
        {

            return null;
        }
    }
}
