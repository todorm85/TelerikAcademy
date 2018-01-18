﻿using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using YouTubePlaylists.Data;
using YouTubePlaylists.Models;

namespace YouTubePlaylists.Web.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();

            var user = new User()
            {
                UserName = Email.Text,
                Email = Email.Text,
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                ImageUrl = ImageUrl.Text ?? "http://i2.mirror.co.uk/incoming/article6379795.ece/ALTERNATES/s615b/Minion.jpg",
                YouTubeUrl = YouTube.Text,
                FacebookUrl = Facebook.Text
            };

            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {

                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                Response.Redirect("~/");
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}