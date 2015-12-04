namespace Teleimot.Server.Models.Estate
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Infrastructure.Mappings;
    using Data.Models;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class PublicEstateResponseModel : IMapFrom<Estate>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Decimal SellingPrice { get; set; }

        public Decimal? RentingPrice { get; set; }

        public bool CanBeSold { get; set; }

        public bool CanBeRented { get; set; }

    }
}
