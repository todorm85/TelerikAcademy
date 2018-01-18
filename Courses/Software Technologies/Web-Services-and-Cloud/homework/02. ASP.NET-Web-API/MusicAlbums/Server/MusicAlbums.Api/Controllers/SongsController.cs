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

namespace MusicAlbums.Api.Controllers
{
    public class SongsController : ApiController
    {
        private IMusicAlbumsData data;

        public SongsController(IMusicAlbumsData data)
        {
            this.data = data;
        }

        public IHttpActionResult Post(SongModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Invalid Song data.");
            }

            if (!this.data.Artists.All().Any(a => a.Id == model.ArtistId))
            {
                return this.BadRequest("No such artist for the song.");
            }

            if (!this.data.Albums.All().Any(a => a.Id == model.AlbumId))
            {
                return this.BadRequest("No such album for the song.");
            }

            var newSong = Mapper.Map<Song>(model);

            this.data.Songs.Add(newSong);

            this.data.SaveChanges();

            return this.Ok();
        }

        public IHttpActionResult Get()
        {
            var artists = this.data.Songs.All().ProjectTo<SongModel>();

            return this.Ok(artists);
        }

        public IHttpActionResult Put(int id, SongModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Invalid Song data.");
            }

            var Song = this.data.Songs.All().Where(a => a.Id == id).FirstOrDefault();

            if (Song == null)
            {
                return this.BadRequest("Song not found.");
            }

            Song.Title = model.Title ?? Song.Title;
            Song.Genre = model.Genre ?? Song.Genre;
            Song.Year = model.Year ?? Song.Year;

            this.data.SaveChanges();

            return this.Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Invalid Song data.");
            }

            var song = this.data.Songs.All().Where(a => a.Id == id).FirstOrDefault();

            if (song == null)
            {
                return this.BadRequest("Song not found.");
            }

            this.data.Songs.Delete(song);
            this.data.SaveChanges();

            return this.Ok();
        }
    }
}
