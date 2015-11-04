namespace StudentSystem.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel.DataAnnotations;
    using StudentSystem.Api.Infrastructure.Mappings;
    using StudentSystem.Models;
    using StudentSystem.Common;

    public class StudentBindingModel : IMapFrom<Student>
    {
        [Required]
        [MinLength(ValidationConstants.StudentNameMinLength)]
        [MaxLength(ValidationConstants.StudentNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(ValidationConstants.StudentNameMinLength)]
        [MaxLength(ValidationConstants.StudentNameMaxLength)]
        public string LastName { get; set; }

        public int Level { get; set; }
    }
}
