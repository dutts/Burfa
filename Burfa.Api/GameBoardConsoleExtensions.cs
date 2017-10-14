using System;
using System.Text;
using Burfa.Common.Board;
using Burfa.Common.Engine;
using Burfa.Common.Engine.Types;

namespace Burfa.Api
{
    public static class GameBoardConsoleExtensions
    {
        public static string ToDisplayString(this IGameBoard gb)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < gb.BoardEdgeLength; i++)
            {
                if (i == 0) sb.Append("  ");
                if (i == gb.BoardEdgeLength - 1) sb.AppendLine("  " + i + " ");
                else
                {
                    sb.Append("  " + i + " ");
                }
            }
            for (int i = 0; i < gb.BoardEdgeLength; i++)
            {
                if (i == 0) sb.Append("  |---");
                else
                {
                    sb.Append("|---");
                }
                if (i == gb.BoardEdgeLength - 1) sb.AppendLine("|");
            }
            for (int i = 0; i < gb.BoardEdgeLength; i++)
            {
                sb.Append(i + " ");
                for (int j = 0; j < gb.BoardEdgeLength; j++)
                {
                    sb.Append("| ");
                    BoardSquare gameSquare = gb.GetGameBoardSquare(j, i);
                    sb.Append(gameSquare.State == null ? " " : gameSquare.State == Player.Black ? "B" : "W");
                    sb.Append(" ");

                    if (j == gb.BoardEdgeLength - 1) sb.AppendLine("|");
                }
                for (int j = 0; j < gb.BoardEdgeLength; j++)
                {
                    if (j == 0)
                    {
                        sb.Append("  |---");
                    }
                    else
                    {
                        sb.Append("|---");
                    }
                    if (j == gb.BoardEdgeLength - 1) sb.AppendLine("|");
                }
            }

            return sb.ToString();
        }

        public static void ToConsole(this IGameBoard gb)
        {
            Console.Clear();
            Console.Write(gb.ToDisplayString());
        }
    }
}