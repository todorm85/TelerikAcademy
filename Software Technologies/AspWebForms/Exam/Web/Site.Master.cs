using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using YouTubePlaylists.Data;

namespace YouTubePlaylists.Web
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public bool isAuthenticated = false;
        public bool isAdmin = false;
        private YouTubePlaylistsDbContext data = new YouTubePlaylistsDbContext();

        public void ShowSuccessMessage(string message)
        {
            this.success.InnerText = message;
            this.success.Attributes.Remove("hidden");
        }

        public void ShowErrorMessage(string message)
        {
            this.error.InnerText = message;
            this.error.Attributes.Remove("hidden");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Authorize();
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        protected void NavigationMenu_MenuItemDataBound(object sender, MenuEventArgs e)
        {
            if (ShouldRemoveItem(e.Item.Text))
            {
                e.Item.Parent.ChildItems.Remove(e.Item);
            }
        }

        private void Authorize()
        {
            isAuthenticated = Context.User.Identity.IsAuthenticated;

            var userId = Context.User.Identity.GetUserId();
            var user = data.Users.Find(userId);
            if (user != null)
            {
                isAdmin = user.AppRoles.Any(x => x.Name == "Administrator");
            }
        }

        private bool ShouldRemoveItem(string menuText)
        {
            if (menuText == "Profile" && !isAuthenticated)
            {
                return true;
            }

            if (menuText == "All playlists" && !isAuthenticated)
            {
                return true;
            }

            if (menuText == "Categories" && !isAdmin)
            {
                return true;
            }

            if (menuText == "Playlists" && !isAuthenticated)
            {
                return true;
            }
            return false;
        }
    }
}