using System.Linq;
using Teleimot.Data.Models;

namespace Teleimot.Services.Data.Contracts
{
    public interface ICommentsService
    {
        void AddNewComment(Comment comment);
        IQueryable<Comment> GetCommentsByUser(string userId, int skip = 0, int take = 10);
        IQueryable<Comment> GetCommentsForEstate(int estateId, int skip = 0, int take = 10);
    }
}