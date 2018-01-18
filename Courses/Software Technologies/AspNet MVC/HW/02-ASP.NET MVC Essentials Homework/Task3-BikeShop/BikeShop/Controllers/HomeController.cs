using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BikeShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This is a simple bike shop app.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Find us on Vitosha, Bai Krystio.";

            return View();
        }
    }
}