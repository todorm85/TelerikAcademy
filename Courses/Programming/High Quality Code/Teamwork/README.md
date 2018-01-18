a# “Bulls-and-Cows”

This is the teamwork project of `"Bulls-And-Cows-2"` team for the course High-Quality Program Code at Telerik Academy from 2015. It contains the famous Bulls And Cows game as described [here](https://en.wikipedia.org/wiki/Bulls_and_Cows). The game is written in C\# following best practices for high-quality code.

For full task description see [TASK DESCRIPTION](https://github.com/todorm85/Bulls-and-Cows-2/blob/master/TASK-DESCRIPTION.md)

## Refactoring Documentation

These are the step-by-step descriptions of modifications and extensions that were applied to the original source code, listed chronologically from oldest to newest. The original source code can be found in /before, the new code in /src.

1.  Renamed classes, variables, methods from source code [(link to commit)](https://github.com/todorm85/Bulls-and-Cows-2/commit/ef60eb4666775fbf61b0eda03cfc47783e434c47)
    -   Renamed the project to `BullsAndCowsGame`.
    -   Renamed the main class `Program`, which is the application entry point, to `Start`.
    -   Renamed the data class `rezultat`, which contains the result from attempted guess, to `GuessTryResult`
    -   Renamed the data class `BullsAndCowsNumber`, which contains the secret number, to `SecretNumber`
    -   Renamed methods and classes to `PascalCase` e.g. `gameScore` data class to `GameScore`
    -   Renamed fields, properties and methods in class `SecretNumber`
        -   field `rrr` to `randomNumber`
        -   field `cheatNumber` to `secretNumber`
        -   method `GenerateRandomNumbers` to `GenerateRandomSecretNumber`
        -   method `TryToGuess` to `MakeGuess`
    -   Renamed fields, properties and methods in class `GameScore`
        -   constructor parameter `ime` to `playerName`
        -   constructor parameter `guesses` to `guessTryCount`
        -   property `Name` to `PlayerName`
        -   property `Guesses` to `GuessTryCount`

2.  Reformatted the source code [(link to commit)](https://github.com/todorm85/Bulls-and-Cows-2/commit/ef60eb4666775fbf61b0eda03cfc47783e434c47):
    -   Removed all unneeded empty lines, e.g. in the method `GameScore.CompareTo()`
    -   Split the lines containing several statements into several simple lines, e.g. in GameScores.Deserialize:
    
    Before:
    
        if (dataAsStringArray.Length != 2) return null;
        
    After:

        if (dataAsStringArray.Length != 2)
        {
            return null;
        }

3. Refactored the game structure and used dependency inversion and `Strategy` design pattern through abstraction to make the code extendable and maintainable [(link to commit)](https://github.com/todorm85/Bulls-and-Cows-2/commit/7578714e28b4e2f9d878753497908496d7a162fc)
    -   Introduce `ConsoleInputProvider` and `ConsoleOutputProvider` classes for printing to the console and reading from the console. Introduce abstraction with interfaces - `IInputProvider` and `IOutputProvider`.
    -   Extracted all data related to Secret Number state from `SecretNumber` to `FourDigitSecretNumber` class. Left only data related to game logic in `SecretNumber` class and renamed it to `GameLogic`
    -   Introduce `IGameLogic` interface from `GameLogic` class. Used `GameLogic` through that abstraction which completes the `Strategy` design pattern impementation
    -   Renamed `ScoreBoard` to `GameStatistics` and extracted `IScore` interface. Used `GameStatistics` through `IScore`.
    -   Introduced constants in class Globals
    -   Introduced `GameEngine` class to hold the main game loop and in-game context data and move all related functionality from `EntryPoint` to it.

4.  Organized classes and interfaces in directories e.g. `ConsoleInputProvider` class into folder `/InputProviders` and `IInputProvider` interface into folder `/InputProviders/Contracts`  [(link to commit)](https://github.com/todorm85/Bulls-and-Cows-2/commit/6965e04781080258b44552fe39ba98856ab67314)

5.  Introduced `State` and `Abstract Factory` design patterns. [(link to commit)](https://github.com/todorm85/Bulls-and-Cows-2/commit/b33fd3c3abd4ec3db3844615a635574c08b9f07c)
    -   The Game class is the state machine. Each state implements `IGameState` interface. `IGameState` has three public methods needed by the main game loop - Render(), GetInput() and Update(). 
    -   Extracted the main game loop from `GameManager` class, which was renamed to `InGameState`. The main game loop is in EntryPoint class. 
    -   Introduced StartMenuState class, which defines the initial behaviour of the game
    -   Introduced `IStateFactory` interface and `GameStateFactory` class that is used through that interface. The class`s main purpose is to hide the complex implementation details for different game states creation. It is also implemented through abstraction via the interface so can be substituted with another to generate dynamically different game state classes that implement `IGameState` interface  

6.  Moved `IInputProvider` and `IOutputProvider` properties from `InGameState` class to `Game` class so that they can be used globally by all game states. [(link to commit)](https://github.com/todorm85/Bulls-and-Cows-2/commit/c4513e5bd6b90f78340d3999ba91bb649c7cc0c7)

7. Renamed `IStatisticsManager` interface to `IScoreCalculator` because the new name defines the interface functionality more clearly. [(link to commit)](https://github.com/todorm85/Bulls-and-Cows-2/commit/a9295c5c6371c3748ec94bda66289552b2b9f02d)

8.  Moved `Game` class `State` property initialization to class`s consturctor. ALso the property is public and method SetState() was no longer needed and was removed. [(link to commit)](https://github.com/todorm85/Bulls-and-Cows-2/commit/404b8a60e9ab62df692fd6c28bfa15e29094e531)

9.  Removed public property Message and introduced private field message to class `StartMenuState`. The field is used only by the class so no public property is needed  [(link to commit)](https://github.com/todorm85/Bulls-and-Cows-2/commit/0c6ec60dc56ec8adbe57acc0748641cb0c9c447c)

10. Implemented Singleton for the console input.
[(link to commit)](https://github.com/todorm85/Bulls-and-Cows-2/commit/bc953d5aef3918f4a34da149cbaa3df153279d9f)

11. Fixed logic of the game. Added validation of the guess numbers. Added scoreboard from file. And some small fixes.
[(link to commit)](https://github.com/todorm85/Bulls-and-Cows-2/commit/f436c5664669abed3eb645ead6db8d4d1478ee64)

12. Added strategy pattern for the file input/output.
[(link to commit)](https://github.com/todorm85/Bulls-and-Cows-2/commit/6e345b3dc6a33dbe743cb91f30c613dbd3cea159)

13. Code formatting. Removed unused usings.
[(link to commit)](https://github.com/todorm85/Bulls-and-Cows-2/commit/a4c6c368e53998cd52a51e9271a0cabb397fc99c)


13. Implemented Template method for the game engine.
[(link to commit)](https://github.com/todorm85/Bulls-and-Cows-2/commit/94c74e844a26fb3f68dd917a789cf9ef0e3fb88d)

14. Added user notification for input.
[(link to commit)](https://github.com/todorm85/Bulls-and-Cows-2/commit/bba29a0d3c6511e6f95c725334c9d14b8dc3cc0c)

15. Fixed logic on check bulls and cows. Fixed scoreboard logic.
[(link to commit)](https://github.com/todorm85/Bulls-and-Cows-2/commit/fe44d91c53ad0e45170e5ffa5aee47a058c098c0)

	

