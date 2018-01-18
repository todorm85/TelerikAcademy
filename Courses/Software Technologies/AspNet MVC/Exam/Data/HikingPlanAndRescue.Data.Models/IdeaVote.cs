namespace VoiceSystem.Data.Models
{
    using Common.Models;

    public class IdeaVote : BaseModel<int>
    {
        public int IdeaId { get; set; }

        public virtual Idea Idea { get; set; }

        public int VotePoints { get; set; }

        public string UserIp { get; set; }
    }
}