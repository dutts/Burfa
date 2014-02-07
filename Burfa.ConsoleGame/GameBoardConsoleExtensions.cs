using Burfa.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burfa.ConsoleGame
{
    public static class GameBoardConsoleExtensions
    {
        public static void ToConsole(this GameBoard gb)
        {
            Console.Clear();
            for (int i = 0; i < gb.BoardEdgeLength; i++)
            {
                if (i == 0) Console.Write("  ");
                if (i == gb.BoardEdgeLength - 1) Console.WriteLine("  " + i + " ");
                else
                {
                    Console.Write("  " + i + " ");
                }
            }
            for (int i = 0; i < gb.BoardEdgeLength; i++)
            {
                if (i == 0) Console.Write("  |---");
                else
                {
                    Console.Write("|---");
                }
                if (i == gb.BoardEdgeLength - 1) Console.WriteLine("|");
            }
            for (int i = 0; i < gb.BoardEdgeLength; i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < gb.BoardEdgeLength; j++)
                {
                    Console.Write("| ");
                    var gameSquare = gb.GetGameBoardSquare(j, i);
                    Console.Write(gameSquare.State == null ? " " : gameSquare.State == Player.Black ? "B" : "W");
                    Console.Write(" ");
                    
                    if (j == gb.BoardEdgeLength - 1) Console.WriteLine("|");
                }
                for (int j = 0; j < gb.BoardEdgeLength; j++)
                {
                    if (j == 0)
                    {
                        Console.Write("  |---");
                    }
                    else
                    {
                        Console.Write("|---");
                    }
                    if (j == gb.BoardEdgeLength - 1) Console.WriteLine("|");
                }
            }
        }
    }
}
