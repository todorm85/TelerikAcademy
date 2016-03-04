namespace VoiceSystem.Web.ViewModels.Ideas
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IdeaIndexViewModel
    {
        public IdeaCreateViewModel CreateModel { get; set; }

        public IEnumerable<IdeaViewModel> Ideas { get; set; }

        public int PageCount { get; set; }

        public int Page { get; set; }
    }
}
