using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanHang.Models.Entities;
using System.Data.Entity;
namespace WebsiteBanHang.Models.DAO
{
    public class CategoryDao
    {
        ShopLapModel shopLapModel;
        public CategoryDao()
        {
            shopLapModel = new ShopLapModel();
        }

        public IQueryable<Category> GetCategory()
        {
            //List<Category> listCategory = new List<Category>();
            //ICollection<SubCategory> subList = new List<SubCategory>();
            //var rsCate = (from s in shopLapModel.Categories select s);
            //foreach(var category in rsCate)
            //{
            //    var rsSubCate = (from rs in shopLapModel.SubCategories
            //                     where rs.danhmucma == category.ma
            //                     select rs);
            //    subList = new List<SubCategory>();
            //    foreach(var subCate in rsSubCate)
            //    {
            //        subList.Add(subCate);
            //    }
            //    listCategory.Add(category, subList);
            //}
            //return listCategory;
            var data = shopLapModel.Categories.Include(x => x.SubCategories).OrderByDescending(x => x.ma).AsQueryable();
            //var rsCate = (from s in shopLapModel.Categories orderby s.ma ascending select s);
            return data;
        }

        public bool AddCategory(Category category)
        {
            try
            {
                category.ma = Guid.NewGuid();
                category.soluong = 0;
                shopLapModel.Categories.Add(category);
                shopLapModel.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IQueryable<SubCategory> GetSubCategory(Guid ma)
        {
            var rs = (from s in shopLapModel.SubCategories
                      where s.danhmucma == ma
                      orderby s.mahienthi ascending
                      select s);
            return rs;
        }

        public bool EditCategory(Category category)
        {
            Category cate = shopLapModel.Categories.Find(category.ma);
            try
            {
               
                cate.tendanhmuc = category.tendanhmuc;
                cate.soluong = category.soluong;
                shopLapModel.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public bool DeleteCategory(Guid ma)
        {
            Category category = shopLapModel.Categories.Find(ma);
            if(category.SubCategories.Count == 0)
            {
                shopLapModel.Categories.Remove(category);
                shopLapModel.SaveChanges();
                return true;
            }else
            {
                return false;
            }
        }

        public bool AddSubCategory(SubCategory subCate)
        {
            try
            {
                subCate.soluong = 0;
                shopLapModel.SubCategories.Add(subCate);
                shopLapModel.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EditSubCategory(SubCategory subCate)
        {
            SubCategory subCategory = shopLapModel.SubCategories.Find(subCate.mahienthi);

            try
            {
                subCategory.tendanhmuccon = subCate.tendanhmuccon;
                subCategory.soluong = subCate.soluong;
                subCategory.danhmucma = subCate.danhmucma;
                shopLapModel.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteSubCategory(string ma)
        {
            SubCategory subCategory = shopLapModel.SubCategories.Find(ma);
            try
            {
                shopLapModel.SubCategories.Remove(subCategory);
                shopLapModel.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Category FindCategory(Guid ma)
        {
            Category category = shopLapModel.Categories.Find(ma);
            return category;
        }

        public SubCategory FindSubCategory(string ma)
        {
            SubCategory subCategory = shopLapModel.SubCategories.Find(ma);
            return subCategory;
        }

        
    }
}