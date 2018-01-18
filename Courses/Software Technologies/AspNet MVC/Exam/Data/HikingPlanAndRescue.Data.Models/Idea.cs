namespace VoiceSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Common.Models;

    public class Idea : BaseModel<int>
    {
        public Idea()
        {
            this.Votes = new HashSet<IdeaVote>();
            this.Comments = new HashSet<Comment>();
        }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string UserIp { get; set; }

        public virtual ICollection<IdeaVote> Votes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
