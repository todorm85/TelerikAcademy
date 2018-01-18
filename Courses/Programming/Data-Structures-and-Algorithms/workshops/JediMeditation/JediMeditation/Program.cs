using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediMeditation
{
    class Program
    {
        static void Main()
        {
            //GetSampleInput();

            int jedisCount = int.Parse(Console.ReadLine());
            var allJedis = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var masters = new List<string>();
            var knights = new List<string>();
            var paduans = new List<string>();

            for (int i = 0; i < jedisCount; i++)
            {
                var currentJedi = allJedis[i];

                if (currentJedi[0] == 'm')
                {
                    masters.Add(currentJedi);
                    continue;
                }

                if (currentJedi[0] == 'k')
                {
                    knights.Add(currentJedi);
                    continue;
                }

                paduans.Add(currentJedi);
            }

            var sb = new StringBuilder();
            for (int i = 0; i < masters.Count(); i++)
            {
                sb.Append(masters[i]);
                sb.Append(" ");
            }

            for (int i = 0; i < knights.Count(); i++)
            {
                sb.Append(knights[i]);
                sb.Append(" ");
            }

            for (int i = 0; i < paduans.Count(); i++)
            {
                sb.Append(paduans[i]);
                sb.Append(" ");
            }

            Console.WriteLine(sb.ToString());
        }

        private static void GetSampleInput()
        {
            var sample = @"3
m1 k1 p1";
            var sample2 = @"7
p4 p2 p3 m1 k2 p1 k1";
            Console.SetIn(new StringReader(sample2));
        }
    }
}
