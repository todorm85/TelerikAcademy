namespace VoiceSystem.Web.ViewModels.Ideas
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IdeaDetailsPageViewModel
    {
        public IdeaDetailsViewModel Idea { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public int Page { get; set; }

        public int PageCount { get; set; }
    }
}
