namespace ExpenseTracker.Web.ViewModels.Category
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class CategoryViewModel : IMapBothWays<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
