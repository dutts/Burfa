using Burfa.Common.Board;
using Burfa.Common.Engine;

namespace Burfa.GameConsole
{
    public static class GameBoardConsoleExtensions
    {
        public static void ToConsole(this IGameBoard gb)
        {
            System.Console.Clear();
            for (int i = 0; i < gb.BoardEdgeLength; i++)
            {
                if (i == 0) System.Console.Write("  ");
                if (i == gb.BoardEdgeLength - 1) System.Console.WriteLine("  " + i + " ");
                else
                {
                    System.Console.Write("  " + i + " ");
                }
            }
            for (int i = 0; i < gb.BoardEdgeLength; i++)
            {
                if (i == 0) System.Console.Write("  |---");
                else
                {
                    System.Console.Write("|---");
                }
                if (i == gb.BoardEdgeLength - 1) System.Console.WriteLine("|");
            }
            for (int i = 0; i < gb.BoardEdgeLength; i++)
            {
                System.Console.Write(i + " ");
                for (int j = 0; j < gb.BoardEdgeLength; j++)
                {
                    System.Console.Write("| ");
                    BoardSquare gameSquare = gb.GetGameBoardSquare(j, i);
                    System.Console.Write(gameSquare.State == null ? " " : gameSquare.State == Player.Black ? "B" : "W");
                    System.Console.Write(" ");

                    if (j == gb.BoardEdgeLength - 1) System.Console.WriteLine("|");
                }
                for (int j = 0; j < gb.BoardEdgeLength; j++)
                {
                    if (j == 0)
                    {
                        System.Console.Write("  |---");
                    }
                    else
                    {
                        System.Console.Write("|---");
                    }
                    if (j == gb.BoardEdgeLength - 1) System.Console.WriteLine("|");
                }
            }
        }
    }
}