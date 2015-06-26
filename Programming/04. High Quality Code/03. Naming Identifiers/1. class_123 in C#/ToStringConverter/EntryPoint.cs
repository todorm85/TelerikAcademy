namespace ToStringConverter
{
    using System;

    internal class EntryPoint
    {
        public static void Main()
        {
            Converter converter = new Converter();
            var trueBoolValueAsString = converter.BoolToString(true);
            Console.WriteLine(trueBoolValueAsString);
        }
    }
}

