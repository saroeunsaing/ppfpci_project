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
    public class LevelsController : Controller
    {
        // GET: Levels
        public ActionResult Index()
        {
            List<LevelsModel> levels = new List<LevelsModel>();
            String cs = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(cs))
            {
                string query = "SELECT * FROM levels";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            levels.Add(new LevelsModel
                            {
                                id = dr["id"].ToString(),
                                namekh = dr["namekh"].ToString(),
                                nameen = dr["nameen"].ToString(),
                                dep = dr["department"].ToString(),

                            });
                        }
                    }
                    con.Close();
                }
            }
            return View(levels);
        }
    }
}