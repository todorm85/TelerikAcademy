namespace Movies.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Data.Models;
    public class MovieViewModel
    {
        public static Expression<Func<Movie, MovieViewModel>> FromMovie
        {
            get
            {
                return x => new MovieViewModel
                {
                    Id = x.Id,
                    Title = x.Title
                };
            }
        }

        public string Title { get; set; }

        public int Id { get; set; }

    }
}
