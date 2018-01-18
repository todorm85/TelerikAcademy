using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouTubePlaylists.Data.Repositories;

namespace YouTubePlaylists
{
	public partial class _Default : Page
	{
        YouTubePlaylistsData data = new YouTubePlaylistsData();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<YouTubePlaylists.Models.Playlist> ListViewPlaylists_GetData()
        {
            return data.Playlists.All().OrderByDescending(x => x.Ratings.Average(r => r.Value)).Take(10);
        }
    }
}