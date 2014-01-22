using Burfa.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burfa.Common
{
    public class GameBoard
    {
        private GameBoardSquare[] board;
        private int _boardEdgeLength;

        public int GameBoardSquareCount
        {
            get
            {
                return _boardEdgeLength * _boardEdgeLength;
            }
        }

        public GameBoard(int boardEdgeLength = 8)
        {
            _boardEdgeLength = boardEdgeLength;
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
                board[i] = new GameBoardSquare() { X = i % _boardEdgeLength, Y = Math.Abs(i/_boardEdgeLength) };
            }
        }

        public void SetSquare(int x, int y, Player player)
        {
            if (x > _boardEdgeLength - 1) throw new BoardIndexOutOfRangeException("x value of " + x + " is larger than board edge length (" + _boardEdgeLength + ")");
            if (y > _boardEdgeLength - 1) throw new BoardIndexOutOfRangeException("y value of " + x + " is larger than board edge length (" + _boardEdgeLength + ")");

            board[(x * _boardEdgeLength) + y].Set(player);
        }

        public GameBoardSquare GetGameBoardSquare(int x, int y)
        {
            if (x > _boardEdgeLength - 1) throw new BoardIndexOutOfRangeException("x value of " + x + " is larger than board edge length (" + _boardEdgeLength + ")");
            if (y > _boardEdgeLength - 1) throw new BoardIndexOutOfRangeException("y value of " + x + " is larger than board edge length (" + _boardEdgeLength + ")");

            return board[(x * _boardEdgeLength) + y];
        }
    }
}
