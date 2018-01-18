namespace Teleimot.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class Estate
    {
        private ICollection<Comment> comments;

        public Estate()
        {
            this.CreatedOn = DateTime.Now;
            this.comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.EstateTitleMaxLength)]
        [MinLength(ValidationConstants.EstateTitleMinLength)]
        public string Title { get; set; }

        public Decimal SellingPrice { get; set; }

        public Decimal? RentingPrice { get; set; }

        public bool CanBeSold { get; set; }

        public bool CanBeRented { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? ConstructionYear { get; set; }

        [Required]
        public string Address { get; set; }

        public EstateType RealEstateType { get; set; }

        [Required]
        [MaxLength(ValidationConstants.EstateDescriptionMaxLength)]
        [MinLength(ValidationConstants.EstateDescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        [MaxLength(ValidationConstants.EstateContactMaxLength)]
        public string Contact { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }
    }
}