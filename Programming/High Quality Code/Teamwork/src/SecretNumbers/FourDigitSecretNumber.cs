namespace BullsAndCowsGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Represents the secret number as four digit number.
    /// </summary>
    internal class FourDigitSecretNumber : ISecretNumber
    {
        private Random randomDigit;
        private char[] revealedSecretNumber;

        /// <summary>
        /// Initializes a new instance of the <see cref="FourDigitSecretNumber"/> class.
        /// </summary>
        public FourDigitSecretNumber()
        {
            this.randomDigit = new Random();
            this.revealedSecretNumber = new char[4] { 'X', 'X', 'X', 'X' };
            this.Numbers = this.GenerateNewRandom();
        }

        /// <summary>
        /// Gets the first digit of the number.
        /// </summary>
        public int FirstDigit { get; private set; }

        /// <summary>
        /// Gets the second digit of the number.
        /// </summary>
        public int SecondDigit { get; private set; }

        /// <summary>
        /// Gets the third digit of the number.
        /// </summary>
        public int ThirdDigit { get; private set; }

        /// <summary>
        /// Gets the fourth digit of the number.
        /// </summary>
        public int FourthDigit { get; private set; }

        /// <summary>
        /// Holds the digits of the secret number.
        /// </summary>
        public HashSet<int> Numbers { get; set; }

        /// <summary>
        /// Holds the state of the currently revealed secret number.
        /// </summary>
        public char[] RevealedState
        {
            get
            {
                return this.revealedSecretNumber;
            }

            set
            {
                this.revealedSecretNumber = value;
            }
        }

        /// <summary>
        /// Generates random secret number based on the game rules.
        /// </summary>
        /// <returns>The secret number as HashSet.</returns>
        public HashSet<int> GenerateNewRandom()
        {
            var numbers = new HashSet<int>();

            while (numbers.Count < 4)
            {
                var item = 0;
                if (numbers.Count == 0)
                {
                    item = this.randomDigit.Next(1, 10);
                }
                else
                {
                    item = this.randomDigit.Next(0, 10);
                }

                numbers.Add(item);
            }

            this.FirstDigit = numbers.ElementAt(0);
            this.SecondDigit = numbers.ElementAt(1);
            this.ThirdDigit = numbers.ElementAt(2);
            this.FourthDigit = numbers.ElementAt(3);
            return numbers;
        }

        /// <summary>
        /// The secret number as string.
        /// </summary>
        /// <returns>String value representing the secret number.</returns>
        public override string ToString()
        {
            StringBuilder numberStringBuilder = new StringBuilder();
            numberStringBuilder.Append(this.revealedSecretNumber[0]);
            numberStringBuilder.Append(this.revealedSecretNumber[1]);
            numberStringBuilder.Append(this.revealedSecretNumber[2]);
            numberStringBuilder.Append(this.revealedSecretNumber[3]);
            return numberStringBuilder.ToString();
        }
    }
}