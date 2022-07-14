using ASP.NET_Project_MySQL.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ASP.NET_Project_MySQL.Models.DataAccess;
using ASP.NET_Project_MySQL.Models;



namespace ASP.NET_Project_MySQL.Controllers
{
    public class AcademicsController : Controller
    {
        MySqlConnection con;
        Academic sql = new Academic();
        // GET: Academics
        public ActionResult Index()
        {
            //ViewBag.Message("Academic List");
            var data = sql.loadAcademic();
            List<AcademicsModel> academics = new List<AcademicsModel>();

            foreach (var row in data)
            {
                academics.Add(new AcademicsModel
                {
                    id = row.id,
                    namekh = row.namekh,
                    nameen = row.nameen
                }) ;
            }

            return View(academics);
            

        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(AcademicsModel models)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    //if (!IsUserExist(models.id))
                    //{
                        sql.Insert_Academic(models.id, models.namekh, models.nameen);
                        FormsAuthentication.SetAuthCookie(models.id, false);

                         return RedirectToAction("create", "academics");

                              //string query = "insert into academics values (@id,@namekh,@nameen)";
                              //using (MySqlCommand cmd = new MySqlCommand(query, con))
                              //{
                              //    cmd.Connection = con;

                    //    cmd.Parameters.AddWithValue("@id", AcademicsModel.id);
                    //    cmd.Parameters.AddWithValue("@namekh", AcademicsModel.namekh);
                    //    cmd.Parameters.AddWithValue("@nameen", AcademicsModel.nameen);


                    //    con.Open();
                    //    int i = cmd.ExecuteNonQuery();
                    //    con.Close();


                    //    if (i > 0)
                    //    {
                    //        FormsAuthentication.SetAuthCookie(AcademicsModel.id, false);

                    //        return RedirectToAction("register", "Academics");
                    //    }
                    //    else
                    //    {
                    //        ModelState.AddModelError("", "something went wrong try later!");
                    //    }
                    //    //}
                    //}
                    //else
                    //{
                    //    ModelState.AddModelError("", "Academics with same id already exist!");
                    //}

                }
                else
                {
                    ModelState.AddModelError("", "Data is not correct");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private bool IsUserExist(string id)
        {
            bool IsUserExist = false;
            String cs = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (con = new MySqlConnection(cs))
            {
                string query = "select * from academics where id=@id";
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@id", id);

                    //da = new MySqlDataAdapter(cmd,con);
                    //dt = new DataTable();
                    //da.Fill(dt);
                    //con.Open();
                    //int i = cmd.ExecuteNonQuery();

                    MySqlDataReader dr = cmd.ExecuteReader();


                    //con.Close();
                    //if (dt.Rows.Count > 0)
                    if (dr.HasRows)
                    {
                        IsUserExist = true;
                    }
                }
                return IsUserExist;
            }
        }
        // GET: Bind controls to Update details      
        public ActionResult Edit(string id)
        {
            Academic academics = new Academic();
            return View(academics.loadAcademic().Find(Academic => Academic.id == id));

        }

        //// POST:Update the details into database      
        [HttpPost]
        public ActionResult Edit(string id, AcademicsModel models)
        {
            try
            {
                Academic academics = new Academic();

                academics.Update_Academic(models.id, models.namekh, models.nameen);

                return RedirectToAction("index", "academics");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(string id)
        {
            try
            {
                Academic academics = new Academic();
                if (academics.Delete_Academic(id))
                {
                    ViewBag.AlertMsg = "Employee details deleted successfully";

                }
                return RedirectToAction("index", "academics");
            }
            catch
            {
                return RedirectToAction("index", "academics");
            }
        }
    }
}