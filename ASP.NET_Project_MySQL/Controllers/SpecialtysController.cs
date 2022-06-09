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
    public class SpecialtysController : Controller
    {
        // GET: Specialtys
        public ActionResult Index()
        {
            List<SpecialtysModel> specialtys = new List<SpecialtysModel>();
            String cs = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(cs))
            {
                string query = "SELECT * FROM specialtys";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            specialtys.Add(new SpecialtysModel
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
            return View(specialtys);
        }
    }
}