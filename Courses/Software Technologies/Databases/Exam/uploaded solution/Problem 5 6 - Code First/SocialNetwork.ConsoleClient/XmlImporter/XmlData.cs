namespace SocialNetwork.ConsoleClient.XmlImporter
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using SocialNetwork.ConsoleClient.XmlImporter.XmlModels;
    using SocialNetwork.Data;
    using SocialNetwork.Models;

    public class XmlData
    {
        private SocialNetworkDbContext db = new SocialNetworkDbContext();

        public void ImportAllFriendships(string filePath)
        {
            var parsedFriendships = new Friendships();

            using (var xmlStream = new StreamReader(filePath))
            {
                var xmlSer = new XmlSerializer(typeof(Friendships)).Deserialize(xmlStream);
                parsedFriendships = (Friendships)xmlSer;
            }

            var existingDbUsernames = db.Users.Select(u => u.Username).ToList();

            foreach (var parsedFriendship in parsedFriendships.Friendship)
            {
                ImportFirstUser(parsedFriendship.FirstUser, existingDbUsernames);
                ImportSecondUser(parsedFriendship.SecondUser, existingDbUsernames);
                db.SaveChanges();

                ImportFriendshipAndMessages(parsedFriendship);

                OptimizedDbSave();
            }

            db.SaveChanges();
        }

        private void ImportFriendshipAndMessages(FriendshipsFriendship parsedFriendship)
        {
            var firstUsername = parsedFriendship.FirstUser.Username;
            var firstUser = db.Users.First(u => u.Username == firstUsername);

            var secondUsername = parsedFriendship.SecondUser.Username;
            var secondUser = db.Users.First(u => u.Username == secondUsername);

            var newFriendship = new Friendship()
            {
                ApprovalDate = (parsedFriendship.Approved == true) ? (DateTime?)DateTime.Parse(parsedFriendship.FriendsSince.ToString()) : null,
            };

            newFriendship.FirstUser = firstUser;
            newFriendship.SecondUser = secondUser;
            db.Friendships.Add(newFriendship);

            ImportMessages(newFriendship, parsedFriendship.Messages);

            //db.SaveChanges();
        }

        private void ImportMessages(Friendship newFriendship, FriendshipsFriendshipMessage[] messages)
        {
            foreach (var message in messages)
            {
                var newMessage = new Message()
                {
                    MessageContent = message.Content,
                    TimeSeen = (message.SeenOn != null) ? (DateTime?)DateTime.Parse(message.SeenOn) : null,
                    TimeSent = message.SentOn
                };

                newMessage.Friendship = newFriendship;

                // todo: possible bug>
                var author = db.Users.First(u => u.Username == message.Author);
                newMessage.User = author;

                db.Messages.Add(newMessage);
            }
            
            //db.SaveChanges();
        }

        private void ImportSecondUser(FriendshipsFriendshipSecondUser user, List<string> existingDbUsernames)
        {
            var newUser = new User()
            {
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                RegistrationDate = user.RegisteredOn,
            };

            var currentUsername = newUser.Username;
            if (!existingDbUsernames.Contains(currentUsername))
            {
                foreach (var image in user.Images)
                {
                    var newImage = new Image()
                    {
                        FileExtension = image.FileExtension,
                        ImageUrl = image.ImageUrl,
                    };

                    newUser.Images.Add(newImage);
                }

                db.Users.Add(newUser);
                existingDbUsernames.Add(currentUsername);
                //db.SaveChanges();
            }
        }

        private void ImportFirstUser(FriendshipsFriendshipFirstUser user, List<string> existingDbUsernames)
        {
            var newUser = new User()
            {
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                RegistrationDate = user.RegisteredOn,
            };

            var currentUsername = newUser.Username;
            if (!existingDbUsernames.Contains(currentUsername))
            {
                foreach (var image in user.Images)
                {
                    var newImage = new Image()
                    {
                        FileExtension = image.FileExtension,
                        ImageUrl = image.ImageUrl,
                    };

                    newUser.Images.Add(newImage);
                }

                db.Users.Add(newUser);
                existingDbUsernames.Add(currentUsername);
                //db.SaveChanges();
            }
        }

        private void OptimizedDbSave()
        {
            if (db.ChangeTracker.Entries().Count() > 100)
            {
                db.SaveChanges();
                db = new SocialNetworkDbContext();
                Console.Write(".");
            }
        }

        internal void ImportAllPosts(string filePath)
        {
            var parsedPosts = new Posts();

            using (var xmlStream = new StreamReader(filePath))
            {
                var xmlSer = new XmlSerializer(typeof(Posts)).Deserialize(xmlStream);
                parsedPosts = (Posts)xmlSer;
            }

            var existingDbUsernames = db.Users.Select(u => u.Username).ToList();

            foreach (var parsedPost in parsedPosts.Post)
            {
                var newPost = new Post()
                {
                    PostContent = parsedPost.Content,
                    PostDate = parsedPost.PostedOn,
                };

                var taggedUsernames = parsedPost.Users.Split(',').Select(x => x.Trim()).ToList();

                foreach (var username in taggedUsernames)
                {
                    var user = db.Users.First(u => u.Username == username);
                    user.Posts.Add(newPost);
                }

                db.Posts.Add(newPost);

                OptimizedDbSave();
            }

            db.SaveChanges();
        }
    }
}
