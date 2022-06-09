using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_Project_MySQL.Controllers
{
    public class ScoresController : Controller
    {
        // GET: Scores
        public ActionResult Index()
        {
            return View();
        }
    }
}