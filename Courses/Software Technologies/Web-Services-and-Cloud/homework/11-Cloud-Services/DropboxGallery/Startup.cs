namespace DropboxGallery
{
    using System;
    using System.IO;
    using System.Diagnostics;

    using Spring.Social.OAuth1;
    using Spring.Social.Dropbox.Api;
    using Spring.Social.Dropbox.Connect;
    using Spring.IO;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    class Startup
    {
        private const string DropboxAppKey = "YourKeyHere!!!!!!!!!!!!!!!!!!!!!";
        private const string DropboxAppSecret = "YourSecretHere!!!!!!!!!!!!!!!!!!!!!!!!";

        private const string OAuthTokenFileName = "OAuthTokenFileName.txt";

        static void Main()
        {
            IDropbox dataContext = GetDropboxContext();

            // Create new folder
            string newFolderName = "SharedGallery" + DateTime.Now.Ticks;
            var targetFolderEntry = CreateFolderAsync(dataContext, newFolderName).Result;

            // Upload files from local folder
            var sourceFolderPath = @"..\..\sourceImages";
            var uploadFileEntry = UploadFiles(dataContext, targetFolderEntry.Path, sourceFolderPath);

            // Share the folder
            DropboxLink sharedUrl = dataContext.GetShareableLinkAsync(targetFolderEntry.Path).Result;
            Process.Start(sharedUrl.Url);
        }

        private static List<Entry> UploadFiles(IDropbox dataContext, string targetFolderPath, string sourceFolderPath)
        {
            var uploadedFileEntries = new List<Entry>();

            var filePaths = Directory.GetFiles(sourceFolderPath);
            foreach (var filePath in filePaths)
            {
                var uploadFileEntry = UploadFileAsync(dataContext, targetFolderPath, filePath);
                uploadedFileEntries.Add(uploadFileEntry);
            }

            return uploadedFileEntries;
        }

        private static Entry UploadFileAsync(IDropbox dropbox, string targetFolderPath, string sourceFilePath)
        {
            var sourceFileName = Path.GetFileName(sourceFilePath);

            var uploadFileEntry = dropbox.UploadFileAsync(
                            new FileResource(sourceFilePath),
                            targetFolderPath + "/" + sourceFileName).Result;

            Console.WriteLine("Uploaded a file: {0}", uploadFileEntry.Path);
            return uploadFileEntry;
        }

        private static async Task<Entry> CreateFolderAsync(IDropbox dropbox, string newFolderName)
        {
            var createFolderEntry = await dropbox.CreateFolderAsync(newFolderName);
            Console.WriteLine("Created folder: {0}", createFolderEntry.Path);
            return createFolderEntry;
        }

        private static IDropbox GetDropboxContext()
        {
            DropboxServiceProvider dropboxServiceProvider =
                            new DropboxServiceProvider(DropboxAppKey, DropboxAppSecret, AccessLevel.AppFolder);

            // Authenticate the application (if not authenticated) and load the OAuth token
            if (!File.Exists(OAuthTokenFileName))
            {
                AuthorizeAppOAuth(dropboxServiceProvider);
            }

            OAuthToken oauthAccessToken = LoadOAuthToken();

            // Login in Dropbox
            IDropbox dropbox = dropboxServiceProvider.GetApi(oauthAccessToken.Value, oauthAccessToken.Secret);
            return dropbox;
        }

        private static OAuthToken LoadOAuthToken()
        {
            string[] lines = File.ReadAllLines(OAuthTokenFileName);
            OAuthToken oauthAccessToken = new OAuthToken(lines[0], lines[1]);
            return oauthAccessToken;
        }

        private static void AuthorizeAppOAuth(DropboxServiceProvider dropboxServiceProvider)
        {
            // Authorization without callback url
            Console.Write("Getting request token...");
            OAuthToken oauthToken = dropboxServiceProvider.OAuthOperations.FetchRequestTokenAsync(null, null).Result;
            Console.WriteLine("Done.");

            OAuth1Parameters parameters = new OAuth1Parameters();
            string authenticateUrl = dropboxServiceProvider.OAuthOperations.BuildAuthorizeUrl(
                oauthToken.Value, parameters);
            Console.WriteLine("Redirect the user for authorization to {0}", authenticateUrl);
            Process.Start(authenticateUrl);
            Console.Write("Press [Enter] when authorization attempt has succeeded.");
            Console.ReadLine();

            Console.Write("Getting access token...");
            AuthorizedRequestToken requestToken = new AuthorizedRequestToken(oauthToken, null);
            OAuthToken oauthAccessToken =
                dropboxServiceProvider.OAuthOperations.ExchangeForAccessTokenAsync(requestToken, null).Result;
            Console.WriteLine("Done.");

            string[] oauthData = new string[] { oauthAccessToken.Value, oauthAccessToken.Secret };
            File.WriteAllLines(OAuthTokenFileName, oauthData);
        }
    }

}
