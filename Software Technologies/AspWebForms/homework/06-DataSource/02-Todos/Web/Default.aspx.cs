using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Countries.Data.Models;
using Todos.Data;
using Todos.Web;

namespace Todos
{
    public partial class _Default : Page
    {
        TodosDbContext data = new TodosDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<Todo> ListViewTodos_GetData()
        {
            return data.Todos.OrderBy(x => x.Id);
        }

        public IQueryable<Category> GetGategories()
        {
            return data.Categories.OrderBy(x => x.Id);
        }

        public List<Todo> FormViewTodos_GetData()
        {
            if (ViewState["selectedTodo"] == null)
            {
                return new List<Todo>();
            }

            var id = (string)ViewState["selectedTodo"];
            var foundTodo = data.Todos.Find(int.Parse(id));
            return new List<Todo> { foundTodo };
        }

        protected void ListViewTodos_ServerClick(object sender, EventArgs e)
        {
            var anchor = sender as HtmlAnchor;
            var id = anchor.Name;
            ViewState["selectedTodo"] = id;
            this.FormViewTodoDetails.DataBind();
        }

        public void FormViewTodoDetails_UpdateItem(int id)
        {
            Todo item = null;
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            item = data.Todos.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            TryUpdateModel(item);

            if (ModelState.IsValid)
            {
                data.Entry(item).State = EntityState.Modified;
                data.SaveChanges();
                // Save changes here, e.g. MyDataLayer.SaveChanges();

            }
        }

        protected void AddNewButton_Click(object sender, EventArgs e)
        {
            this.FormViewTodoDetails.ChangeMode(FormViewMode.Insert);
        }

        public void FormViewTodoDetails_InsertItem()
        {
            var item = new Todo();
            TryUpdateModel(item);
            var dropDownCategories = (DropDownList)this.FormViewTodoDetails.FindControl("DropDownListCategoriesList");
            item.CategoryId = int.Parse(dropDownCategories.SelectedValue);

            if (ModelState.IsValid)
            {
                var id = data.Todos.Add(item);
                data.SaveChanges();
                var master = this.Master as Site;
                master.ShowSuccessMessage("Item added");
                this.ListViewTodos.DataBind();

                var pageSize = ListViewTodosPager.MaximumRows;
                var todosCount = data.Todos.Count();
                var correctionIndex = (todosCount % pageSize == 0) ? pageSize : todosCount % pageSize;
                var startItemIndex = todosCount - correctionIndex;
                this.ListViewTodosPager.SetPageProperties(startItemIndex , pageSize, true);
            }
        }

        public void FormViewTodoDetails_DeleteItem(int id)
        {
            var item = data.Todos.Find(id);
            data.Todos.Remove(item);
            data.SaveChanges();
            var master = this.Master as Site;
            master.ShowSuccessMessage("Item deleted");
            ViewState["selectedTodo"] = null;
            this.ListViewTodos.DataBind();

            var pageSize = ListViewTodosPager.MaximumRows;
            var pageParam = Request.Params.Get("page");
            var currentPage = 0;
            if (pageParam != null)
            {
                currentPage = int.Parse(pageParam);
            }
            this.ListViewTodosPager.SetPageProperties((currentPage-1)*pageSize, pageSize, true);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewTodos_DeleteItem(int id)
        {

        }
    }
}