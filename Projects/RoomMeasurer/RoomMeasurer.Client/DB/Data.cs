﻿namespace RoomMeasurer.Client.DB
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using SQLite.Net;
    using SQLite.Net.Platform.WinRT;
    using Windows.Storage;
    using DB.Models;
    using SQLite.Net.Async;
    public class Data
    {
        public const string SettingsFileName = "focus.txt";
        private readonly string dbFilePath;
        private SQLiteConnectionWithLock dbContext;
        private StorageFolder localFolder;
        private SQLiteAsyncConnection connection;

        public Data()
        {
            // will be created if non-existent
            this.dbFilePath = Path.Combine(
                ApplicationData.Current.LocalFolder.Path,
                "db.sqlite");

            this.dbContext = new SQLiteConnectionWithLock(
                         new SQLitePlatformWinRT(),
                         new SQLiteConnectionString(
                             dbFilePath,
                             storeDateTimeAsTicks: false)
                         );

            this.init();

            this.localFolder = ApplicationData.Current.LocalFolder;

        }

        private async void init()
        {
            this.connection = new SQLiteAsyncConnection(() => { return this.dbContext; });
            await this.connection.CreateTableAsync<UserDatabaseModel>();
        }

        public async Task UpdateCurrentUserAsync(UserDatabaseModel user)
        {
            if (user == null)
            {
                return;
            }

            await this.connection.DeleteAllAsync<UserDatabaseModel>();

            await this.connection.InsertAsync(user);
        }

        public async Task<UserDatabaseModel> GetCurrentUser()
        {
            var result = await this.connection.Table<UserDatabaseModel>().ToListAsync();

            if (result == null || result.Count <= 0)
            {
                return null;
            }

            return result[0];
        }

        public async void SaveFocusDistance(double f)
        {
            var files = await this.localFolder.GetFilesAsync();
            var textFile = files.FirstOrDefault(x => x.Name == SettingsFileName);
            if (textFile == null)
            {
                textFile = await this.localFolder.CreateFileAsync(SettingsFileName);
            }

            await FileIO.WriteTextAsync(textFile, f.ToString());
        }

        /// <summary>
        /// Gets the previously saved focus distance.
        /// </summary>
        /// <returns>Returns the focus distance or -1 if not found.</returns>
        public async Task<double> GetFoucsDistance()
        {
            var files = await this.localFolder.GetFilesAsync();
            var desiredFile = files.FirstOrDefault(x => x.Name == SettingsFileName);
            if (desiredFile == null)
            {
                return -1;
            }

            var textContent = await FileIO.ReadTextAsync(desiredFile);
            var focus = double.Parse(textContent);

            return focus;
        }
    }
}