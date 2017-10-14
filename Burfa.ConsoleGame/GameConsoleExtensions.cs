using System;
using Burfa.Common.Engine;
using Burfa.Common.Engine.Types;

namespace Burfa.ConsoleGame
{
    public static class GameConsoleExtensions
    {
        public static void ToConsole(this IGame game)
        {
            game.Board.ToConsole();
            if (game.LastTurnResult.State != GameState.Initial) Console.WriteLine("Last turn was " + (game.LastTurnResult.IsValid ? "" : "not ") + "valid");
            Console.WriteLine("Current Player Turn : " + game.CurrentPlayer);
        }
    }
}