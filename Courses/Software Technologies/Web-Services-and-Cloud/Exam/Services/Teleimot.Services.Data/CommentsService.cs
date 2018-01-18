namespace Teleimot.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common.Constants;
    using Teleimot.Data.Contracts;
    using Teleimot.Data.Models;
    using Contracts;

    public class CommentsService : ICommentsService
    {
        private ITeleimotData data;

        public CommentsService(ITeleimotData data)
        {
            this.data = data;
        }

        public IQueryable<Comment> GetCommentsForEstate(int estateId, int skip = ValidationConstants.SkipDefaultValue, int take = ValidationConstants.TakeDefaultValue)
        {
            if (take > ValidationConstants.TakeMaxValue || skip > ValidationConstants.SkipMaxValue)
            {
                throw new ArgumentException($"Take and skip must be less than {ValidationConstants.TakeDefaultValue} and {ValidationConstants.SkipDefaultValue} respectively.");
            }

            var estate = this.data.Estates.All().FirstOrDefault(x => x.Id == estateId);
            if (estate == null)
            {
                return null;
            }

            var comments = estate.Comments
                .OrderBy(x => x.CreatedOn)
                .Skip(skip)
                .Take(take);

            return comments.AsQueryable();
        }

        public IQueryable<Comment> GetCommentsByUser(string username, int skip = ValidationConstants.SkipDefaultValue, int take = ValidationConstants.TakeDefaultValue)
        {
            if (take > ValidationConstants.TakeMaxValue || skip > ValidationConstants.SkipMaxValue)
            {
                throw new ArgumentException($"Take and skip must be less than {ValidationConstants.TakeDefaultValue} and {ValidationConstants.SkipDefaultValue} respectively.");
            }

            var user = this.data.Users.All().FirstOrDefault(x => x.ProvidedUsername == username);
            if (user == null)
            {
                return null;
            }

            var comments = user.Comments
                .OrderBy(x => x.CreatedOn)
                .Skip(skip)
                .Take(take);

            return comments.AsQueryable();
        }

        public void AddNewComment(Comment comment)
        {
            var user = this.data.Users.All().First(x => x.Id == comment.UserId);
            comment.User = user;

            this.data.Comments.Add(comment);
            this.data.SaveChanges();
        }
    }
}
