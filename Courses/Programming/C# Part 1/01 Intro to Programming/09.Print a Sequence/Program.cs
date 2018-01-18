using System;

class PrintASequence
{
    static void Main()
    {
        int PosNum = 0;
        int NegNum = -1;

        for (int i = 0; i < 5; i++)             //cycle that will run 5 times, printing 2 numbers each cycle
        {
            Console.WriteLine(PosNum + 2);
            Console.WriteLine(NegNum - 2);
            PosNum += 2;                        //increments PosNum with 2
            NegNum -= 2;                        //decrements NegNum with 2
        }
    }
}

