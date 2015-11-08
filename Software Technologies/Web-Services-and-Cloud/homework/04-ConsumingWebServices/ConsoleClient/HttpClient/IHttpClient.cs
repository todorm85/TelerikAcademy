namespace ConsoleClient
{
    using System.Threading.Tasks;

    public interface IHttpClient
    {
        Task<string> GetHttpResponse(string api, string acceptHeader);
    }
}