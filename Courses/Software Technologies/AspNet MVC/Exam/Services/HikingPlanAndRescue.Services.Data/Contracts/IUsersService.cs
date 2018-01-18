﻿namespace VoiceSystem.Services.Data.Contracts
{
    using System.Linq;
    using VoiceSystem.Data.Models;

    public interface IUsersService
    {
        IQueryable<ApplicationUser> GetAll();

        ApplicationUser GetById(string id);

        void Update();

        void AddUser(ApplicationUser user, string password);
        void Delete(string id);
    }
}