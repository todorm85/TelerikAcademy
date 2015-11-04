namespace StudentSystem.Api.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using StudentSystem.Api.Infrastructure.Mappings;
    using StudentSystem.Models;

    public class HomeworkModel : IMapFrom<Homework>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string FileUrl { get; set; }

        public DateTime TimeSent { get; set; }

        [Required]
        public int StudentIdentification { get; set; }

        [Required]
        public string CourseName { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration config)
        {
            config.CreateMap<HomeworkModel, Homework>()
                .ForMember(h => h.TimeSent,
                    opts => opts
                        .MapFrom(s => DateTime.Now));
        }
    }
}