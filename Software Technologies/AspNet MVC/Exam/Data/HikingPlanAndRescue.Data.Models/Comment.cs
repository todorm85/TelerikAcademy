namespace VoiceSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common.Models;

    public class Comment : BaseModel<int>
    {
        public string Content { get; set; }

        public string Email { get; set; }

        public string UserIp { get; set; }

        public int IdeaId { get; set; }

        public virtual Idea Idea { get; set; }
    }
}
