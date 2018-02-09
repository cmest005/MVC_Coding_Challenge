using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestingTextRead.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Coding Challenge";

            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Carlos Mestre contact info";

            return View();
        }

        
    }
}