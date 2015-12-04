namespace Teleimot.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class Comment
    {
        public Comment()
        {
            this.CreatedOn = DateTime.Now;
        }

        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int EstateId { get; set; }

        public virtual Estate Estate { get; set; }

        [Required]
        [MaxLength(ValidationConstants.CommentsContentMaxLength)]
        [MinLength(ValidationConstants.CommentsContentMinLength)]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }


    }
}