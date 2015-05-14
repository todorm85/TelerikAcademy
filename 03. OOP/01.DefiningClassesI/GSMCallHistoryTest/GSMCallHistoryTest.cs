using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone
{
    class GSMCallHistoryTest
    {
        static void Main()
        {
            // create test GSM
            string delimiter = new string('\xA', 3) + new string('-', 35);
            GSM genericGsm = new GSM("Test model", "Test manufacturer");

            // add calls
            var date1 = new DateTime(2014, 03, 10, 04, 55, 0);
            var date2 = new DateTime(2014, 03, 10, 13, 55, 0);
            var date3 = new DateTime(2014, 03, 10, 18, 55, 0);
            genericGsm.AddCall(new Call(date1, "+359885985678", 90));
            genericGsm.AddCall(new Call(date2, "+359885985678", 120));
            genericGsm.AddCall(new Call(date3, "+359885985678", 70));


            // display calls
            Console.WriteLine("DISPLAY ALL CALLS");
            PrintCallHistory("\nNEXT CALL\n", genericGsm);


            // calculate total price of calls
            Console.WriteLine(delimiter);
            Console.WriteLine("CALCULATE TOTAL BILL");
            Console.WriteLine("Total Bill: {0:0.00}", genericGsm.TotalCallsBill());


            // remove longest call
            Console.WriteLine(delimiter);
            Console.WriteLine("REMOVE LONGEST CALL");
            int maxDuration = 0;
            int maxDurationIndex = 0;
            for (int i = 0; i < genericGsm.CallHistory.Count; i++)
            {
                if (genericGsm.CallHistory[i].Duration > maxDuration)
                {
                    maxDuration = genericGsm.CallHistory[i].Duration;
                    maxDurationIndex = i;
                }
            }

            genericGsm.DeleteCall(maxDurationIndex);
            Console.WriteLine("CALCULATE TOTAL BILL");
            Console.WriteLine("Total Bill: {0:0.00}", genericGsm.TotalCallsBill());


            // clear call history and print
            Console.WriteLine(delimiter);
            Console.WriteLine("CLEAR CALL HISTORY AND PRINT");
            genericGsm.ClearCalls();
            PrintCallHistory(delimiter, genericGsm);
        }               

        private static void PrintCallHistory(string delimiter, GSM genericGsm)
        {
            foreach (var call in genericGsm.CallHistory)
            {
                Console.WriteLine(delimiter);

                Console.WriteLine("Date: {0}", call.Date);
                Console.WriteLine("Dialed Number: {0}", call.DialedNumber);
                Console.WriteLine("Call Duration: {0}", call.Duration);
            }
        }
    }
}
