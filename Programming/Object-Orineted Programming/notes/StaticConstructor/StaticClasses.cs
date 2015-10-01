using System;

public static class Global
{
    static Global()
    {
        Console.WriteLine("Global()");
    }

    public static void Funct()
    {
        Console.WriteLine("Funct()");
    }
}

class Program
{
    static void Main()
    {
        Global.Funct();
        Global.Funct();
        Global.Funct();
    }
}
