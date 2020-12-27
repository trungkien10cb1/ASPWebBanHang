using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanHang.Models.Entities;

namespace WebsiteBanHang.Models.Bean
{
    public class ItemCart
    {
        public Product Product { get; set; }
        public int soluong { get; set; }

        public double GetTotal()
        {
            return soluong * (double) Product.dongia;
        }
    }
}