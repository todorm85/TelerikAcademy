namespace SocialNetwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;

    public class Friendship
    {
        public int FriendshipId { get; set; }

        public int FirstUserId { get; set; }

        [ForeignKey("FirstUserId")]
        public virtual User FirstUser { get; set; }

        public int SecondUserId { get; set; }

        [ForeignKey("SecondUserId")]
        public virtual User SecondUser { get; set; }

        public DateTime? ApprovalDate { get; set; }
    }
}
