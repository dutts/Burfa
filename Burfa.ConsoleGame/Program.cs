using Burfa.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace Burfa.ConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IGameRules>().To<GameRules>().InSingletonScope();
                kernel.Bind<IGameEngine>().To<GameEngine>().InSingletonScope();
                kernel.Bind<IGameBoard>().To<GameBoard>().InSingletonScope();
                var engine = kernel.Get<IGameEngine>();
                engine.ToConsole();
                while (true)
                {
                    Console.WriteLine("Enter move as X,Y:");
                    var line = Console.ReadLine();
                    var coords = line.Split(',');
                    int x, y;
                    if (coords.Length != 2 || !TryParseCoords(coords, out x, out y)) break;
                    engine.TakeTurn(x, y);
                    engine.ToConsole();
                }
            }
        }

        public static bool TryParseCoords(string[] coords, out int x, out int y)
        {
            int tryX = -1;
            int tryY = -1;
            var result = (int.TryParse(coords[0], out tryX) && int.TryParse(coords[1], out tryY));
            x = tryX;
            y = tryY;
            return result;
        }
    }
}
