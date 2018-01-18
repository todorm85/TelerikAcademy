using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalculator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.TypeLabel = "bit";
            TempData["type"] = "0 bit";
            ViewBag.CalcBit = 1;
            ViewBag.CalcByte = 1 / 8d;
            ViewBag.KiloValue = 1024;
            return View();
        }

        [HttpPost]
        public ActionResult Index(double qt, string type, double kilo)
        {
            if (type == "")
            {
                type = (string)TempData["type"];
            }

            TempData["type"] = type;
            ViewBag.TypeLabel = type.Split(' ')[1];

            var inputParams = type.Split(' ');
            double calcBit;
            double calcByte;
            if (inputParams[1] == "bit")
            {
                calcBit = qt * Math.Pow(kilo, int.Parse(inputParams[0]));
                calcByte = calcBit / 8;
            }
            else
            {
                calcByte = qt * Math.Pow(kilo, int.Parse(inputParams[0]));
                calcBit = calcByte * 8;
            }

            ViewBag.qt = qt;
            ViewBag.CalcBit = calcBit;
            ViewBag.CalcByte = calcByte;
            ViewBag.KiloValue = kilo;

            return View();
        }
    }
}