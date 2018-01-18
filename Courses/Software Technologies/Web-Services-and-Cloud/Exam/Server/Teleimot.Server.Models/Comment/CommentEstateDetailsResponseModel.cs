namespace Teleimot.Server.Models.Comment
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mappings;

    public class CommentEstateDetailsResponseModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserName { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Comment, CommentEstateDetailsResponseModel>()
                .ForMember(x => x.UserName, opts => opts.MapFrom(x => x.User.ProvidedUsername));
        }
    }
}
