using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Models.DAO;
using WebsiteBanHang.Models.Entities;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        CustomerDao dao;
        static int madonhang;
        public ActionResult Details(int ma)
        {
            madonhang = ma;
            ShopLapModel model = new ShopLapModel();
            Order order = model.Orders.Find(ma);
            ViewBag.giohang = order;
            var rs = from s in model.OrderDetails where s.madathang == order.ma select s;
            return View(rs);
        }

        public ActionResult UpdateStatus()
        {

            ShopLapModel model = new ShopLapModel();
            Order order = model.Orders.Find(madonhang);
            order.status = "Đã nhận hàng và thanh toán";
            int lineChange = model.SaveChanges();
            if (lineChange != 0)
            {
                return RedirectToAction("OrderManager", "HomeAd");
            }else
            {
                return Redirect(Request.UrlReferrer.ToString());
            }
        }
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
                return RedirectToAction("OderController", "HomeAd");
            }
            else
            {
                return JavaScript("<script>alert('Sửa không thành công')</script>");
            }
        }
    }
}