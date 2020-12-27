using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanHang.Models.Entities;

namespace WebsiteBanHang.Models.Bean
{
    public class ShoppingCart
    {
        public List<ItemCart> listItem = new List<ItemCart>();

        public void AddItem(Product product, int soluong)
        {
            bool check = false;
            foreach(var itemTmp in listItem)
            {
                if (itemTmp.Product.ma == product.ma)
                {
                    check = true;
                    itemTmp.soluong += soluong;
                    break;
                }
            }
            if (!check)
            {
                ItemCart item = new ItemCart();
                item.Product = product;
                item.soluong = soluong;
                listItem.Add(item);
            }
        }

        public void SubItem(Product product, int soluong)
        {
            bool check = false;
            foreach(var itemTmp in listItem)
            {
                if(itemTmp.Product.ma == product.ma)
                {
                    check = true;
                    itemTmp.soluong -= soluong;
                    break;
                }
            }
            if (!check)
            {
                ItemCart item = new ItemCart();
                item.Product = product;
                item.soluong = soluong;
                listItem.Remove(item);
            }
        }

        public void AddAmount(string ma, int soluong)
        {
            foreach(var itemTmp in listItem)
            {
                if(itemTmp.Product.ma == ma)
                {
                    itemTmp.soluong += soluong;
                    break;
                }
            }
        }

        public void SubAmount(string ma, int soluong)
        {
            foreach(var itemTmp in listItem)
            {
                if(itemTmp.Product.ma == ma)
                {
                    itemTmp.soluong -= soluong;
                    break;
                }
            }
        }

        public void Delete(string ma)
        {
            foreach(var itemTmp in listItem)
            {
                if(itemTmp.Product.ma == ma)
                {
                    listItem.Remove(itemTmp);
                    break;
                }
            }
        }

        public double GetTotalCart()
        {
            double total = 0;
            foreach(var itemTmp in listItem)
            {
                total += itemTmp.GetTotal();
            }
            return total;
        }

        public int GetAmount()
        {
            int soluong = 0;
            foreach(var itemTmp in listItem)
            {
                soluong += itemTmp.soluong;
            }
            return soluong;
        }

        public void DeleteAll()
        {
            foreach(var itemTmp in listItem)
            {
                listItem=null;
            }
        }
    }
}