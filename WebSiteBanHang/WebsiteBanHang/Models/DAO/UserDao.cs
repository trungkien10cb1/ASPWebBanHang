using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanHang.Models.Entities;

namespace WebsiteBanHang.Models.DAO
{
    public class UserDao
    {
        ShopLapModel model;
        public UserDao()
        {
            model = new ShopLapModel();
        }

        public bool Login(string name, string pass)
        {
            var res = model.Users.Count(x => x.username == name && x.password == pass);
            if (res > 0)
            {
                return true;
            }else
            {
                return false;
            }
            
        }

        public IQueryable<User> ListUser()
        {
            var rs = (from s in model.Users select s);
            return rs;
        }
    }
}