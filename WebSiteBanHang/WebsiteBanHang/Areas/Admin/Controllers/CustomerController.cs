using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Models.DAO;
using WebsiteBanHang.Models.Entities;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        CustomerDao dao;
        public ActionResult Edit(int ma)
        {

            dao = new CustomerDao();
            Customer customer = dao.FindCustomer(ma);

            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            dao = new CustomerDao();
            bool check = dao.EditCustomer(customer);
            if (check)
            {
                return RedirectToAction("CustomerManager", "HomeAd");
            }
            else
            {
                return JavaScript("<script>alert('Sửa không thành công')</script>");
            }
        }
    }
}