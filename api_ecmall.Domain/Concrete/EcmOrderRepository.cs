using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_ecmall.Domain.Abstract;
using api_ecmall.Domain.Entities.Orders;

namespace api_ecmall.Domain.Concrete
{
    public class EcmOrderRepository:IEcmOrderRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Order> Orders {
            get { return context.Orders; } }
        public bool Save_Orders(Order order)
        {
            bool flag = false;
            try
            {
                //if (order.Order_id == 0)
                //{
                //    context.ecm_orders.Add(order);
                //}
                //else
                //{
                //ecm_order ord = context.ecm_orders.FirstOrDefault();

                //}
                //ord.Buyer_email = "test";
                Order ecm = new Order();

                //ecm.Add_time = order.Add_time;
                //ecm.anonymous = order.anonymous;
                //ecm.Auto_finished_time = order.Auto_finished_time;
                //ecm.Buyer_email = order.Buyer_email;
                //ecm.Buyer_id = order.Buyer_id;

                //ecm.Buyer_name = order.Buyer_name;
                //ecm.discount = order.discount;
                //ecm.evaluation_status = order.evaluation_status;
                //ecm.evaluation_time = order.evaluation_time;
                //ecm.Express_company = order.Express_company;

                //ecm.extension = order.extension;
                //ecm.Finished_time = order.Finished_time;
                //ecm.Goods_amount = order.Goods_amount;
                //ecm.Invoice_no = order.Invoice_no;
                //ecm.order_amount = order.order_amount;

                //ecm.Order_id = order.Order_id;
                //ecm.Order_sn = order.Order_sn;
                //ecm.Out_trade_sn = order.Out_trade_sn;
                //ecm.Payment_code = order.Payment_code;
                //ecm.Payment_id = order.Payment_id;

                //ecm.Payment_name = order.Payment_name;
                //ecm.pay_alter = order.pay_alter;
                //ecm.Pay_message = order.Pay_message;
                //ecm.Pay_time = order.Pay_time;
                //ecm.postscript = order.postscript;

                //ecm.seller_evaluation_status = order.seller_evaluation_status;
                //ecm.seller_evaluation_time = order.seller_evaluation_time;
                //ecm.Seller_id = order.Seller_id;
                //ecm.Seller_name = order.Seller_name;
                //ecm.Ship_time = order.Ship_time;

                //ecm.Status = order.Status;
                //ecm.Type = order.Type;





                context.Orders.Add(order);
                context.SaveChanges();
                //if (context.SaveChanges()>0)
                //{
                //    flag = true;
                //}
            }
            catch(Exception ex)
            {
                flag = false;
            }
            return flag;
        }
    }
}
