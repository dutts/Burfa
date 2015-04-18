using System;
using Burfa.Bots;
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
                kernel.Bind<IBurfaBot>().To<RandomBot>().InSingletonScope().WithConstructorArgument("Player", Player.White);

                var engine = kernel.Get<IGameEngine>();
                engine.ToConsole();

                var computerPlayer = kernel.Get<IBurfaBot>();

                while ((engine.CurrentGameState == GameState.InPlay) || (engine.CurrentGameState == GameState.Initial))
                {
                    if (engine.CurrentPlayer == Player.Black)
                    {
                        Console.WriteLine("Enter move as X,Y. S to skip or Q to quit:");
                        string line = Console.ReadLine();
                        if (line.ToUpper() == "Q") break;
                        if (line.ToUpper() == "S")
                        {
                            engine.SkipTurn();
                        }
                        else
                        {
                            string[] coords = line.Split(',');
                            int x, y;
                            if (coords.Length != 2 || !TryParseCoords(coords, out x, out y)) continue;
                            engine.TakeTurn(x, y);                            
                        }
                        engine.ToConsole();
                    }
                    else // BOT
                    {
                        var computerTurn = computerPlayer.GetTurn();
                        engine.TakeTurn(computerTurn.Item1, computerTurn.Item2);
                        engine.ToConsole();
                    }
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