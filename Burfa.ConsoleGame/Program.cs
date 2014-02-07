using Burfa.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burfa.ConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new GameEngine();
            engine.ToConsole();
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                    break;
                else
                    engine.TakeTurn(engine.CurrentPlayer, -1, -1);
                    engine.ToConsole();

            }
        }
    }
}
