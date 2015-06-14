using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone
{
    class TestGSM
    {
        static void Main()
        {
            string delimiter = new string('-', 35);

            // define generic GSM with empty data
            GSM genericGsm = new GSM("Generic model", "Unknown manufacturer");
            Console.WriteLine(genericGsm);

            Console.WriteLine(delimiter);

            // define 3 GSM in array with some data
            Console.WriteLine("\nSpecs from GSMs in array:\n");

            GSM[] phone = new GSM[3]
            {
                new GSM("n1010","nokia",50,"Pe6o",
                new Battery("Nokia",8,18,BatteryType.LiIon),
                new Display(3.4,16000000)),

                new GSM("1598","LG",90,"Sa6o",
                new Battery("LG",14,25,BatteryType.LiIon),
                new Display()),

                new GSM("Galaxy10","Samsung",403.5M,"Gosho",
                new Battery("Samsung"),
                new Display(5.2,16000000)),
            };

            foreach (var gsm in phone)
            {
                Console.WriteLine(delimiter);
                Console.WriteLine(gsm + "\n");
            }

            Console.WriteLine(delimiter);
            Console.WriteLine("PRINT IPHONE DATA\n");
            Console.WriteLine(GSM.IPhone4S);
        }

    }
}