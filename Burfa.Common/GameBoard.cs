using Burfa.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burfa.Common
{
    public interface IGameBoard
    {
        int BoardEdgeLength { get; set; }
        int GameBoardSquareCount { get; }
        void Reset();
        void SetSquare(int x, int y, Player player);
        GameBoardSquare[] GetRow(int y);
        GameBoardSquare[] GetColumn(int x);
        GameBoardSquare GetGameBoardSquare(int x, int y);
    }

    public class GameBoard : IGameBoard
    {
        private GameBoardSquare[] board;
          
        public int BoardEdgeLength { get; set; }

        public int GameBoardSquareCount
        {
            get
            {
                return BoardEdgeLength * BoardEdgeLength;
            }
        }

        public GameBoard(int boardEdgeLength = 8)
        {
            BoardEdgeLength = boardEdgeLength;
            Reset();
        }

        /*
         Board location example
          0  1  2  3
          4  5  6  7              x -->
          8  9 10 11              y |
         12 13 14 15               \/
         
         */

        public void Reset()
        {
            board = new GameBoardSquare[GameBoardSquareCount];
            for (int i = 0; i < GameBoardSquareCount; i++)
            {
                board[i] = new GameBoardSquare() { X = i % BoardEdgeLength, Y = Math.Abs(i/BoardEdgeLength) };
            }
        }

        public void SetSquare(int x, int y, Player player)
        {
            if (x > BoardEdgeLength - 1) throw new BoardIndexOutOfRangeException("x value of " + x + " is larger than board edge length (" + BoardEdgeLength + ")");
            if (y > BoardEdgeLength - 1) throw new BoardIndexOutOfRangeException("y value of " + x + " is larger than board edge length (" + BoardEdgeLength + ")");

            board[(y * BoardEdgeLength) + x].Set(player);
        }

        public GameBoardSquare[] GetRow(int y)
        {
           return new ArraySegment<GameBoardSquare>(board, y * BoardEdgeLength, BoardEdgeLength).ToArray();
        }

        public GameBoardSquare[] GetColumn(int x)
        {
            var squareList = new List<GameBoardSquare>();
            for (int i = 0; i < BoardEdgeLength; i++)
            {
                squareList.Add(GetGameBoardSquare(x, i));
            }
            return squareList.ToArray();
        }

        public GameBoardSquare GetGameBoardSquare(int x, int y)
        {
            if (x > BoardEdgeLength - 1) throw new BoardIndexOutOfRangeException("x value of " + x + " is larger than board edge length (" + BoardEdgeLength + ")");
            if (y > BoardEdgeLength - 1) throw new BoardIndexOutOfRangeException("y value of " + y + " is larger than board edge length (" + BoardEdgeLength + ")");

            return board[(y * BoardEdgeLength) + x];
        }
    }
}
