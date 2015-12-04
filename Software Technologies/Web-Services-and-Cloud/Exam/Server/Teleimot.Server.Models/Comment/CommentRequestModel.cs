namespace Teleimot.Server.Models.Comment
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Common.Constants;
    using Infrastructure.Mappings;
    using Data.Models;
    using AutoMapper;

    public class CommentRequestModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int RealEstateId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.CommentsContentMaxLength)]
        [MinLength(ValidationConstants.CommentsContentMinLength)]
        public string Content { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<CommentRequestModel, Comment>()
                .ForMember(x => x.EstateId, opts => opts.MapFrom(x => x.RealEstateId));
        }
    }
}
