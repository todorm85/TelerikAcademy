namespace VoiceSystem.Web.Areas.Admin.Models.Comments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CommentListItemViewModel : IMap<Comment>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Email { get; set; }

        public string UserIp { get; set; }
    }
}
