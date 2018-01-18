﻿using System.Linq;

namespace BullsAndCowsGame
{
    using System;
    using System.Collections.Generic;
    using BullsAndCowsGame.Engine;

    /// <summary>
    /// Handles the ingame state.
    /// </summary>
    public class InGameState : IGameState
    {
        private string command;
        private IGameLogic gameLogic;
        private string message;
        private IScoreCalculator scoreCalculator;
        private IFileIo fileIo;

        /// <summary>
        /// Initializes a new instance of the <see cref="InGameState"/> class.
        /// </summary>
        /// <param name="gameLogic">Object that holds the game logic.</param>
        /// <param name="gameStatistics">Object that holds the game statistics.</param>
        /// <param name="fileIo">Object that holds information where the data should be saved.</param>
        public InGameState(IGameLogic gameLogic, IScoreCalculator gameStatistics, IFileIo fileIo)
        {
            this.gameLogic = gameLogic;
            this.scoreCalculator = gameStatistics;
            this.fileIo = fileIo;
            this.message = "Welcome, please make your guess:";
        }

        /// <summary>
        /// Defines the game context.
        /// </summary>
        internal Game Context { get; set; }

        /// <summary>
        /// Renders the game data.
        /// </summary>
        public void Render()
        {
            this.Context.OutputProvider.Render(this.message);
        }

        /// <summary>
        /// Retrieves the user input.
        /// </summary>
        public void GetInput()
        {
            this.command = this.Context.InputProvider.GetInput();
        }

        /// <summary>
        /// Handles the user commands.
        /// </summary>
        public void Update()
        {
            switch (this.command)
            {
                case "top":
                    this.message = string.Format(this.scoreCalculator.ScoreToString());
                    break;
                case "restart":
                    this.Context.State = this.Context.StateFactory.GetStartMenuState(this.Context);
                    break;
                case "help":
                    this.message = string.Format("The number looks like {0}.", this.gameLogic.GetCheat());
                    if (this.scoreCalculator.CheatsCount < 4)
                    {
                        this.scoreCalculator.CheatsCount++;
                    }

                    break;
                case "exit":
                    this.Context.IsOver = true;
                    break;

                default:
                    if (this.ValidateCommand(this.command))
                    {
                        this.MakeGuess(this.command);
                    }

                    break;
            }
        }

        private void MakeGuess(string command)
        {
            GuessResult guessResult = this.gameLogic.GetGuessResult(command);
            this.scoreCalculator.GuessCount++;
            if (guessResult.Bulls == 4)
            {
                this.ProcessResultsOnGuessedNumber();
                this.fileIo.SaveToFile(Constants.ScoresFile);
                this.Context.IsOver = true;
            }
            else
            {
                this.message = string.Format("{0} {1}", Constants.WrongNumberMessage, guessResult);
            }
        }

        private bool CheckIfNumberAttempted(string number)
        {
            if (this.scoreCalculator.AttemptedNumbers.Count == 0)
            {
                this.scoreCalculator.AttemptedNumbers.Add(number);

                return false;
            }
            if (this.scoreCalculator.AttemptedNumbers.Any(x => x == number))
            {
                this.message = "You already tried this number!!!";
                return true;
            }

            this.scoreCalculator.AttemptedNumbers.Add(number);

            return false;
        }

        private void ProcessResultsOnGuessedNumber()
        {
            if (this.scoreCalculator.CheatsCount == 0)
            {
                this.Context.OutputProvider.Render(string.Format(Constants.NumberGuessedWithoutCheats, this.scoreCalculator.GuessCount, this.scoreCalculator.GuessCount == 1 ? "attempt" : "attempts"));
                string name = this.Context.InputProvider.GetInput();
                while (!this.scoreCalculator.AddScore(name, this.scoreCalculator.GuessCount))
                {
                    this.Context.OutputProvider.Render("The name is taken");
                    //Console.WriteLine("The name is taken");
                    name = this.Context.InputProvider.GetInput();
                }

                this.fileIo.ScoreBoard.Add(name, this.scoreCalculator.GuessCount);

            }
            else
            {
                this.Context.OutputProvider.Render(string.Format(
                    Constants.NumberGuessedWithCheats,
                    this.scoreCalculator.GuessCount,
                    this.scoreCalculator.GuessCount == 1 ? "attempt" : "attempts",
                    this.scoreCalculator.CheatsCount,
                    this.scoreCalculator.CheatsCount == 1 ? "cheat" : "cheats"));
            }
            //this.fileIo.UpdateScore(Constants.ScoresFile);
            this.Context.OutputProvider.Render(this.scoreCalculator.ScoreToString());
        }

        private bool ValidateForRepeatingDigits(string number)
        {
            var arrOfChars = number.ToCharArray();
            HashSet<char> chars = new HashSet<char>();

            foreach (var charItem in arrOfChars)
            {
                chars.Add(charItem);
            }

            if (number.Length != chars.Count)
            {
                this.message = "You have repeating digits!!!";
                return false;

            }

            return true;
        }

        private bool ValidateIfAllAreDigits(string number)
        {
            if (number.ToCharArray().Any(num => (num < '0' || num > '9')) || number[0] < '1')
            {
                this.message = "Invalid number! Not all are digits or first digit is 0!!!";
                return false;
            }

            return true;
        }

        private bool ValidateCommand(string command)
        {
            if (string.IsNullOrEmpty(command) || command.Length != 4)
            {
                this.message = Constants.InvalidCommandMessage;
                return false;
            }

            if (!ValidateIfAllAreDigits(command))
            {
                return false;
            }

            if (!this.ValidateForRepeatingDigits(command))
            {
                return false;
            }

            if (CheckIfNumberAttempted(command))
            {
                return false;
            }


            return true;
        }


    }
}