
namespace _02_DayOfWeekService.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DayOfWeekService;

    class Startup
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            var service = new DayOfWeekClient();
            var dayOfWeekBg = service.GetDayOWeek(DateTime.Now);

            // CHANGE CONSOLE FONT TO CONSOLAS
            Console.WriteLine(dayOfWeekBg);
        }
    }
}
