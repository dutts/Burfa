using System;
using System.Linq;
using Burfa.Common.Board;
using Burfa.Common.Engine.Types;

namespace Burfa.Common.Engine
{
    public interface IGameRules
    {
        ValidOrientation IsValidTurn(Player player, int x, int y);
    }

    public enum ValidOrientation
    {
        None,
        Vertical,
        Horizontal,
        Both
    }

    public class Rules : IGameRules
    {
        private readonly IGameBoard _board;

        public Rules(IGameBoard board)
        {
            _board = board;
        }

        public ValidOrientation IsValidTurn(Player player, int x, int y)
        {
            bool upDownValid = IsValidInSequence(player, _board.GetColumn(x), y);
            bool leftRightValid = IsValidInSequence(player, _board.GetRow(y), x);

            if (upDownValid && leftRightValid) return ValidOrientation.Both;
            if (upDownValid) return ValidOrientation.Vertical;
            if (leftRightValid) return ValidOrientation.Horizontal;
            return ValidOrientation.None;
        }

        public static bool IsValidInSequence(Player player, BoardSquare[] squareSeq, int turnPos)
        {
            //bool isValid = true;

            // Handle white space on both sides, invalid
            if ((turnPos > 0 && squareSeq[turnPos - 1].IsEmpty()) &&
                (turnPos < squareSeq.Length && squareSeq[turnPos + 1].IsEmpty()))
                return false;

            // Handle after turnPos in sequence
            bool isValidAfter = SeekOverOtherPlayerToThisPlayer(player,
                new ArraySegment<BoardSquare>(squareSeq, turnPos + 1, squareSeq.Length - turnPos - 1).ToArray());
            bool isValidBefore = SeekOverOtherPlayerToThisPlayer(player,
                new ArraySegment<BoardSquare>(squareSeq, 0, turnPos).Reverse().ToArray());

            return isValidBefore || isValidAfter;
        }

        private static bool SeekOverOtherPlayerToThisPlayer(Player thisPlayer, BoardSquare[] squareSeq)
        {
            bool isValid = false;
            bool foundSquaresToTake = false;

            for (int i = 0; i < squareSeq.Length; i++)
            {
                if (squareSeq[i].DoesNotBelongToAndIsNotEmpty(thisPlayer))
                {
                    foundSquaresToTake = true;
                }
                if (foundSquaresToTake && squareSeq[i].BelongsTo(thisPlayer))
                {
                    isValid = true;
                }
                if (!foundSquaresToTake) break;
            }
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

        public GameState GetGameState()
        {
            var retVal = GameState.InPlay;
            if (_board.Completed)
            {
                int blackScore = _board.GetPlayerScore(Player.Black);
                int whiteScore = _board.GetPlayerScore(Player.White);
                if (blackScore == whiteScore) retVal = GameState.Draw;
                else if (blackScore > whiteScore) retVal = GameState.WinBlack;
                else if (whiteScore < blackScore) retVal = GameState.WinWhite;
            }
            return retVal;
        }
    }
}