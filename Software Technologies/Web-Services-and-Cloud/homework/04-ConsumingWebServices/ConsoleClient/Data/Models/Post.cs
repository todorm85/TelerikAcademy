namespace ConsoleClient
{
    using Newtonsoft.Json;

    public class Post
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
    }
}