using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouTubePlaylists.Data;
using YouTubePlaylists.Models;
using Microsoft.AspNet.Identity;
using System.IO;
using System.Data.Entity;
using YouTubePlaylists.Data.Repositories;

namespace YouTubePlaylists.Web.Account
{
    public partial class Profile : System.Web.UI.Page
    {
        YouTubePlaylistsData data = new YouTubePlaylistsData();
        private Site master;

        // PAGE EVENTS

        protected void Page_Load(object sender, EventArgs e)
        {
            master = this.Master as Site;
        }

        // DATA

        public IQueryable<User> GetData()
        {
            var id = User.Identity.GetUserId();
            var users = data.Users.All().Where(x => x.Id == id);
            return users;
        }

        public void UpdateItem(string id)
        {
            if (!master.isAdmin && id != User.Identity.GetUserId())
            {
                master.ShowErrorMessage("Not authorized.");
                return;
            }

            User user = null;
            user = data.Users.GetById(id);
            if (user == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            TryUpdateModel(user);

            if (ModelState.IsValid)
            {

                data.Users.Update(user);
                data.SaveChanges();
                master.ShowSuccessMessage("Item updated");

                this.DataBind();
            }
        }
    }
}