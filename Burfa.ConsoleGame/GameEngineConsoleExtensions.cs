using System;
using Burfa.Common;

namespace Burfa.ConsoleGame
{
    public static class GameEngineConsoleExtensions
    {
        public static void ToConsole(this IGameEngine ge)
        {
            ge.Board.ToConsole();
            Console.WriteLine("Last turn was " + (ge.LastTurnResult.IsValid ? "" : "not ") + "valid");
            Console.WriteLine("Current Player Turn : " + ge.CurrentPlayer);
        }
    }
}