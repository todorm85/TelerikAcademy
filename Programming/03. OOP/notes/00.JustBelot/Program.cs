using System;
using JustBelot.Common;
using JustBelot.AI;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<IPlayer> players = new List<IPlayer>();

        players.Add(new HumanPlayer());
        players.Add(new Player());

        foreach (var player in players)
        {
            player.PlayCard();
        }
    }
}
