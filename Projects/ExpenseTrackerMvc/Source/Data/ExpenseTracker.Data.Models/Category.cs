namespace ExpenseTracker.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;

    public class Category : BaseModel<int>
    {
        public Category()
        {
            this.Categories = new HashSet<Category>();
            this.Records = new HashSet<Record>();
        }

        public string Name { get; set; }

        public int ParentCategoryId { get; set; }

        [InverseProperty("Categories")]
        public virtual Category ParentCategory { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<Record> Records { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
