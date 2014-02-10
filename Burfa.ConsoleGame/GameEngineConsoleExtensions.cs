using Burfa.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
