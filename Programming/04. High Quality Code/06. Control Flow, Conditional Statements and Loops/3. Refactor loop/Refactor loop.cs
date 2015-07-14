class EntryPoint
{
    void Main()
    {
        int i = 0;
        for (i = 0; i < 100; i++)
        {
            Console.WriteLine(array[i]);

            if (i % 10 == 0 && array[i] == expectedValue)
            {
                Console.WriteLine("Value Found");
                break;
            }
        }
    }
}