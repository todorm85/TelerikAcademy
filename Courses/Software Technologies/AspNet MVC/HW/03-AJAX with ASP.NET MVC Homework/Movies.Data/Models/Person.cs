using System.Collections.Generic;

namespace Movies.Data.Models
{
    public class Person
    {
        public Person()
        {
            this.Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int StudioId { get; set; }

        public virtual Studio Studio { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}