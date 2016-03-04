using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Movies.Data;
using Movies.Web.Models;

namespace Movies.Controllers
{
    public class HomeController : Controller
    {
        SimpleTwitterDbContext data = new SimpleTwitterDbContext();

        public ActionResult Index()
        {
            var movies = data.Movies.Select(MovieViewModel.FromMovie).AsQueryable();
            return View(movies);
        }

        public ActionResult MovieDetails(int id)
        {
            var movie = data.Movies.Find(id);
            Thread.Sleep(2000);
            return this.PartialView("_MovieDetails", movie);
        }
    }
}