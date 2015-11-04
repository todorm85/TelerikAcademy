namespace StudentSystem.Api.Models
{
    using System.Collections.Generic;
    using AutoMapper;
    using StudentSystem.Api.Infrastructure.Mappings;
    using StudentSystem.Models;
    using System.Linq;

    public class StudentViewModel : IMapFrom<Student>, IHaveCustomMappings
    {
        public int StudentIdentification { get; set; }

        public string FirstName { get; set; }

        public int Level { get; set; }

        public ICollection<string> Courses { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Student, StudentViewModel>()
                .ForMember(sv => sv.Courses, 
                    opts => opts
                        .MapFrom(s => s.Courses.Select(c => c.Name)));
        }
    }
}