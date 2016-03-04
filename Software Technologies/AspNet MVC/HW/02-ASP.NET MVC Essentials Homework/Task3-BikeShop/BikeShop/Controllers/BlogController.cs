using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BikeShop.Models;

namespace BikeShop.Controllers
{
    public class BlogController : Controller
    {
        IList<ArticleViewModel> data = new List<ArticleViewModel>();

        public BlogController()
        {
            for (int i = 0; i < 20; i++)
            {
                this.data.Add(new ArticleViewModel() {Id = i, Title = $"Article {i}", Content = $"Article {i} content..." });
            }
        }

        // GET: Blog
        public ActionResult Index()
        {
            return View(data);
        }

        public ActionResult Article(int id)
        {
            return View(data[id]);
        }
    }
}