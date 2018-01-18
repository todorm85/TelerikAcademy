using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleTwitter.Data.Models;
using SimpleTwitter.Web.Models.Tweet;
using Microsoft.AspNet.Identity;
using System.Text.RegularExpressions;
using SimpleTwitter.Data.Repositories;
using SimpleTwitter.Data.Contracts;

namespace SimpleTwitter.Web.Controllers
{
    [Authorize]
    public class TweetController : Controller
    {
        ISimpleTwitterData data;

        public TweetController()
        {
            data = new SimpleTwitterData();
        }

        [AllowAnonymous]
        [OutputCache(Duration =15*60, VaryByParam ="none")]
        public ActionResult Index()
        {
            var tweets = data.Tweets.All()
                .OrderByDescending(x => x.Id)
                .Take(10);

            return View(tweets);
        }

        [HttpPost]
        [AllowAnonymous]
        [OutputCache(Duration = 15 * 60, VaryByParam = "query")]
        public ActionResult Index(string query)
        {
            if (query == null || query == "")
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Query = query;
            var tweets = new HashSet<Tweet>().AsQueryable();
            var tag = data.HashTags.All().FirstOrDefault(x => x.Name == "#" + query);
            if (tag != null)
            {
                tweets = tag.Tweets.AsQueryable();
            }

            return View(tweets);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TweetInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }

            var text = model.Content;
            var tweet = new Tweet()
            {
                AuthorId = this.User.Identity.GetUserId(),
                Content = text,
            };

            string hashRegex = @"(?<=\s|^)#(\w*[A-Za-z_]+\w*)";
            MatchCollection hashes = Regex.Matches(text, hashRegex);
            foreach (Match item in hashes)
            {
                var hashTagValue = item.Value;

                var hashTag = data.HashTags.All().FirstOrDefault(x => x.Name == hashTagValue);
                if (hashTag == null)
                {
                    hashTag = new HashTag()
                    {
                        Name = hashTagValue
                    };
                }

                tweet.HashTags.Add(hashTag);
            }

            data.Tweets.Add(tweet);
            data.SaveChanges();

            return RedirectToAction(nameof(MyTweets));
        }

        public ActionResult MyTweets()
        {
            var userId = User.Identity.GetUserId();
            var tweets = data.Tweets.All().Where(x => x.AuthorId == userId);
            return View(tweets);
        }
    }
}