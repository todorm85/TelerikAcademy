using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspMvc.Models;

namespace AspMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Calculate(Numbers nums)
        {
            ViewBag.FirstNumber = nums.FirstNumber;
            ViewBag.SecondNumber = nums.SecondNumber;
            ViewBag.Result = nums.FirstNumber + nums.SecondNumber;
            return View("index");
        }
    }
}