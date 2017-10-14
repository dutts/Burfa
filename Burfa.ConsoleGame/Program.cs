using System;
using Autofac;
using Burfa.Bots;
using Burfa.Common.Board;
using Burfa.Common.Engine;
using Burfa.Common.Engine.Types;

namespace Burfa.ConsoleGame
{
    internal class Program
    {
        private static IContainer Container;

        private static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Game>().As<IGame>().SingleInstance();
            builder.RegisterType<Board>().As<IGameBoard>().SingleInstance();
            builder.RegisterType<RandomBot>().As<IBurfaBot>().SingleInstance().WithParameter("Player", Player.White);
            Container = builder.Build();

            using (var scope = Container.BeginLifetimeScope())
            {
                var game = scope.Resolve<IGame>();
                game.ToConsole();
            

                var computerPlayer = scope.Resolve<IBurfaBot>();

                while ((game.CurrentGameState == GameState.InPlay) || (game.CurrentGameState == GameState.Initial))
                {
                    if (game.CurrentPlayer == Player.Black)
                    {
                        Console.WriteLine("Enter move as X,Y. S to skip or Q to quit:");
                        string line = Console.ReadLine();
                        if (line.ToUpper() == "Q") break;
                        if (line.ToUpper() == "S")
                        {
                            game.SkipTurn();
                        }
                        else
                        {
                            string[] coords = line.Split(',');
                            int x, y;
                            if (coords.Length != 2 || !TryParseCoords(coords, out x, out y)) continue;
                            game.TakeTurn(x, y);                            
                        }
                        game.ToConsole();
                    }
                    else // BOT
                    {
                        var computerTurn = computerPlayer.GetTurn();
                        game.TakeTurn(computerTurn.Item1, computerTurn.Item2);
                        game.ToConsole();
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