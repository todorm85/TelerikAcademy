using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BikeShop.Areas.Shop.Controllers
{
    public class OperationsController : Controller
    {
        // GET: Shop
        public ActionResult Buy()
        {
            return View();
        }

        public ActionResult Sell()
        {
            return View();
        }
    }
}