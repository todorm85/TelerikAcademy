namespace Common
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class InputProvider
    {
        private const string InvalidInputFormatMessage = "Invalid input format for {0}";
        private TextReader inputStream;

        public InputProvider(TextReader inputStream)
        {
            this.inputStream = inputStream;
        }

        public List<T> ReadAllLines<T>(string breakLine)
            where T : IConvertible
        {
            List<T> inputValues = new List<T>();

            string currentInputLine = this.inputStream.ReadLine();
            while (currentInputLine != breakLine)
            {
                T parsedInput = this.ParseString<T>(currentInputLine);
                inputValues.Add(parsedInput);

                currentInputLine = this.inputStream.ReadLine();
            }

            return inputValues;
        }

        public List<T> ReadAllLines<T>(int linesCount)
            where T : IConvertible
        {
            List<T> inputValues = new List<T>();

            for (int i = 0; i < linesCount; i++)
            {
                string currentInputLine = this.inputStream.ReadLine();
                T parsedInput = this.ParseString<T>(currentInputLine);
                inputValues.Add(parsedInput);
            }

            return inputValues;
        }

        public List<T> ReadAllLines<T>(Predicate<T> breakCondition)
            where T : IConvertible, IComparable
        {
            List<T> inputValues = new List<T>();

            while (true)
            {
                string currentInputLine = this.inputStream.ReadLine();
                T parsedInput = this.ParseString<T>(currentInputLine);
                inputValues.Add(parsedInput);

                if (breakCondition(parsedInput))
                {
                    break;
                }
            }

            return inputValues;
        }

        public T ReadLine<T>()
            where T : IConvertible
        {
            string currentInputLine;

            currentInputLine = this.inputStream.ReadLine();

            T parsedInput = this.ParseString<T>(currentInputLine);

            return parsedInput;
        }

        private T ParseString<T>(string input)
            where T : IConvertible
        {
            var thisType = default(T);
            var typeCode = thisType.GetTypeCode();

            switch (typeCode)
            {
                case TypeCode.Int32:
                    int parsedInt;
                    if (!int.TryParse(input, out parsedInt))
                    {
                        throw new ArgumentException(InvalidInputFormatMessage, thisType.ToString());
                    }

                    return (T)Convert.ChangeType(parsedInt, typeCode);

                case TypeCode.UInt32:
                    uint parsedUint;
                    if (!uint.TryParse(input, out parsedUint))
                    {
                        throw new ArgumentException(InvalidInputFormatMessage, thisType.ToString());
                    }

                    return (T)Convert.ChangeType(parsedUint, typeCode);

                case TypeCode.String:
                    return (T)Convert.ChangeType(input, typeCode);

                default:
                    throw new ArgumentException("Unsupported input type.");
            }

            //return default(T);
        }
    }
}