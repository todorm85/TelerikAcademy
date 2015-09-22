namespace StatePattern
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var ivan = new Person("Ivan");
            ivan.Greet();
            ivan.GiveChocolate();
            ivan.Greet();
            ivan.GiveChocolate();
        }
    }
}