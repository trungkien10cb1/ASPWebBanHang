using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanHang.Models.Entities;

namespace WebsiteBanHang.Models.DAO
{
    public class CustomerDao
    {
        ShopLapModel model;
        public CustomerDao()
        {
            model = new ShopLapModel();
        }
        public IQueryable<Customer> GetCustomer()
        {
            var rs = (from s in model.Customers
                      orderby s.makhachhang ascending
                      select s);
            return rs;
        }

        public bool EditCustomer(Customer customer)
        {
            Customer cts = model.Customers.Find(customer.makhachhang);
            try
            {
                cts.shipName = customer.shipName;
                cts.shipMobile = customer.shipMobile;
                cts.shipAddress = customer.shipAddress;
                cts.shipEmail = customer.shipEmail;
                model.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Customer FindCustomer(int ma)
        {
            Customer customer = model.Customers.Find(ma);
            return customer;
        }
    }
}