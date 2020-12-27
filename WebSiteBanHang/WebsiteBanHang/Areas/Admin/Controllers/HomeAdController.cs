using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Models.DAO;
using WebsiteBanHang.Models.Entities;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class HomeAdController : Controller
    {
        // GET: Admin/HomeAd
        public ActionResult Index()
        {
            if(Session["username"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }

        public ActionResult ProductManager(int? page)
        {
            ProductsDao dao = new ProductsDao();
            IQueryable<Product> list = dao.GetAllProduct();
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            IPagedList<Product> a = list.ToPagedList(pageNumber, pageSize);
            return View(a);
        }

        public ActionResult CategoryManager(int? page)
        {
            CategoryDao dao = new CategoryDao();
            IQueryable<Category> lisCate = dao.GetCategory();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            IPagedList<Category> a = lisCate.ToPagedList(pageNumber, pageSize);
            return View(a);
        }

        public ActionResult CustomerManager(int? page)
        {
            CustomerDao dao = new CustomerDao();
            IQueryable<Customer> listCus = dao.GetCustomer();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            IPagedList<Customer> a = listCus.ToPagedList(pageNumber, pageSize);
            return View(a);
        }

        public ActionResult OrderManager(int? page)
        {
            OrderDao dao = new OrderDao();
            IQueryable<Order> list = dao.GetDataOrder();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            IPagedList<Order> a = list.ToPagedList(pageNumber, pageSize);
            return View(a);
        }
    }
}