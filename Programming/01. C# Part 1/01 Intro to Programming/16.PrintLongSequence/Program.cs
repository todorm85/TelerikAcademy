using System;

class PrintLongSequence
{
    static void Main()
    {
        int PosNum = 0;
        int NegNum = -1;

        for (int i = 0; i < 500; i++)                   //cycle that will run 500 times, printing 2 numbers each cycle, total 1000
        {
            Console.WriteLine(PosNum + 2);
            Console.WriteLine(NegNum - 2);
            PosNum += 2;                                //increments PosNum with 2
            NegNum -= 2;                                //decrements NegNum with 2
        }
    }
}

