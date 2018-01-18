namespace VoiceSystem.Web.ViewModels.Ideas
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class IdeaViewModel : IMap<Idea>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int VoteCount { get; set; }

        public int CommentsCount { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Idea, IdeaViewModel>()
                .ForMember(x => x.VoteCount, opt => opt.MapFrom(x => x.Votes.Sum(y => (int?)y.VotePoints) ?? 0));

            configuration.CreateMap<Idea, IdeaViewModel>()
                .ForMember(x => x.CommentsCount, opt => opt.MapFrom(x => x.Comments.Count()));
        }
    }
}
