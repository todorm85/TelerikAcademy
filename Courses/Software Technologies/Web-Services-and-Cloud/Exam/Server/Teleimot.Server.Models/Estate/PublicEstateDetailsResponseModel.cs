namespace Teleimot.Server.Models.Estate
{
    using System;
    using Data.Models;
    using Infrastructure.Mappings;

    public class PublicEstateDetailsResponseModel : IMapFrom<Estate>
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
    }
}