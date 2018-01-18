namespace SimpleTwitter.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using Contracts;
    using Models;

    public class SimpleTwitterData : ISimpleTwitterData
    {
        private readonly DbContext context;
        private readonly IDictionary<Type, object> repositories;

        // TODO: IoC injection
        public SimpleTwitterData()
        {
            this.context = new SimpleTwitterDbContext();
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users => this.GetRepository<User>();

        public IRepository<Tweet> Tweets => this.GetRepository<Tweet>();

        public IRepository<HashTag> HashTags => this.GetRepository<HashTag>();

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);

            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EfRepository<T>), this.context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}