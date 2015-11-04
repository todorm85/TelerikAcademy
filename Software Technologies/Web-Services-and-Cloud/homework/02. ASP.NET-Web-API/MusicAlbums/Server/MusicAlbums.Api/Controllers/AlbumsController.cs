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

    public class AlbumsController : ApiController
    {
        private IMusicAlbumsData data;

        public AlbumsController(IMusicAlbumsData data)
        {
            this.data = data;
        }

        public IHttpActionResult Post(AlbumModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Invalid Album data.");
            }

            var newAlbum = Mapper.Map<Album>(model);

            this.data.Albums.Add(newAlbum);

            this.data.SaveChanges();

            return this.Ok();
        }

        public IHttpActionResult Get()
        {
            var artists = this.data.Albums.All().ProjectTo<AlbumModel>();

            return this.Ok(artists);
        }

        public IHttpActionResult Put(int id, AlbumModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Invalid album data.");
            }

            var album = this.data.Albums.All().Where(a => a.Id == id).FirstOrDefault();

            if (album == null)
            {
                return this.BadRequest("album not found.");
            }

            album.Title = model.Title ?? album.Title;
            album.Year = model.Year ?? album.Year;
            album.Producer = model.Producer ?? album.Producer;

            this.data.SaveChanges();

            return this.Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Invalid Artist data.");
            }

            var album = this.data.Albums.All().Where(a => a.Id == id).FirstOrDefault();

            if (album == null)
            {
                return this.BadRequest("Artist not found.");
            }

            this.data.Albums.Delete(album);
            this.data.SaveChanges();

            return this.Ok();
        }
    }
}
