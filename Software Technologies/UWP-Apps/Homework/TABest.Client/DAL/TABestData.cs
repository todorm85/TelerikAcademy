namespace TABest.Client.Data
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using DAL.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    public class TABestData
    {
        private const string ProjectsUrl = "http://best.telerikacademy.com/api/projects/popular";

        private HttpClient httpClient;

        public TABestData()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<IEnumerable<Project>> GetPopularProjects()
        {
            var response = await this.httpClient.GetAsync(ProjectsUrl);

            var data = await response.Content.ReadAsStringAsync();

            var task = new TaskFactory();

            var rawData = await task.StartNew(() => JObject.Parse(data));

            var rawProjects = rawData["data"];

            var projects = await task.StartNew(() => rawProjects.ToObject<List<Project>>());

            //var projects = new List<Project>();

            return projects;
        }
    }
}