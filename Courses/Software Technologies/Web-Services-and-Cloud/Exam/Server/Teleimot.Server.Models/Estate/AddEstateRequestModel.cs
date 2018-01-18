namespace Teleimot.Server.Models.Estate
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Common.Constants;
    using Data.Models;
    using Infrastructure.Mappings;

    public class AddEstateRequestModel : IMapFrom<Estate>, IHaveCustomMappings
    {
        [Required]
        [MaxLength(ValidationConstants.EstateTitleMaxLength)]
        [MinLength(ValidationConstants.EstateTitleMinLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(ValidationConstants.EstateDescriptionMaxLength)]
        [MinLength(ValidationConstants.EstateDescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [MaxLength(ValidationConstants.EstateContactMaxLength)]
        public string Contact { get; set; }

        public int? ConstructionYear { get; set; }

        public Decimal? RentingPrice { get; set; }

        public Decimal SellingPrice { get; set; }

        public EstateType Type { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<AddEstateRequestModel, Estate>()
                .ForMember(x => x.RealEstateType, opts => opts.MapFrom(x => x.Type));
        }
    }
}