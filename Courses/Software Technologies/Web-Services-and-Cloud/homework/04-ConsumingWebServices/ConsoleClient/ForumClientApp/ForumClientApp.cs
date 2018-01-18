namespace ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ForumClientApp
    {
        private IForumData data;

        public ForumClientApp(IForumData data)
        {
            this.data = data;
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("\nWelcome to JSONPlaceholder console client app. Available commands are 'search', 'exit'");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "search":
                        SearchPosts();
                        break;

                    case "exit":
                        return;

                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }
            }
        }

        private void SearchPosts()
        {
            Console.WriteLine("Please enter your search key or nothing to see all posts: ");
            var searchKey = Console.ReadLine();

            IEnumerable<string> result = new List<string>();
            try
            {
                result = data.GetPosts(searchKey);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                while (e.InnerException != null)
                {
                    e = e.InnerException;
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine("Found posts:");
            Console.WriteLine(string.Join("\n", result.ToArray()));
            Console.WriteLine("\nSearch finidhed.\n");
        }
    }
}