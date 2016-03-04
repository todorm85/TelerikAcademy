namespace Movies.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Movie
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public int DirectorId { get; set; }

        public virtual Person Director { get; set; }

        public int LeadingMaleRoleId { get; set; }

        public virtual Person LeadingMaleRole { get; set; }

        public int LeadingFemaleRoleId { get; set; }

        public virtual Person LeadingFemaleRole { get; set; }


    }
}
