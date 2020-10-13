using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_ecmall.Domain.Entities;
using api_ecmall.Domain.Entities.Orders;
using System.Data.Entity;
using api_ecmall.Domain.Entities.Pay;
using api_ecmall.Domain.Entities.WareHouse;
using api_ecmall.Domain.Abstract;
using XML311.JsonModel;

namespace api_ecmall.Domain.Concrete
{
    public class EFDbContext:DbContext
    {
        public EFDbContext():base("name=DefaultConnection")
        {

        }
        public DbSet<Entities.Orders.Order> Orders { get; set; }
        public DbSet<Entities.Orders.OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserInfo> UserInfoes { get; set; }
        public DbSet<LoggerInfo> LoggerInfoes { get; set; }
        //public DbSet<ENT311Message> ENT311Messages { get; set; }
        public DbSet<custom_order> custom_orders { get; set; }
        public DbSet<custom_order_re> custom_order_res { get; set; }
        public DbSet<PayOrder> PayOrders { get; set; }
        public DbSet<WarehouseInfo> WarehouseInfoes { get; set; }
        public DbSet<payExInfo_DTO> payExInfoes { get; set; }
        public DbSet<AspNetClient> AspNetClients { set; get; }
    }
}
