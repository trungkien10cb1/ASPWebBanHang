using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Models.DAO;
using WebsiteBanHang.Models.Entities;
using WebsiteBanHang.Models.Bean;
using WebsiteBanHang.Models;

namespace WebsiteBanHang.Controllers
{
    public class ShoppingCartController : Controller
    {
        ShopLapModel model = new ShopLapModel();
        // GET: ShoppingCart
        public ActionResult Add(string ma, int soluong)
        {
            ShoppingCart Cart = (ShoppingCart)Session["cart"];
            if (Cart == null)
                Cart = new ShoppingCart();

            ProductsDao dao = new ProductsDao();
            Product pro = dao.FindProduct(ma);
            Cart.AddItem(pro, soluong);

            Session["cart"] = Cart;

            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Sub(string ma, int soluong)
        {
            ShoppingCart Cart = (ShoppingCart)Session["cart"];
            if (Cart == null)
                Cart = new ShoppingCart();

            ProductsDao dao = new ProductsDao();
            Product pro = dao.FindProduct(ma);
            Cart.SubItem(pro, soluong);

            Session["cart"] = Cart;

            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult List()
        {
            CategoryDao categoryDao = new CategoryDao();
            ShoppingCart Cart = (ShoppingCart)Session["cart"];
            List<ItemCart> listItem = new List<ItemCart>();
            IndexData data = new IndexData();
            data.listCategory = categoryDao.GetCategory();
            if (Cart != null)
            {
                data.listItemCart = Cart.listItem;
            }
            else
            {
                data.listItemCart = listItem;
                Session["cart"] = new ShoppingCart();
            }

            return View(data);
        }

        public ActionResult UpdateAmount()
        {
            return View();
        }

        public ActionResult Delete(string ma)
        {
            ShoppingCart Cart = (ShoppingCart)Session["cart"];
            if (Cart != null)
                Cart.Delete(ma);
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult DatHang()
        {
            CategoryDao categoryDao = new CategoryDao();
            ShoppingCart Cart = (ShoppingCart)Session["cart"];
            List<ItemCart> listItem = new List<ItemCart>();
            IndexData data = new IndexData();
            data.listCategory = categoryDao.GetCategory();
            if (Cart != null)
            {
                data.listItemCart = Cart.listItem;
            }
            else
            {
                data.listItemCart = listItem;
                Session["cart"] = new ShoppingCart();
            }

            return View(data);
        }

        //[HttpPost]
        //public ActionResult ActionPayment(string shipName, string shipMobile, string shipAddress, string shipEmail)
        //{
        //    var order = new Order();
        //    order.ngaytao = DateTime.Now;
        //    order.shipName = shipName;
        //    order.shipMobile = shipMobile;
        //    order.shipAddress = shipAddress;
        //    order.shipEmail = shipEmail;

        //    try
        //    {
        //        var ma = new OrderDao().Insert(order);
        //        var detailDao = new OrderDetailDao();
        //        var productDao = new ProductsDao();
        //        CategoryDao categoryDao = new CategoryDao();
        //        ShoppingCart Cart = (ShoppingCart)Session["cart"];
        //        List<ItemCart> listItem = new List<ItemCart>();
        //        IndexData data = new IndexData();
        //        data.listCategory = categoryDao.GetCategory();

        //        if (Cart != null)
        //        {
        //            data.listItemCart = Cart.listItem;
        //            foreach (var item in data.listItemCart)
        //            {
        //                var orderDetail = new OrderDetail();
        //                orderDetail.masanpham = item.Product.ma;
        //                orderDetail.madathang = ma;
        //                orderDetail.dongia = item.Product.dongia;
        //                orderDetail.soluong = item.soluong;
        //                item.Product.soluong = item.Product.soluong - item.soluong;

        //                detailDao.Insert(orderDetail);
        //                productDao.EditProduct(item.Product);
        //            }
        //        }
        //        else
        //        {
        //            data.listItemCart = listItem;
        //            Session["cart"] = new ShoppingCart();
        //            foreach (var item in data.listItemCart)
        //            {
        //                var orderDetail = new OrderDetail();
        //                orderDetail.masanpham = item.Product.ma;
        //                orderDetail.madathang = ma;
        //                orderDetail.dongia = item.Product.dongia;
        //                orderDetail.soluong = item.soluong;

        //                item.Product.soluong = item.Product.soluong - item.soluong;

        //                detailDao.Insert(orderDetail);
        //            }
        //        }

        //    }
        //    catch
        //    {

        //    }

        //    return RedirectToAction("Index", "Home");
        //}
        [HttpPost]
        public ActionResult DatHang(string shipName, string shipMobile, string shipAddress, string shipEmail)
        {
            if (Session["cart"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            //Thêm chi tiết vào giỏ hàng
            Customer cus = new Customer();
            Customer test = model.Customers.SingleOrDefault(x => x.shipName == shipName && x.shipMobile == shipMobile && x.shipAddress == shipAddress && x.shipEmail == shipEmail);
            if (test != null)
            {
                cus.makhachhang = test.makhachhang;
                cus.shipName = test.shipName;
                cus.shipMobile = test.shipMobile;
                cus.shipAddress = test.shipAddress;
                cus.shipEmail = test.shipEmail;
            }
            else
            {
                cus.shipName = shipName;
                cus.shipMobile = shipMobile;
                cus.shipAddress = shipAddress;
                cus.shipEmail = shipEmail;
                model.Customers.Add(cus);
                model.SaveChanges();
            }
            ShoppingCart Cart = (ShoppingCart)Session["cart"];
            Order order = new Order();
            order.ngaydathang = DateTime.Now;
            order.ngaygiaohang = DateTime.Now;
            order.status = "Đang giao hang";
            order.makhachhang = cus.makhachhang;
            model.Orders.Add(order);
            model.SaveChanges();
            CategoryDao categoryDao = new CategoryDao();
            List<ItemCart> listItem = new List<ItemCart>();
            IndexData data = new IndexData();
            data.listCategory = categoryDao.GetCategory();

            if (Cart != null)
            {
                data.listItemCart = Cart.listItem;
                foreach (var item in data.listItemCart)
                {
                    OrderDetail detail = new OrderDetail();
                    detail.madathang = order.ma;
                    detail.masanpham = item.Product.ma;
                    detail.soluong = item.soluong;
                    detail.dongia = item.Product.dongia;
                    Product sp = model.Products.Find(detail.masanpham);
                    sp.soluong = sp.soluong - item.soluong;
                    SubCategory subcategory = model.SubCategories.Find(sp.producttype);
                    subcategory.soluong = subcategory.soluong - item.soluong;
                    Category category = model.Categories.Find(subcategory.danhmucma);
                    category.soluong = category.soluong - item.soluong;
                    model.OrderDetails.Add(detail);
                    model.SaveChanges();
                }
                ViewData["DonHang"] = order;
            }

            return View(data);
        }
    }
}