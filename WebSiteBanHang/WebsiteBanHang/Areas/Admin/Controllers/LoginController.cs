using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Areas.Admin.Models;
using WebsiteBanHang.Models.DAO;
using System.Web.Security;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginAction(Account acc)
        {
            UserDao dao = new UserDao();
            bool check = dao.Login(acc.username, acc.password);
            if (check)
            {
                Session["username"] = acc.username;
                return RedirectToAction("ProductManager", "HomeAd");
            }else
            {
                return RedirectToAction("Login", "Login");
            }
            
        }
    }
}