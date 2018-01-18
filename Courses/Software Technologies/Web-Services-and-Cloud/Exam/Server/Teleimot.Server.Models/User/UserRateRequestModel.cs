namespace Teleimot.Server.Models.User
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class UserRateRequestModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public double Value { get; set; }
    }
}
