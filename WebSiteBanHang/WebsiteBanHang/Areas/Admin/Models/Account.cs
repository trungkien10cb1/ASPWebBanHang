using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteBanHang.Areas.Admin.Models
{
    public class Account
    {
        public string username { get; set; }
        public string password { get; set; }
        public bool remember { get; set; }
    }
}