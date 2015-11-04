namespace MusicAlbums.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MusicAlbums.Api.Models;
    using MusicAlbums.Data;
    using MusicAlbums.Models;

    public class ArtistsController : ApiController
    {
        private IMusicAlbumsData data;

        public ArtistsController(IMusicAlbumsData data)
        {
            this.data = data;
        }

        public IHttpActionResult Post(ArtistModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Invalid Artist data.");
            }

            var newArtist = Mapper.Map<Artist>(model);

            this.data.Artists.Add(newArtist);

            this.data.SaveChanges();

            return this.Ok();
        }

        public IHttpActionResult Get()
        {
            var artists = this.data.Artists.All().ProjectTo<ArtistModel>();

            return this.Ok(artists);
        }

        public IHttpActionResult Put(int id, ArtistModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Invalid Artist data.");
            }

            var artist = this.data.Artists.All().Where(a => a.Id == id).FirstOrDefault();

            if (artist == null)
            {
                return this.BadRequest("Artist not found.");
            }

            artist.Name = model.Name ?? artist.Name;
            artist.Country = model.Country ?? artist.Country;
            artist.DateOfBirth = model.DateOfBirth ?? artist.DateOfBirth;

            this.data.SaveChanges();

            return this.Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Invalid Artist data.");
            }

            var artist = this.data.Artists.All().Where(a => a.Id == id).FirstOrDefault();

            if (artist == null)
            {
                return this.BadRequest("Artist not found.");
            }

            this.data.Artists.Delete(artist);
            this.data.SaveChanges();

            return this.Ok();
        }
    }
}
