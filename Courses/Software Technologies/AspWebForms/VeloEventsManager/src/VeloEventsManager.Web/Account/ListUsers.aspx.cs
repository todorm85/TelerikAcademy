﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using VeloEventsManager.Data;
using VeloEventsManager.Models;
using Microsoft.AspNet.Identity;
using System.IO;

namespace VeloEventsManager.Web.Account
{
    public partial class ListUsers : System.Web.UI.Page
    {
        VeloEventsManagerDbContext data = new VeloEventsManagerDbContext();
        private const int PageSize = 5;
        private Site master;

        // PAGE EVENTS

        protected void Page_Load(object sender, EventArgs e)
        {
            master = this.Master as Site;

            if (!IsPostBack)
            {
                ViewState["page"] = 0;
                this.FormViewUserDetails.Visible = false;
            }
        }

        // DATA

        public IQueryable<User> GetData()
        {
            var Users = data.Users.OrderBy(x => x.Id);
            var dateOrder = (string)ViewState["orderByName"];
            if (dateOrder != null && dateOrder == "asc")
            {
                Users = Users.OrderBy(x => x.UserName);
            }
            else if (dateOrder != null && dateOrder == "des")
            {
                Users = Users.OrderByDescending(x => x.UserName);
            }

            int page = (int)ViewState["page"];
            return Users.Skip(PageSize * page).Take(PageSize);
        }

        public void UpdateItem(string id)
        {
            if (!master.isAdmin && id != User.Identity.GetUserId())
            {
                master.ShowErrorMessage("Not authorized.");
                return;
            }

            var user = data.Users.Find(id);
            User item = null;
            item = data.Users.Find(id);
            if (item == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            TryUpdateModel(item);

            if (ModelState.IsValid)
            {

                var fileUploadControl = (FileUpload)FormViewUserDetails.FindControl("FileUploadControl");

                if (fileUploadControl.HasFile)
                {
                    string fileName = user.UserName + DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss") + ".jpg";
                    fileUploadControl.SaveAs(Server.MapPath("~/Uploaded_Files/") + fileName);
                    user.Avatar = fileName;
                }

                data.Entry(item).State = EntityState.Modified;
                data.SaveChanges();
                master.ShowSuccessMessage("Item updated");

                this.DataBind();
            }
        }

        public void DeleteItem(string id)
        {
            if (!master.isAdmin)
            {
                master.ShowErrorMessage("Not authorized.");
                return;
            }

            var item = data.Users.Find(id);
            data.Users.Remove(item);
            data.SaveChanges();
            master.ShowSuccessMessage("Item deleted");
            //ViewState["selectedTodo"] = null;
            this.ListViewUsers.SelectedIndex = -1;
            this.FormViewUserDetails.Visible = false;
            this.DataBind();
        }

        // USERS LIST

        protected void orderByName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dropDown = (DropDownList)sender;
            var selectedItem = dropDown.SelectedItem;
            ViewState.Add("orderByName", selectedItem.Text);
            FirstPage_ServerClick(new { }, new EventArgs());
            this.DataBind();
        }

        protected void ListViewUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FormViewUserDetails.PageIndex = this.ListViewUsers.SelectedIndex;
            this.FormViewUserDetails.Visible = true;
        }

        // PAGINATION

        protected void NextPage_ServerClick(object sender, EventArgs e)
        {
            int page = (int)ViewState["page"];
            if (page * PageSize < data.Users.Count() - PageSize)
            {
                ViewState["page"] = ++page;
                this.ListViewUsers.SelectedIndex = -1;
                this.FormViewUserDetails.Visible = false;
                this.DataBind();
            }

        }

        protected void PrevPage_ServerClick(object sender, EventArgs e)
        {
            int page = (int)ViewState["page"];
            if (page > 0)
            {
                ViewState["page"] = --page;
                this.ListViewUsers.SelectedIndex = -1;
                this.FormViewUserDetails.Visible = false;
                this.DataBind();
            }
        }

        protected void FirstPage_ServerClick(object sender, EventArgs e)
        {
            ViewState["page"] = 0;
            this.ListViewUsers.SelectedIndex = -1;
            this.FormViewUserDetails.Visible = false;
            this.DataBind();
        }

        protected void LastPage_ServerClick(object sender, EventArgs e)
        {
            var totalCount = data.Users.Count();

            var lastPage = totalCount / PageSize;
            if (totalCount % PageSize == 0)
            {
                lastPage--;
            }

            ViewState["page"] = lastPage;
            this.ListViewUsers.SelectedIndex = -1;
            this.FormViewUserDetails.Visible = false;
            this.DataBind();
        }
    }
}