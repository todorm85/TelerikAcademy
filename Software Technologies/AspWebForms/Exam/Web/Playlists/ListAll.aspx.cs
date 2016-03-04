using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouTubePlaylists.Data.Repositories;

namespace YouTubePlaylists.Web.Playlists
{
    public partial class ListAll : System.Web.UI.Page
    {
        YouTubePlaylistsData data = new YouTubePlaylistsData();
        private Site master;
        private bool changeDirection = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            master = this.Master as Site;
        }

        public SortDirection SortDirection
        {
            get
            {
                SortDirection direction = SortDirection.Ascending;
                if (ViewState["sortdirection"] != null)
                {
                    if ((SortDirection)ViewState["sortdirection"] == SortDirection.Descending &&
                        !this.changeDirection ||
                        (SortDirection)ViewState["sortdirection"] == SortDirection.Ascending &&
                        this.changeDirection)
                    {
                        direction = SortDirection.Descending;
                    }
                }

                ViewState["sortdirection"] = direction;
                return direction;
            }

            set
            {
                ViewState["sortdirection"] = value;
            }
        }

        public IQueryable<YouTubePlaylists.Models.Playlist> ListViewPlaylists_GetData([ViewState("OrderBy")]String OrderBy = null)
        {
            var playlists = this.data.Playlists.All();

            var searchKey = Request.QueryString.Get("searchKey");
            if (searchKey != null)
            {
                playlists = playlists.Where(b => b.Title.IndexOf(searchKey) >= 0 ||
                b.Description.IndexOf(searchKey) >= 0).OrderBy(b => b.Id);
            }

            var categoryFilter = Request.QueryString.Get("category");
            if (categoryFilter != null)
            {
                playlists = playlists.Where(p => p.Category.Name == categoryFilter).OrderBy(b => b.Id);
            }

            if (OrderBy != null)
            {
                switch (this.SortDirection)
                {
                    case SortDirection.Ascending:
                        playlists = playlists.OrderBy(OrderBy);
                        break;

                    case SortDirection.Descending:
                        playlists = playlists.OrderBy(OrderBy + " Descending");
                        break;

                    default:
                        playlists = playlists.OrderBy(OrderBy + " Descending");
                        break;
                }
                return playlists;
            }
            else
            {
                playlists.OrderBy("Id Descending");
            }

            return playlists;
        }

        protected void ListViewPlaylists_Sorting(object sender, ListViewSortEventArgs e)
        {
            e.Cancel = true;
            if (ViewState["OrderBy"] != null &&
                (string)ViewState["OrderBy"] == e.SortExpression)
            {
                this.changeDirection = true;
            }
            else
            {
                this.SortDirection = SortDirection.Ascending;
            }

            ViewState["OrderBy"] = e.SortExpression;
            this.ListViewPlaylists.DataBind();
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            var searchKey = InputTextSearch.Value;
            Response.Redirect($"~/Playlists/ListAll.aspx?searchKey={searchKey}");
        }
    }
}