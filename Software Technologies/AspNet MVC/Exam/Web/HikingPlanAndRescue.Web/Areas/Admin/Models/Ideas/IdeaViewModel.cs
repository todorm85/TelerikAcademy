namespace VoiceSystem.Web.Areas.Admin.Models.Ideas
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class IdeaViewModel : IMap<Idea>
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [UIHint("Description")]
        public string Description { get; set; }

        [Required]
        public string UserIp { get; set; }
    }
}