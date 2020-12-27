using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanHang.Models.Entities;

namespace WebsiteBanHang.Models.DAO
{
    public class OrderDao
    {
        ShopLapModel model;
        public OrderDao()
        {
            model = new ShopLapModel();
        }
        public long Insert(Order order)
        {
            model.Orders.Add(order);
            model.SaveChanges();
            return order.ma;
        }

        public IQueryable<Order> GetDataOrder()
        {
            var rs = from s in model.Orders orderby s.ma ascending select s;
            return rs;
        }
    }
}