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
    public class CategoryManagerController : Controller
    {
        public ShopLapModel model;
        public CategoryDao dao;
        public static Guid madanhmuc;

        public ActionResult Create()
        {
            model = new ShopLapModel();
            
            return View();
        }

        public ActionResult AddCategory(Category category)
        {
            dao = new CategoryDao();
            bool check = dao.AddCategory(category);
            if (check)
            {
                return RedirectToAction("CategoryManager", "HomeAd");
            }else
            {
                return JavaScript("<script>alert('Thêm không thành công')</script>");
            }
            
        }

        public ActionResult Edit(Guid id)
        {
            dao = new CategoryDao();
            Category category = dao.FindCategory(id);
            return View(category);
        }

        public ActionResult EditCategory(Category category)
        {
            dao = new CategoryDao();
            bool check = dao.EditCategory(category);
            if (check)
            {
                return RedirectToAction("CategoryManager", "HomeAd");
            }
            else
            {
                return JavaScript("<script>alert('Sửa không thành công')</script>");
            }
        }

        public ActionResult Delete(Guid id)
        {
            dao = new CategoryDao();
            bool check = dao.DeleteCategory(id);
            if (check)
            {
                return RedirectToAction("CategoryManager", "HomeAd");
            }
            else
            {
                return JavaScript("<script>alert('Xóa không thành công')</script>");
            }
        }

        public ActionResult Details(Guid ma, int? page)
        {
            madanhmuc = ma;
            ViewBag.madanhmuc = madanhmuc;
            dao = new CategoryDao();
            IQueryable<SubCategory> subCategories = dao.GetSubCategory(ma);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            IPagedList<SubCategory> a = subCategories.ToPagedList(pageNumber, pageSize);
            return View(a);
        }

        public ActionResult CreateSubCategory()
        {
            model = new ShopLapModel();
            ViewBag.madanhmuc = madanhmuc;
            dao = new CategoryDao();
            Category cate = dao.FindCategory(madanhmuc);
            ViewBag.tendanhmuc = cate.tendanhmuc;
            return View();
        }

        public ActionResult AddSubCategory(SubCategory subCategory)
        {
            //subCategory.danhmucma = new Guid(Request.Form["Danhmuc"].ToString());
            dao = new CategoryDao();
            subCategory.danhmucma = madanhmuc;

            bool check = dao.AddSubCategory(subCategory);
            if (check)
            {
                return RedirectToAction("Details", "CategoryManager", new { ma = madanhmuc });
            }else
            {
                return JavaScript("<script>alert('Thêm không thành công')</script>");
            }
        }

        public ActionResult EditSubCategory(string ma)
        {
            dao = new CategoryDao();
            SubCategory subCate = dao.FindSubCategory(ma);
            model = new ShopLapModel();
            SelectList selectList = new SelectList(model.Categories.ToList().OrderBy(x => x.ma), "ma", "tendanhmuc");
            ViewBag.Danhmuc = selectList;
            
            return View(subCate);
        }

        public ActionResult ReSubCategory(SubCategory subCategory)
        {
            SelectList selectList = (SelectList) ViewBag.Danhmuc;

            subCategory.danhmucma = subCategory.Category.ma;
            dao = new CategoryDao();
            bool check = dao.EditSubCategory(subCategory);
            if (check)
            {
                return RedirectToAction("Details", "CategoryManager", new { ma = madanhmuc });
            }
            else
            {
                
                return JavaScript("<script>alert('Sửa không thành công')</script>");
            }

        }

        public ActionResult DeleteSubCategory(string ma)
        {
            dao = new CategoryDao();
            bool check = dao.DeleteSubCategory(ma);
            if (check)
            {
                return RedirectToAction("Details", "CategoryManager", new { ma = madanhmuc });
            }
            else
            {
                return JavaScript("<script>alert('Xóa không thành công')</script>");
            }
        }
    }
}