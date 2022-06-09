using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using System.Configuration;
using ASP.NET_Project_MySQL.Models;

namespace ASP.NET_Project_MySQL.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            List<UsersModel> users = new List<UsersModel>();
            String cs = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(cs))
            {
                string query = "SELECT * FROM Users";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using(MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while(dr.Read())
                        {
                            users.Add(new UsersModel
                            {
                                id = dr["id"].ToString(),
                                username = dr["username"].ToString(),
                                password = dr["password"].ToString(),
                                role = dr["role"].ToString()
                            }) ;
                        }
                    }
                    con.Close();
                }
            }
                return View(users);
        }
    }
}