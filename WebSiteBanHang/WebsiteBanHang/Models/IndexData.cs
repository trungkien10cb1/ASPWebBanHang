////////////////////using System;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanHang.Models.Entities;
using WebsiteBanHang.Models.Bean;

namespace WebsiteBanHang.Models
{
    public class IndexData
    {
        public IQueryable<Category> listCategory { get; set; }
        public IQueryable<Product> lastestProducts { get; set; }
        public List<List<Product>> featuredProducts { get; set; }
        public IPagedList<Product> listProductsType { get; set; }
        public Product productsDetail { get; set; }
        public List<ItemCart> listItemCart { get; set; }
    }
}