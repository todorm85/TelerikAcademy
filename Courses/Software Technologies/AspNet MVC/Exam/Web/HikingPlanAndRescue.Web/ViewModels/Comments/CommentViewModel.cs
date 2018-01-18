namespace VoiceSystem.Web.ViewModels.Ideas
{
    using System;
    using VoiceSystem.Data.Models;
    using VoiceSystem.Web.Infrastructure.Mapping;

    public class CommentViewModel : IMap<Comment>
    {
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Email { get; set; }

        public string UserIp { get; set; }
    }
}