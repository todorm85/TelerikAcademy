namespace ExpenseTracker.Data.Models
{
    using Common.Models;

    public class Record : BaseModel<int>
    {
        public string Description { get; set; }

        public decimal? Expense { get; set; }

        public decimal? Income { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
