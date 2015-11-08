namespace ConsoleClient
{
    using System;

    internal class Startup
    {
        private static void Main(string[] args)
        {
            var httpClient = new GenericHttpClient();
            var forumData = new ForumData(httpClient);
            var forumClientApp = new ForumClientApp(forumData);

            forumClientApp.Start();
        }
    }
}