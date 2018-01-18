namespace HikingPlanAndRescue.Web.Areas.Admin.Models.Users
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Data.Models;
    using Infrastructure.Mapping;

    public class UserViewModel : IMap<ApplicationUser>
    {
        [Required]
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string GSM { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
