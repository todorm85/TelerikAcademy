
namespace Teleimot.Server.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Services.Data.Contracts;
    using Models.Estate;
    using AutoMapper.QueryableExtensions;
    using AutoMapper;
    using Data.Models;
    using Models.Comment;
    using Microsoft.AspNet.Identity;
    using Common.Constants;

    public class RealEstatesController : ApiController
    {
        private IEstatesService estatesService;

        public RealEstatesController(IEstatesService estatesService)
        {
            this.estatesService = estatesService;
        }

        // GET api/RealEstates
        // GET api/RealEstates?skip=2&take=5
        public IHttpActionResult GetPublicEstates(int skip = ValidationConstants.SkipDefaultValue, int take = ValidationConstants.TakeDefaultValue)
        {
            if (skip > ValidationConstants.SkipMaxValue || take > ValidationConstants.TakeMaxValue)
            {
                return this.BadRequest($"Take and skip must be less than {ValidationConstants.TakeDefaultValue} and {ValidationConstants.SkipDefaultValue} respectively.");
            }

            var estates = this.estatesService.GetPublicEstates(skip, take)
                .ProjectTo<PublicEstateResponseModel>();

            return this.Ok(estates);
        }

        // GET api/RealEstates/{id}
        public IHttpActionResult GetEstateDetails(int id)
        {
            var estate = this.estatesService.GetEstateDetails(id);
            if (estate == null)
            {
                return this.NotFound();
            }

            if (this.User.Identity.IsAuthenticated)
            {
                var responseEstate = Mapper.Map<Estate, PrivateEstateDetailsResponseModel>(estate, opt =>
                {
                    opt.AfterMap((src, dest) =>
                    {
                        dest.Comments = src
                            .Comments
                            .Select(x => Mapper.Map<CommentEstateDetailsResponseModel>(x))
                            .ToList();
                    });
                });

                return this.Ok(responseEstate);
            }
            else
            {
                var responseEstate = Mapper.Map<PublicEstateDetailsResponseModel>(estate);
                return this.Ok(responseEstate);
            }
        }

        // POST api/RealEstates
        [Authorize]
        public IHttpActionResult PostEstate(AddEstateRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newEstate = Mapper.Map<AddEstateRequestModel, Estate>(model, opt =>
            {
                opt.AfterMap((src, dest) =>
                {
                    dest.CanBeRented = (src.RentingPrice != null && src.RentingPrice > 0) ? true : false;
                    dest.CanBeSold = (src.SellingPrice > 0) ? true : false;
                });
            });


            if (newEstate.CanBeRented == false && newEstate.CanBeSold == false )
            {
                return this.BadRequest("Must be either rentable or for sale.");
            }

            var userId = this.User.Identity.GetUserId();
            newEstate.UserId = userId;

            this.estatesService.CreateEstate(newEstate);

            var responseEstate = Mapper.Map<PublicEstateResponseModel>(newEstate);

            return this.Created("api/RealEstates",responseEstate);
        }

    }
}
