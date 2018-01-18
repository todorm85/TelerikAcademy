using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MusicAlbumsClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // IMPORTANT: DO NOT FORGET TO SET THE PROPER LOCALHOST PORT!!!!!!!!!!!!!!!!!!
            string artistsApi = "http://localhost:52175/api/artists";


            string jsonHeader = "application/json";
            string xmlHeader = "application/xml";


            Console.WriteLine("Creating artist");
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Name", "ConsoleArtist2")
            });

            Task<string> createArtistResponse = CreateEntity(artistsApi, content);
            Console.WriteLine(createArtistResponse.Result);

            Console.WriteLine("Artists as json");
            Task<string> requestArtists = GetHttpResponse(artistsApi, jsonHeader);
            Console.WriteLine(requestArtists.Result);

            Console.WriteLine("\nArtists as xml");
            Task<string> requestAlbums = GetHttpResponse(artistsApi, xmlHeader);
            Console.WriteLine(requestAlbums.Result);
        }

        public static async Task<string> GetHttpResponse(string api, string acceptHeader)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(acceptHeader));

            var response = await client.GetAsync(new Uri(api));
            var contents = await response.Content.ReadAsStringAsync();

            return contents;
        }

        public static async Task<string> CreateEntity(string api, FormUrlEncodedContent content)
        {
            HttpClient client = new HttpClient();

            var response = await client.PostAsync(api, content);
            var contents = await response.Content.ReadAsStringAsync();

            return contents;
        }
    }
}
