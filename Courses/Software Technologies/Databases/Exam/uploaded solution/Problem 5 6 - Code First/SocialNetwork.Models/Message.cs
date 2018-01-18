namespace SocialNetwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;

    public class Message
    {
        public int MessageId { get; set; }

        public int FriendshipId { get; set; }

        public virtual Friendship Friendship { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public string MessageContent { get; set; }

        public DateTime TimeSent { get; set; }

        public DateTime? TimeSeen { get; set; }
    }
}
