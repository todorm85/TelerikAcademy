using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

//Problem 7. Timer
//•	Using delegates write a class Timer that can execute certain method at each t seconds.
public delegate void TestDelegate<T>();

public class Timer<T>
{
    private int seconds;
    private TestDelegate<T> actionDelegate;

    public TestDelegate<T> ActionDelegate
    {
        get { return actionDelegate; }
        set { actionDelegate = value; }
    }

    public int Seconds
    {
        get { return seconds; }
        set
        {
            if (value <= 0)
            {
                throw new Exception("Seconds must be >0");
            }

            seconds = value;
        }
    }

    public Timer(int seconds, TestDelegate<T> inDelegate)
    {
        this.Seconds = seconds;
        this.ActionDelegate = inDelegate;
    }

    public void StartTimer()
    {
        while (!Console.KeyAvailable)
        {
            this.ActionDelegate();
            Thread.Sleep(this.seconds * 1000);
        }
    }
}

class Program
{
    static void Main()
    {
        TestDelegate<string> test = delegate()
        {
            Console.WriteLine("First anonymous method called!");

        };

        test += () => Console.WriteLine("Second anonymous method called!");

        Timer<string> testSchedule = new Timer<string>(2, test);
        testSchedule.StartTimer();
    }
}

