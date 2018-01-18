namespace YouTubePlaylists.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Models;
    public static class DbSeeder
    {
        private static string[] videoUrls = new string[]
        {
            "https://www.youtube.com/watch?v=tPFz04LSa2U",
            "https://www.youtube.com/watch?v=bSghnrBtvKM",
            "https://www.youtube.com/watch?v=fWRISvgAygU",
        };

        public static void Seed(YouTubePlaylistsDbContext context)
        {
            SeedRoles(context);
            context = new YouTubePlaylistsDbContext();
            SeedUsers(context);
            context = new YouTubePlaylistsDbContext();
            SeedCategories(context);
            context = new YouTubePlaylistsDbContext();
            SeedPlaylists(context);
            context = new YouTubePlaylistsDbContext();
        }

        private static void SeedPlaylists(YouTubePlaylistsDbContext context)
        {
            if (context.Playlists.Any())
            {
                return;
            }

            var authors = context.Users.ToList();
            var categoriesCount = context.Categories.Count();
            var random = new Random();

            for (int i = 1; i <= 10; i++)
            {
                var pl = new Playlist
                {
                    Creator = authors[random.Next(0, authors.Count)],
                    CategoryId = random.Next(1, categoriesCount + 1),
                    Title = $"Playlist_{i}",
                    Description = $"Playlist_{i} description...",
                };

                var videosCount = random.Next(3, 6);
                for (int j = 0; j < videosCount; j++)
                {
                    var vid = new Video
                    {
                        Url = videoUrls[random.Next(0, videoUrls.Length)]
                    };

                    pl.Videos.Add(vid);
                }

                for (int j = 1; j <= 5; j++)
                {
                    var rating = new Rating
                    {
                        User = authors[j],
                        Value = random.Next(1, 6)
                    };

                    pl.Ratings.Add(rating);
                }

                context.Playlists.Add(pl);
            }

            context.SaveChanges();
        }

        private static void SeedRoles(YouTubePlaylistsDbContext context)
        {
            if (!context.AppRoles.Any())
            {
                context.AppRoles.Add(new AppRole("Administrator"));
                context.AppRoles.Add(new AppRole("User"));
                context.SaveChanges();
            }

        }

        private static void SeedCategories(YouTubePlaylistsDbContext context)
        {
            if (context.Categories.Any())
            {
                return;
            }

            for (int i = 1; i <= 30; i++)
            {
                var cat = new Category
                {
                    Name = $"Cat_{i}",
                };

                context.Categories.Add(cat);
            }

            context.SaveChanges();
        }

        private static void SeedUsers(YouTubePlaylistsDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var admin = new User()
            {
                UserName = "admin@site.com",
                Email = "admin@site.com",
                FirstName = $"adminFN",
                LastName = $"adminLN",
                PasswordHash = new PasswordHasher().HashPassword("admin"),
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var roles = context.AppRoles.ToList();

            admin.AppRoles.Add(roles[0]);

            context.Users.AddOrUpdate(admin);

            var random = new Random();
            for (int i = 1; i <= 5; i++)
            {
                var user = new User()
                {
                    Email = $"user{i}@site.com",
                    UserName = $"user{i}@site.com",
                    FirstName = $"user{i}FN",
                    LastName = $"user{i}LN",
                    PasswordHash = new PasswordHasher().HashPassword($"user{i}"),
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                user.AppRoles.Add(roles[1]);

                context.Users.Add(user);
            }

            context.SaveChanges();
        }
    }
}
