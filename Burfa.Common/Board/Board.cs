using System;
using System.Collections.Generic;
using System.Linq;
using Burfa.Common.Engine;
using Burfa.Common.Exceptions;

namespace Burfa.Common.Board
{
    public interface IGameBoard
    {
        int BoardEdgeLength { get; set; }
        int GameBoardSquareCount { get; }
        bool Completed { get; }
        void Reset();
        void SetSquare(int x, int y, Player player);
        int GetPlayerScore(Player player);
        BoardSquare[] GetRow(int y);
        BoardSquare[] GetColumn(int x);
        BoardSquare GetGameBoardSquare(int x, int y);

        void SetSquaresFromTurnPos(int x, int y, Player player, ValidOrientation validOrientation);
    }

    public class Board : IGameBoard
    {
        private BoardSquare[] _board;

        public Board(int boardEdgeLength = 8)
        {
            BoardEdgeLength = boardEdgeLength;
            Reset();
        }

        public int BoardEdgeLength { get; set; }

        public int GameBoardSquareCount
        {
            get { return BoardEdgeLength*BoardEdgeLength; }
        }

        public bool Completed
        {
            get { return _board.All(s => !s.IsEmpty()); }
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
            _board = new BoardSquare[GameBoardSquareCount];
            for (int i = 0; i < GameBoardSquareCount; i++)
            {
                _board[i] = new BoardSquare {X = i%BoardEdgeLength, Y = Math.Abs(i/BoardEdgeLength)};
            }
        }

        public int GetPlayerScore(Player player)
        {
            return _board.Count(s => s.BelongsTo(player));
        }

        public void SetSquare(int x, int y, Player player)
        {
            if (x > BoardEdgeLength - 1)
                throw new BoardIndexOutOfRangeException("x value of " + x + " is larger than board edge length (" +
                                                        BoardEdgeLength + ")");
            if (y > BoardEdgeLength - 1)
                throw new BoardIndexOutOfRangeException("y value of " + x + " is larger than board edge length (" +
                                                        BoardEdgeLength + ")");

            _board[(y*BoardEdgeLength) + x].Set(player);
        }

        public BoardSquare[] GetRow(int y)
        {
            return new ArraySegment<BoardSquare>(_board, y*BoardEdgeLength, BoardEdgeLength).ToArray();
        }

        public BoardSquare[] GetColumn(int x)
        {
            var squareList = new List<BoardSquare>();
            for (int i = 0; i < BoardEdgeLength; i++)
            {
                squareList.Add(GetGameBoardSquare(x, i));
            }
            return squareList.ToArray();
        }

        public BoardSquare GetGameBoardSquare(int x, int y)
        {
            if (x > BoardEdgeLength - 1)
                throw new BoardIndexOutOfRangeException("x value of " + x + " is larger than board edge length (" +
                                                        BoardEdgeLength + ")");
            if (y > BoardEdgeLength - 1)
                throw new BoardIndexOutOfRangeException("y value of " + y + " is larger than board edge length (" +
                                                        BoardEdgeLength + ")");

            return _board[(y*BoardEdgeLength) + x];
        }


        public void SetSquaresFromTurnPos(int x, int y, Player player, ValidOrientation validOrientation)
        {
            if (validOrientation == ValidOrientation.Both || validOrientation == ValidOrientation.Horizontal)
            {
                SetSquaresToPlayerInSequence(
                    new ArraySegment<BoardSquare>(GetRow(y), x + 1, BoardEdgeLength - x - 1).ToArray(), player);
                SetSquaresToPlayerInSequence(new ArraySegment<BoardSquare>(GetRow(y), 0, x).Reverse().ToArray(),
                    player);
            }
            if (validOrientation == ValidOrientation.Both || validOrientation == ValidOrientation.Vertical)
            {
                SetSquaresToPlayerInSequence(
                    new ArraySegment<BoardSquare>(GetColumn(x), y + 1, BoardEdgeLength - y - 1).ToArray(), player);
                SetSquaresToPlayerInSequence(new ArraySegment<BoardSquare>(GetColumn(x), 0, y).Reverse().ToArray(),
                    player);
            }
        }

        private void SetSquaresToPlayerInSequence(IEnumerable<BoardSquare> squares, Player player)
        {
            foreach (var square in squares)
            {
                if (square.DoesNotBelongToAndIsNotEmpty(player))
                    square.Set(player);
                else
                    break;
            }
        }
    }
}