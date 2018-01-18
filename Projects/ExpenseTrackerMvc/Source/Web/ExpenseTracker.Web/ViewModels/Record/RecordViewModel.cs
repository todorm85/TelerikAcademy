namespace ExpenseTracker.Web.ViewModels.Record
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Category;
    using Data.Models;
    using Infrastructure.Mapping;

    public class RecordViewModel : IMapBothWays<Record>
    {
        public string Description { get; set; }

        public decimal Expense { get; set; }

        public decimal Income { get; set; }

        public CategoryViewModel Category { get; set; }
    }
}
