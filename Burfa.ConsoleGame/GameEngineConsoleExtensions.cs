using System;
using Burfa.Common.Engine;

namespace Burfa.ConsoleGame
{
    public static class GameEngineConsoleExtensions
    {
        public static void ToConsole(this IGameEngine ge)
        {
            ge.Board.ToConsole();
            if (ge.LastTurnResult.State != GameState.Initial) Console.WriteLine("Last turn was " + (ge.LastTurnResult.IsValid ? "" : "not ") + "valid");
            Console.WriteLine("Current Player Turn : " + ge.CurrentPlayer);
        }
    }
}