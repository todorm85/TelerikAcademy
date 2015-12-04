namespace Tests.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Models;

    public class TestDbContext : DbContext
    {
        public TestDbContext()
            : base("DefaultConnection")
        {

        }

        public virtual IDbSet<Question> Questions { get; set; }

        public virtual IDbSet<Answer> Answers { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }
    }
}
