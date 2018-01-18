using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouTubePlaylists.Data.Repositories;

namespace YouTubePlaylists.Web.Categories
{
    public partial class Categories : System.Web.UI.Page
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


        public IQueryable<YouTubePlaylists.Models.Category> ListViewCategories_GetData([ViewState("OrderBy")]String OrderBy = null)
        {
            var categories = this.data.Categories.All();
            if (OrderBy != null)
            {
                switch (this.SortDirection)
                {
                    case SortDirection.Ascending:
                        categories = categories.OrderBy(OrderBy);
                        break;

                    case SortDirection.Descending:
                        categories = categories.OrderBy(OrderBy + " Descending");
                        break;

                    default:
                        categories = categories.OrderBy(OrderBy + " Descending");
                        break;
                }
                return categories;
            }
            else
            {
                categories.OrderBy("Id Descending");
            }

            return categories;
        }

        public void ListViewCategories_InsertItem()
        {
            var item = new YouTubePlaylists.Models.Category();
            TryUpdateModel(item);

            if (ModelState.IsValid)
            {
                if (data.Categories.All().Any(x => x.Name == item.Name))
                {
                    master.ShowErrorMessage("Category not added. Duplicate name!");
                    return;
                }

                data.Categories.Add(item);
                data.SaveChanges();
                master.ShowSuccessMessage("Category added!");
            }
            else
            {
                master.ShowErrorMessage("Category not added. Invalid data.");
            }
        }

        public void ListViewCategories_UpdateItem(int id)
        {
            var cat = data.Categories.GetById(id);

            if (cat == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                master.ShowErrorMessage(String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(cat);
            if (ModelState.IsValid)
            {
                if (data.Categories.All().Any(x => x.Name == cat.Name))
                {
                    master.ShowErrorMessage("Category not added. Duplicate name!");
                    return;
                }

                data.SaveChanges();
                master.ShowSuccessMessage("Category updated!");
            }
        }

        protected void ListViewCategories_Sorting(object sender, ListViewSortEventArgs e)
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
            this.ListViewCategories.DataBind();
        }
    }
}