using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouTubePlaylists.Data.Repositories;
using Microsoft.AspNet.Identity;
using YouTubePlaylists.Models;

namespace YouTubePlaylists.Web.Playlists
{
    public partial class Playlist : System.Web.UI.Page
    {
        YouTubePlaylistsData data = new YouTubePlaylistsData();
        private Site master;

        protected void Page_Load(object sender, EventArgs e)
        {
            master = this.Master as Site;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!Context.User.Identity.IsAuthenticated)
            {
                this.btnCreate.Visible = false;
                var btnEdit = this.FormViewPlaylist.FindControl("ButtonEdit");
                if (btnEdit != null)
                {
                    btnEdit.Visible = false;
                }
                var btnDelete = this.FormViewPlaylist.FindControl("ButtonDelete");
                if (btnDelete != null)
                {
                    btnDelete.Visible = false;
                }
            }
        }


        public YouTubePlaylists.Models.Playlist FormViewPlaylist_GetItem([QueryString("id")]int? id)
        {
            return data.Playlists.GetById(id);
        }

        public IQueryable<Models.Category> DropDownListCategories_GetData()
        {
            return data.Categories.All();
        }

        public void FormViewPlaylist_InsertItem()
        {
            var playlist = new YouTubePlaylists.Models.Playlist();

            TryUpdateModel(playlist);

            playlist.CreatorId = Context.User.Identity.GetUserId();

            var tbVideoUrls = (TextBox)FormViewPlaylist.FindControl("tbVideoUrls");
            if (tbVideoUrls != null)
            {
                var videoUrls = tbVideoUrls.Text.Split(' ');
                foreach (var url in videoUrls)
                {
                    var video = new Video
                    {
                        Url = url
                    };

                    playlist.Videos.Add(video);
                }
            }

            try
            {
                data.Playlists.Add(playlist);
                data.SaveChanges();
                master.ShowSuccessMessage("Playlist added.");
                Response.Redirect("/Playlists/Playlist.aspx?id=" + playlist.Id);
            }
            catch (Exception e)
            {
                master.ShowErrorMessage("Playlist not added. Invalid data.");
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void FormViewPlaylist_DeleteItem(int id)
        {
            var item = data.Playlists.GetById(id);
            if (item == null)
            {
                master.ShowErrorMessage("Not found.");
                return;
            }

            if (item.CreatorId != Context.User.Identity.GetUserId())
            {
                master.ShowErrorMessage("NOT AUTHORIZED! Not your playlist.");
                return;
            }

            data.Playlists.Delete(item);
            data.SaveChanges();
            master.ShowSuccessMessage("Item deleted.");
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            this.FormViewPlaylist.ChangeMode(FormViewMode.Insert);
        }

        protected void RemoveVideo_Click(object sender, EventArgs e)
        {
            var lb = (ListBox)FormViewPlaylist.FindControl("ListBoxEditVideos");
            var itemsToRemove = new List<ListItem>();
            foreach (ListItem item in lb.Items)
            {
                if (item.Selected)
                {
                    itemsToRemove.Add(item);
                }
            }

            foreach (var item in itemsToRemove)
            {
                lb.Items.Remove(item);
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void FormViewPlaylist_UpdateItem(int id)
        {
            var item = data.Playlists.GetById(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            if (item.CreatorId != Context.User.Identity.GetUserId())
            {
                master.ShowErrorMessage("NOT AUTHORIZED! Not your playlist.");
                return;
            }

            TryUpdateModel(item);

            if (ModelState.IsValid)
            {
                item.Videos.Clear();
                var lbVideos = (ListBox)FormViewPlaylist.FindControl("ListBoxEditVideos");
                foreach (ListItem ev in lbVideos.Items)
                {
                    var vidId = int.Parse(ev.Value);
                    var videoToAdd = data.Videos.GetById(vidId);
                    item.Videos.Add(videoToAdd);
                }

                data.SaveChanges();
                master.ShowSuccessMessage("Updated!");
            }
        }
    }
}