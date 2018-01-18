namespace Teleimot.Server.Models.User
{
    using System;
    using System.Linq;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mappings;

    public class UserResponseModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public int RealEstates { get; set; }

        public int Comments { get; set; }

        public double Rating { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<User, UserResponseModel>()
                .ForMember(x => x.Username, opts => opts.MapFrom(x => x.ProvidedUsername))
                .ForMember(x => x.RealEstates, opts => opts.MapFrom(x => x.Estates.Count))
                .ForMember(x => x.Comments, opts => opts.MapFrom(x => x.Comments.Count));
        }
    }
}