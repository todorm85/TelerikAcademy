namespace VoiceSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using VoiceSystem.Data.Common;
    using VoiceSystem.Data.Models;

    public class CommentsService : BaseDataService<Comment>, ICommentsService
    {
        public CommentsService(IDbRepository<Comment> dataSet)
            : base(dataSet)
        {
        }

        public IQueryable<Comment> GetAllIdeaCommentsWithPaging(int page, int pageSize, int ideaId)
        {
            return this.Data
                .All()
                .Where(x => x.IdeaId == ideaId)
                .OrderByDescending(x => x.CreatedOn)
                .Skip(page * pageSize)
                .Take(pageSize);
        }
    }
}
