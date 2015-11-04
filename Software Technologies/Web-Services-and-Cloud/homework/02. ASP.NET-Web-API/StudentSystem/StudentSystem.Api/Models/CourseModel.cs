namespace StudentSystem.Api.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using StudentSystem.Api.Infrastructure.Mappings;
    using StudentSystem.Models;

    public class CourseModel : IMapFrom<Course>, IHaveCustomMappings
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid Id { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<CourseModel, Course>()
                .ForMember(c => c.Id, opts => opts.MapFrom(cm => Guid.NewGuid()));
        }
    }
}