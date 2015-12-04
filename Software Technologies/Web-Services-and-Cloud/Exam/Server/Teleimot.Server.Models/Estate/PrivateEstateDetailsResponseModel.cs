namespace Teleimot.Server.Models.Estate
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Infrastructure.Mappings;
    using Data.Models;
    using Comment;

    public class PrivateEstateDetailsResponseModel : IMapFrom<Estate>
    {
        public DateTime CreatedOn { get; set; }
        public int? ConstructionYear { get; set; }
        public string Address { get; set; }
        public EstateType RealEstateType { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public Decimal SellingPrice { get; set; }
        public Decimal? RentingPrice { get; set; }
        public bool CanBeSold { get; set; }
        public bool CanBeRented { get; set; }

        public string Contact { get; set; }

        public ICollection<CommentEstateDetailsResponseModel> Comments { get; set; }

    }
}
