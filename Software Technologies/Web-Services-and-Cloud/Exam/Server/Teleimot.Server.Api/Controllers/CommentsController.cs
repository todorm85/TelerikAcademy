namespace Teleimot.Server.Api.Controllers
{
    using System.Web.Http;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Common.Constants;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Models.Comment;
    using Services.Data.Contracts;

    public class CommentsController : ApiController
    {
        private ICommentsService commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        // GET api/Comments/ID?skip=2&take=5
        [Authorize]
        public IHttpActionResult GetEstateComments(int id, int skip = ValidationConstants.SkipDefaultValue, int take = ValidationConstants.TakeDefaultValue)
        {
            if (skip > ValidationConstants.SkipMaxValue || take > ValidationConstants.TakeMaxValue)
            {
                return this.BadRequest($"Take and skip must be less than {ValidationConstants.TakeDefaultValue} and {ValidationConstants.SkipDefaultValue} respectively.");
            }

            var comments = this.commentsService.GetCommentsForEstate(id, skip, take);

            if (comments == null)
            {
                return this.BadRequest("No such estate id.");
            }

            var commentsResponse = comments.ProjectTo<CommentEstateDetailsResponseModel>();

            return this.Ok(commentsResponse);
        }

        // GET api/Comments/ByUser/USERNAME?skip=2&take=5
        [Authorize]
        [Route("api/Comments/ByUser/{username}")]
        public IHttpActionResult GetUserComments(string username, int skip = ValidationConstants.SkipDefaultValue, int take = ValidationConstants.TakeDefaultValue)
        {
            if (skip > ValidationConstants.SkipMaxValue || take > ValidationConstants.TakeMaxValue)
            {
                return this.BadRequest($"Take and skip must be less than {ValidationConstants.TakeDefaultValue} and {ValidationConstants.SkipDefaultValue} respectively.");
            }

            var comments = this.commentsService.GetCommentsByUser(username, skip, take);

            if (comments == null)
            {
                return this.BadRequest("No such user id.");
            }

            var commentsResponse = comments.ProjectTo<CommentEstateDetailsResponseModel>();

            return this.Ok(commentsResponse);
        }

        [Authorize]
        public IHttpActionResult PostNewComment(CommentRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var userId = this.User.Identity.GetUserId();

            var newComment = Mapper.Map<Comment>(model);
            newComment.UserId = userId;

            this.commentsService.AddNewComment(newComment);

            var createdCommentResponse = Mapper.Map<CommentEstateDetailsResponseModel>(newComment);

            return this.Created("api/comments", createdCommentResponse);
        }
    }
}