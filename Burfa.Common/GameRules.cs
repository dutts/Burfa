using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burfa.Common
{
    public interface IGameRules
    {
        bool IsValidTurn(Player player, int x, int y);
    }

    enum SearchDirection
    {
        Up,
        Down,
        Left,
        Right
    }

    public class GameRules : IGameRules
    {
        private IGameBoard _board;

        public GameRules(IGameBoard board)
        {
            _board = board;
        }

        public bool IsValidTurn(Player player, int x, int y)
        {
            bool upValid = true;
            bool downValid = true;
            bool leftValid = true;
            bool rightValid = true;

            return upValid || downValid || leftValid || rightValid;
        }

        private bool IsValidInDirection(Player player, int x, int y, SearchDirection direction)
        {
            bool isValid = true;
            //var squares = GetSquaresInDirectionFromStartSquare(x, y, direction);
            //foreach (var square in squares)
            //{
            //    if 
            //}
            return isValid;
        }

        public bool IsAdjacentToPlayerSquare(Player player, int x, int y)
        {
            bool retVal = false;

            if ((x >= 0 && x < _board.BoardEdgeLength) && (y >= 0 && y < _board.BoardEdgeLength))
            {
                if ((_board.GetGameBoardSquare(x - 1, y).State == player) ||
                    (_board.GetGameBoardSquare(x + 1, y).State == player) ||
                    (_board.GetGameBoardSquare(x, y + 1).State == player) ||
                    (_board.GetGameBoardSquare(x, y + 1).State == player))
                {
                    retVal = true;
                }
            }
            return retVal;
        }
    }
}
