using ASP.NET_Project_MySQL.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_Project_MySQL.Controllers
{
    public class YearsController : Controller
    {
        // GET: Years
        public ActionResult Index()
        {
            List<YearsModel> years = new List<YearsModel>();
            String cs = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(cs))
            {
                string query = "SELECT * FROM years";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            years.Add(new YearsModel
                            {
                                id = dr["id"].ToString(),
                                namekh = dr["namekh"].ToString(),
                                nameen = dr["nameen"].ToString(),

                            });
                        }
                    }
                    con.Close();
                }
            }
            return View(years);
        }
    }
}