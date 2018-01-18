namespace BullsAndCows.Services.Data
{
    using System;
    using System.Linq;
    using BullsAndCows.Data.Contracts;
    using BullsAndCows.Data.Models;
    using Contracts;

    public class GamesService : IGamesService
    {
        private IUow uow;
        private IUsersService usersService;
        private static Random rand = new Random();

        public GamesService(IUow uow)
        {
            this.uow = uow;
            this.usersService = new UsersService(uow);
        }

        public void AddNewGame(Game game, string username)
        {
            string userId = this.usersService.UserIdByUsername(username);
            game.RedPlayerId = userId;
            this.uow.Games.Add(game);
            this.uow.SaveChanges();
        }

        public IQueryable<Game> GetAll(string username, int page)
        {
            string userId = this.usersService.UserIdByUsername(username);

            var games = this.uow.Games.All()
                .OrderBy(x => x.GameState)
                .ThenBy(x => x.Name)
                .ThenBy(x => x.DateCreated)
                .ThenBy(x => x.RedPlayer.UserName)
                .Skip(page * 10)
                .Take(10)
                .Where(x => x.GameState == 0 || (x.GameState != 0 && (x.BluePlayerId == userId || x.RedPlayerId == userId)));

            return games;
        }

        public Game GetDetailedGameProgressInfo(int id, string username)
        {
            var game = this.uow.Games.GetById(id);
            if (game == null)
            {
                return null;
            }

            if (game.RedPlayer.UserName != username && game.BluePlayer.UserName != username)
            {
                return null;
            }

            if (game.GameState != GameState.BlueInTurn && game.GameState != GameState.RedInTurn)
            {
                return null;
            }

            return game;
        }

        public string JoinAvailableGame(int id, string username, string number)
        {
            var game = this.uow.Games.GetById(id);
            if (game == null)
            {
                return null;
            }

            if (game.GameState != GameState.WaitingForOpponent)
            {
                return null;
            }

            if (game.RedPlayer.UserName == username)
            {
                return null;
            }

            var bluePlayerId = this.usersService.UserIdByUsername(username);
            game.BluePlayerId = bluePlayerId;
            game.BlueSecretNumber = number;
            game.GameState = (rand.Next(1,100) % 2 == 0) ? GameState.BlueInTurn : GameState.RedInTurn;
            //this.uow.Games.Update(game);
            this.uow.SaveChanges();

            return $"You joined {game.Name}";
        }
    }
}