namespace BullsAndCowsGame
{
    using System;
    using System.Linq;

    /// <summary>
    /// Handles the entire game logic based on the standard rules. 
    /// </summary>
    public class StandardGameLogic : IGameLogic
    {
        private ISecretNumber secretNumber;

        /// <summary>
        /// Initializes a new instance of the <see cref="StandardGameLogic"/> class.
        /// </summary>
        /// <param name="secretNumber">Object that represents the secret number.</param>
        public StandardGameLogic(ISecretNumber secretNumber)
        {
            this.SecretNumber = secretNumber;
        }

        /// <summary>
        /// Gets the secret number.
        /// </summary>
        public ISecretNumber SecretNumber
        {
            get
            {
                return this.secretNumber;
            }

            private set
            {
                this.secretNumber = value;
            }
        }

        /// <summary>
        /// Reveals part of the secret number.
        /// </summary>
        /// <returns>String value containing the revealed part of the secret number.</returns>
        public string GetCheat()
        {
            if (this.SecretNumber.RevealedState.Contains('X'))
            {
                while (true)
                {
                    int randPossition = new Random().Next(0, 4);
                    if (this.secretNumber.RevealedState[randPossition] == 'X')
                    {
                        switch (randPossition)
                        {
                            case 0:
                                this.secretNumber.RevealedState[randPossition] = (char)(this.secretNumber.FirstDigit + '0');
                                break;
                            case 1:
                                this.secretNumber.RevealedState[randPossition] = (char)(this.secretNumber.SecondDigit + '0');
                                break;
                            case 2:
                                this.secretNumber.RevealedState[randPossition] = (char)(this.secretNumber.ThirdDigit + '0');
                                break;
                            case 3:
                                this.secretNumber.RevealedState[randPossition] = (char)(this.secretNumber.FourthDigit + '0');
                                break;
                        }

                        break;
                    }
                }
            }

            return this.secretNumber.ToString();
        }

        /// <summary>
        /// Logic for calculating the bulls and cows based on the guess and the secret number.
        /// </summary>
        /// <param name="number">The guess as string value.</param>
        /// <returns>Object of type GuessResult containing the guessed bulls and cows.</returns>
        public GuessResult GetGuessResult(string number)
        {
            if (string.IsNullOrEmpty(number) || number.Trim().Length != 4)
            {
                throw new ArgumentException("Invalid string number");
            }

            return this.GetGuessResult(number.ToCharArray());
        }

        /// <summary>
        /// Logic for calculating the bulls and cows based on the guess and the secret number.
        /// </summary>
        /// <param name="arr">The guess as char array.</param>
        /// <returns>Object of type GuessResult containing the guessed bulls and cows.</returns>
        private GuessResult GetGuessResult(char[] arr)
        {
            return this.CheckBullOrCow(arr);
        }

        private GuessResult CheckBullOrCow(char[] arr)
        {
            GuessResult guessResult = new GuessResult();
            for (int i = 0; i < arr.Length; i++)
            {
                var indexInSecretNumber = this.SecretNumber.Numbers.ToList().FindIndex(x => x == (arr[i] - '0'));

                if (indexInSecretNumber != i && indexInSecretNumber >= 0)
                {
                    guessResult.Cows++;
                }
                else if (indexInSecretNumber == i)
                {
                    guessResult.Bulls++;
                }
            }

            return guessResult;
        }
    }
}
