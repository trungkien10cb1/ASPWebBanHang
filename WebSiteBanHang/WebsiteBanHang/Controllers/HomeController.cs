using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Models;
using WebsiteBanHang.Models.DAO;
using WebsiteBanHang.Models.Entities;
using WebsiteBanHang.Models.Bean;
using PagedList;
using PagedList.Mvc;

namespace WebsiteBanHang.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            CategoryDao categoryDao = new CategoryDao();
            ProductsDao productDao = new ProductsDao();
            ShoppingCart Cart = (ShoppingCart)Session["cart"];
            if (Cart == null)
            {
                Session["cart"] = new ShoppingCart();
            }
            IndexData data = new IndexData {
                listCategory = categoryDao.GetCategory(),
                featuredProducts = productDao.GetFeaturedProducts(),
                lastestProducts = productDao.GetLastestProducts()
            };
            return View(data);
        }

        public ActionResult Products(string type, int? page)
        {
            ViewBag.kieu = type;
            CategoryDao categoryDao = new CategoryDao();
            ProductsDao productDao = new ProductsDao();
            IQueryable<Product> list = productDao.GetProducts(type);
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            IPagedList<Product> a = list.ToPagedList(pageNumber, pageSize);
            IndexData data = new IndexData
            {
                listCategory = categoryDao.GetCategory(),
                listProductsType = a
            };

            //return View(list.ToPagedList(pageNumber, pageSize));
            return View(data);
        }

        public ActionResult ProductsDetail(string ma)
        {
            CategoryDao categoryDao = new CategoryDao();
            ProductsDao productDao = new ProductsDao();

            IndexData data = new IndexData
            {
                listCategory = categoryDao.GetCategory(),
                productsDetail = productDao.GetProductDetail(ma)

            };
            return View(data);
        }
       
        public ActionResult ProductSearch(string key, int? page)
        {
            //ViewBag.chuoi = temp;
            CategoryDao categoryDao = new CategoryDao();
            ProductsDao productDao = new ProductsDao();
            List<Product> list = productDao.SearchProduct(key);
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            IPagedList<Product> a = list.ToPagedList(pageNumber, pageSize);
            IndexData data = new IndexData
            {
                listCategory = categoryDao.GetCategory(),
                listProductsType = a
            };
            return View(data);
        }

        public ActionResult ProductsPromosion()
        {
            CategoryDao categoryDao = new CategoryDao();
            IndexData data = new IndexData
            {
                listCategory = categoryDao.GetCategory()
            };
            return View(data);
        }

        public ActionResult Contact()
        {
            CategoryDao categoryDao = new CategoryDao();
            IndexData data = new IndexData()
            {
                listCategory = categoryDao.GetCategory()
            };
            return View(data);
        }
        //public List<Product> getProducts(string type)
        //{
        //    List<Product> list = new List<Product>();
        //    Product product;
        //    for(int i=0; i<6; i++)
        //    {
        //        product = new Product();
        //        product.Id = i;
        //        product.Name = "Laptop " + type + " "+(i + 1);
        //        product.Price = "10.000.000";
        //        product.Details = "Intel Core i5/4GB/500GB/7200rpm";
        //        product.UriImage = "/Content/themes/images/products/" + (i + 1) + ".jpg";
        //        product.Type = type;
        //        list.Add(product);
        //    }
        //    return list;
        //}

        //public List<Product> getLastestProducts()
        //{
        //    List<Product> list = new List<Product>();
        //    Product product;
        //    for(int i=0; i<6; i++)
        //    {
        //        product = new Product();
        //        product.Id = i;
        //        product.Name = "Laptop " + (i + 1);
        //        product.Price = "20.000.000";
        //        product.Details = "Intel Core i5/4GB/500GB/7200rpm";
        //        product.UriImage = "/Content/themes/images/products/"+(i+1)+".jpg";
        //        product.Type = "LASTPROD";
        //        list.Add(product);
        //    }
        //    return list;
        //}

        //public List<List<Product>> getFeaturedProducts()
        //{
        //    List<Product> list = new List<Product>();
        //    List<List<Product>> listFeatured = new List<List<Product>>();
        //    Product product;
        //    for (int i = 0; i < 16; i++)
        //    {
        //        product = new Product();
        //        product.Id = i;
        //        product.Name = "Laptop " + (i + 1);
        //        product.Price = "20.000.000";
        //        product.Details = "Intel Core i5/4GB/500GB/7200rpm";
        //        product.UriImage = "/Content/themes/images/products/" + (i + 1) + ".jpg";
        //        product.Type = "FEATPROD";
        //        list.Add(product);
        //        if(i==3 || i==7 || i==11 || i == 15)
        //        {
        //            listFeatured.Add(list);
        //            list = new List<Product>();
        //        }
        //    }
        //    return listFeatured;
        //}
        //public List<Category> getCategory()
        //{
        //    List<Category> list = new List<Category>();
        //    List<SubCategory> subList = new List<SubCategory>();
        //    subList.Add(new SubCategory { subCateName = "Laptop Dell", subCateQuantity = 30, subCateType="DELL" });
        //    subList.Add(new SubCategory { subCateName = "Laptop HP", subCateQuantity = 30, subCateType="HP" });
        //    subList.Add(new SubCategory { subCateName = "Laptop Lenovo", subCateQuantity = 20, subCateType="LENOVO" });
        //    subList.Add(new SubCategory { subCateName = "Laptop Asus", subCateQuantity = 20, subCateType="ASUS" });
        //    list.Add(new Category { categoryName="LAPTOP PHỔ THÔNG", categoryQuantity=100, listSubCate=subList});
        //    subList = new List<SubCategory>();
        //    subList.Add(new SubCategory { subCateName = "Laptop Dell workstation", subCateQuantity = 20, subCateType="DELLWORK" });
        //    subList.Add(new SubCategory { subCateName = "Laptop HP workstation", subCateQuantity = 12, subCateType="HPWORK" });
        //    subList.Add(new SubCategory { subCateName = "Laptop ThinkPad workstation", subCateQuantity = 20, subCateType="THINKWORK" });
        //    subList.Add(new SubCategory { subCateName = "Laptop MSI workstation", subCateQuantity = 20, subCateType="MSIWORK" });
        //    list.Add(new Category { categoryName = "LAPTOP WORKSTATION", categoryQuantity = 50, listSubCate = subList });
        //    subList = new List<SubCategory>();
        //    subList.Add(new SubCategory { subCateName = "Laptop MSI Gaming", subCateQuantity = 20, subCateType="MSIGAME" });
        //    subList.Add(new SubCategory { subCateName = "Laptop Dell Alienware", subCateQuantity = 20, subCateType = "DELLGAME" });
        //    subList.Add(new SubCategory { subCateName = "Laptop Asus ROG", subCateQuantity = 20, subCateType = "ASUSGAME" });
        //    subList.Add(new SubCategory { subCateName = "Laptop HP Gaming", subCateQuantity = 20, subCateType="HPGAME" });
        //    subList.Add(new SubCategory { subCateName = "Laptop Lenovo Gaming", subCateQuantity = 20, subCateType="LENOVOGAME" });
        //    list.Add(new Category { categoryName = "LAPTOP GAMING", categoryQuantity = 150, listSubCate = subList });
        //    subList = new List<SubCategory>();
        //    subList.Add(new SubCategory { subCateName = "Laptop HP Elitebook", subCateQuantity = 20, subCateType="HPBUSI" });
        //    subList.Add(new SubCategory { subCateName = "Laptop Dell Latitude", subCateQuantity = 20, subCateType="DELLBUSI" });
        //    subList.Add(new SubCategory { subCateName = "Laptop Lenovo ThinkPad", subCateQuantity = 20, subCateType="LENOVOBUSI" });
        //    list.Add(new Category { categoryName = "LAPTOP BUSINESS", categoryQuantity = 50, listSubCate = subList });
        //    return list;
        //}
    }
}