using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanHang.Models.Entities;

namespace WebsiteBanHang.Models.DAO
{
    public class OrderDetailDao
    {
        ShopLapModel model;
        public OrderDetailDao()
        {
            model = new ShopLapModel();
        }

        public IQueryable<OrderDetail> ChitietGH(int mahd)
        {
            var res = (from sp in model.OrderDetails where sp.madathang == mahd select sp);
            return res;
        }
    }
}