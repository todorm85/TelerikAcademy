namespace Teleimot.Server.Api.Controllers
{
    using System.Web.Http;
    using Teleimot.Services.Data.Contracts;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Common.Constants;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Models.Comment;
    using Models.User;
    using System.Linq;

    public class UsersController : ApiController
    {
        private IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }


        public IHttpActionResult GetUserDetails(string id)
        {
            // 'id' is username (ProvidedUsername) 
            var user = this.usersService.GetUserDetails(id);
            if (user == null)
            {
                return this.BadRequest("User not found");
            }


            var response = Mapper.Map<UserResponseModel>(user);
            if (user.Ratings.Count > 0)
            {
                response.Rating = user.Ratings.Sum(x => x.Value) / user.Ratings.Count;
            }

            return this.Ok(response);
        }

        [HttpPut]
        [Authorize]
        [Route("api/users/rate")]
        public IHttpActionResult RateUser(UserRateRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var raterId = this.User.Identity.GetUserId();
            if (raterId == model.UserId)
            {
                return this.BadRequest("Users cannot rate themselves");
            }

            if (model.Value < ValidationConstants.RatingsMinValue || ValidationConstants.RatingsMaxValue < model.Value)
            {
                return this.BadRequest($"Must rate with value between {ValidationConstants.RatingsMinValue} - {ValidationConstants.RatingsMaxValue}.");
            }

            var ratedUser = this.usersService.RateUser(model.UserId, model.Value);
            if (ratedUser == null)
            {
                return this.BadRequest("No user with this id.");
            }

            return this.Ok();
        }
    }
}