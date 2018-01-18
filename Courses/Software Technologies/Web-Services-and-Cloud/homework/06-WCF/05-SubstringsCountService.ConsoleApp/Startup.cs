
namespace _02_DayOfWeekService.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using _05_SubstringsCountService.ConsoleApp.SubstringsCountService;

    class Startup
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            var service = new SubstringsCountServiceClient();
            var countOfSubstring = service.GetSubstringsCount("abbabbbassa","a");

            // CHANGE CONSOLE FONT TO CONSOLAS
            Console.WriteLine(countOfSubstring);
        }
    }
}
