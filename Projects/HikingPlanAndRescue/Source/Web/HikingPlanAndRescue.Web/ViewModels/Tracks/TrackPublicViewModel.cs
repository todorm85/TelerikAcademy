﻿namespace HikingPlanAndRescue.Web.ViewModels.Tracks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class TrackPublicViewModel : IMap<Track>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public double Length { get; set; }

        public double Ascent { get; set; }

        public double AscentLength { get; set; }

        public int VotesCount { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Track, TrackPublicViewModel>()
                .ForMember(x => x.Author, opt => opt.MapFrom(x => x.User.UserName));

            configuration.CreateMap<Track, TrackPublicViewModel>()
                .ForMember(x => x.VotesCount, opt => opt.MapFrom(x => x.TrackVotes.Sum(y => (int?)y.Vote) ?? 0));
        }
    }
}
