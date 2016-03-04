namespace VoiceSystem.Web.ViewModels.Ideas
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using VoiceSystem.Data.Models;
    using VoiceSystem.Web.Infrastructure.Mapping;

    public class CommentCreateViewModel : IMap<Comment>
    {
        [Required]
        public string Content { get; set; }

        [Required]
        public string Email { get; set; }

        public int IdeaId { get; set; }
    }
}