namespace ConsoleClient
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public class ForumData : IForumData
    {
        private const string ForumsApi = "http://jsonplaceholder.typicode.com/posts";

        private IHttpClient client;

        public ForumData(IHttpClient client)
        {
            this.client = client;
        }

        public IEnumerable<string> GetPosts(string searchKey)
        {
            Task<string> postsResponse = this.client.GetHttpResponse(ForumsApi, GenericHttpClient.JsonHeader);
            var posts = JsonConvert.DeserializeObject<List<Post>>(postsResponse.Result);
            var filteredPosts = posts.Where(x => x.Title.Contains(searchKey)).Select(x => x.Title);

            return filteredPosts;
        }
    }
}