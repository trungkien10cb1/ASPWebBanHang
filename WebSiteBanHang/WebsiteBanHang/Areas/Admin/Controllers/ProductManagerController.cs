using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Models.DAO;
using WebsiteBanHang.Models.Entities;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class ProductManagerController : Controller
    {
        public ShopLapModel model;
        public ProductsDao dao;
        public static Product pro;
        public ActionResult Create()
        {
            model = new ShopLapModel();
            ViewBag.Dongmay = new SelectList(model.SubCategories.ToList().OrderBy(x => x.mahienthi), "mahienthi", "tendanhmuccon");
            return View();
        }

        public ActionResult AddDetail(Product product, HttpPostedFileBase imgFile)
        {
            var filename = Path.GetFileName(imgFile.FileName);
            var path = Path.Combine(Server.MapPath("~/Content/themes/images/products/"), filename);
            imgFile.SaveAs(path);
            string imgLink = "/Content/themes/images/products/" + filename;
            product.imglink = imgLink;
            pro = product;
            return View(product);
        }

        public ActionResult AddProduct(Product product)
        {
            ProductDetail productDetail = product.ProductDetail;
            productDetail.masanpham = pro.ma;
            pro.ProductDetail = productDetail;
            dao = new ProductsDao();
            bool check = dao.AddProduct(pro);
            if (check)
            {
                return RedirectToAction("ProductManager", "HomeAd");
            }
            else
            {
                return JavaScript("<script>alert(\"Mã sản phẩm đã tồn tại\")</script>");
            }
        }

        public ActionResult Edit(string id)
        {
            model = new ShopLapModel();
            Product product = model.Products.Find(id);
            pro = product;
            ViewBag.Dongmay = new SelectList(model.SubCategories.ToList().OrderBy(x => x.mahienthi), "mahienthi", "tendanhmuccon");
            return View(product);
        }

        public ActionResult EditDetail(Product product, HttpPostedFileBase imgFile)
        {
            if(imgFile != null)
            {
                var filename = Path.GetFileName(imgFile.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/themes/images/products/"), filename);
                imgFile.SaveAs(path);
                string imgLink = "/Content/themes/images/products/" + filename;
                product.imglink = imgLink;
            }else
            {
                product.imglink = pro.imglink;
            }
            
            //product.producttype = Request.Form["Dongmay"].ToString();
            product.ProductDetail = pro.ProductDetail;
            pro = product;
            return View(product);
        }

        public ActionResult EditProduct(Product product)
        {
            ProductDetail productDetail = product.ProductDetail;
            productDetail.masanpham = pro.ma;
            pro.ProductDetail = productDetail;
            dao = new ProductsDao();
            bool check = dao.EditProduct(pro);
            if (check)
            {
                return RedirectToAction("ProductManager", "HomeAd");
            }
            else
            {
                return JavaScript("<script>alert(\"Sửa không thành công\")</script>");
            }
        }

        public ActionResult Delete(string id)
        {
            dao = new ProductsDao();
            bool check = dao.DeleteProduct(id);
            if (check)
            {
                return RedirectToAction("ProductManager", "HomeAd");
            }else
            {
                return JavaScript("<script>alert(\"Xóa không thành công\")</script>");
            }
        }
    }
}