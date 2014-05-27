using System;
using Burfa.Common.Board;
using Burfa.Common.Engine;
using Ninject;

namespace Burfa.ConsoleGame
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IGameRules>().To<Rules>().InSingletonScope();
                kernel.Bind<IGameEngine>().To<Engine>().InSingletonScope();
                kernel.Bind<IGameBoard>().To<Board>().InSingletonScope();
                var engine = kernel.Get<IGameEngine>();
                engine.ToConsole();
                while (true)
                {
                    Console.WriteLine("Enter move as X,Y:");
                    string line = Console.ReadLine();
                    string[] coords = line.Split(',');
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
            bool result = (int.TryParse(coords[0], out tryX) && int.TryParse(coords[1], out tryY));
            x = tryX;
            y = tryY;
            return result;
        }
    }
}