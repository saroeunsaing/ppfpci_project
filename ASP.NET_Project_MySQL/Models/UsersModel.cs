using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_Project_MySQL.Models
{
    public class UsersModel
    {
        public string id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
    }
}