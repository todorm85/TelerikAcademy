namespace ExpenseTracker.Data.Common.Models
{
    public interface IEntityWithCreator
    {
        string UserId { get; set; }
    }
}