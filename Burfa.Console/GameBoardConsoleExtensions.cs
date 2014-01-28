using Burfa.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burfa.Console
{
    public static class GameBoardConsoleExtensions
    {
        public static void ToConsole(this GameBoard gb)
        {
            System.Console.Clear();
            for (int i = 0; i < gb.BoardEdgeLength; i++)
            {
                System.Console.Write("|---");
                if (i == gb.BoardEdgeLength - 1) System.Console.WriteLine("|");
            }
            for (int i = 0; i < gb.BoardEdgeLength; i++)
            {
                for (int j = 0; j < gb.BoardEdgeLength; j++)
                {
                    var gameSquare = gb.GetGameBoardSquare(j, i);
                    System.Console.Write("| ");
                    System.Console.Write(gameSquare.State == null ? " " : gameSquare.State == Player.Black ? "B" : "W");
                    System.Console.Write(" ");
                    
                    if (j == gb.BoardEdgeLength - 1) System.Console.WriteLine("|");
                }
                for (int j = 0; j < gb.BoardEdgeLength; j++)
                {
                    System.Console.Write("|---");
                    if (j == gb.BoardEdgeLength - 1) System.Console.WriteLine("|");
                }
            }
        }
    }
}
