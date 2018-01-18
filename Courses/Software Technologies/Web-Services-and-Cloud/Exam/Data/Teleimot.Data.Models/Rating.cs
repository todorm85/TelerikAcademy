namespace Teleimot.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Rating
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public double Value { get; set; }
    }
}
