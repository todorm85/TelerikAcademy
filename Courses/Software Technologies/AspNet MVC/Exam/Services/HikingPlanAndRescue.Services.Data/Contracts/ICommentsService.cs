namespace VoiceSystem.Services.Data.Contracts
{
    using System.Linq;
    using VoiceSystem.Data.Models;
    using VoiceSystem.Services.Data.Common;

    public interface ICommentsService : IBaseDataService<Comment>
    {
        IQueryable<Comment> GetAllIdeaCommentsWithPaging(int page, int pageSize, int ideaId);
    }
}