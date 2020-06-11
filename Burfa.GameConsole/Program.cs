using Autofac;
using Burfa.Bots;
using Burfa.Common.Board;
using Burfa.Common.Engine;

namespace Burfa.GameConsole
{
    class Program
    {
        private static IContainer Container;

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Rules>().As<IGameRules>().SingleInstance();
            builder.RegisterType<Engine>().As<IGameEngine>().SingleInstance();
            builder.RegisterType<Board>().As<IGameBoard>().SingleInstance();
            builder.RegisterType<RandomBot>().As<IBurfaBot>().SingleInstance().WithParameter("Player", Player.White);
            Container = builder.Build();

            using (var scope = Container.BeginLifetimeScope())
            {
                var engine = scope.Resolve<IGameEngine>();
                engine.ToConsole();


                var computerPlayer = scope.Resolve<IBurfaBot>();

                while ((engine.CurrentGameState == GameState.InPlay) || (engine.CurrentGameState == GameState.Initial))
                {
                    if (engine.CurrentPlayer == Player.Black)
                    {
                        System.Console.WriteLine("Enter move as X,Y. S to skip or Q to quit:");
                        string line = System.Console.ReadLine();
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
