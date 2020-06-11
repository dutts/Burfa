using Burfa.Common.Board;
using Burfa.Common.Engine;
using NUnit.Framework;

namespace Burfa.Common.Tests
{
    [TestFixture]
    public class GameBoardTests
    {
        [Test]
        public void CreateGameBoard__DefaultEdgeWidth__CorrectNUmberOfSquares()
        {
            var gameBoard = new Board.Board();
            Assert.AreEqual(64, gameBoard.GameBoardSquareCount);
        }

        [Test]
        public void CreateGameBoard__DefinedEdgeWidth__CorrectNUmberOfSquares()
        {
            var gameBoard = new Board.Board(10);
            Assert.AreEqual(100, gameBoard.GameBoardSquareCount);
        }

        [Test]
        public void Constructor__IterateOverGeneratedSquares__CorrectXYPositions()
        {
            int boardEdgeLength = 8;
            var gameBoard = new Board.Board(boardEdgeLength);
            for (int i = 0; i < boardEdgeLength; i++)
            {
                for (int j = 0; j < boardEdgeLength; j++)
                {
                    BoardSquare gameBoardSquare = gameBoard.GetGameBoardSquare(i, j);

                    Assert.AreEqual(j, gameBoardSquare.Y);
                    Assert.AreEqual(i, gameBoardSquare.X);
                }
            }
        }

        [Test]
        public void GetRow__CorrectSquaresReturned()
        {
            int boardEdgeLength = 8;
            var gameBoard = new Board.Board(boardEdgeLength);

            for (int rowNum = 0; rowNum < boardEdgeLength; rowNum++)
            {
                BoardSquare[] topRow = gameBoard.GetRow(rowNum);
                Assert.AreEqual(boardEdgeLength, topRow.Length);

                for (int i = 0; i < boardEdgeLength; i++)
                {
                    Assert.AreEqual(i, topRow[i].X);
                    Assert.AreEqual(rowNum, topRow[i].Y);
                }
            }
        }

        [Test]
        public void GetColumn__CorrectSquaresReturned()
        {
            int boardEdgeLength = 8;
            var gameBoard = new Board.Board(boardEdgeLength);

            for (int columnNum = 0; columnNum < boardEdgeLength; columnNum++)
            {
                BoardSquare[] topRow = gameBoard.GetColumn(columnNum);
                Assert.AreEqual(boardEdgeLength, topRow.Length);

                for (int i = 0; i < boardEdgeLength; i++)
                {
                    Assert.AreEqual(i, topRow[i].Y);
                    Assert.AreEqual(columnNum, topRow[i].X);
                }
            }
        }

        [Test]
        public void Completed__CompleteBoard__ReturnsTrue()
        {
            int boardEdgeLength = 2;
            var gameBoard = new Board.Board(boardEdgeLength);
            for (int columnNum = 0; columnNum < boardEdgeLength; columnNum++)
            {
                for (int rowNum = 0; rowNum < boardEdgeLength; rowNum++)
                {
                    gameBoard.SetSquare(columnNum, rowNum, (rowNum%2 == 0) ? Player.Black : Player.White);
                }
            }

            Assert.IsTrue(gameBoard.Completed);
        }

        [Test]
        public void Completed__PartialBoard__ReturnsFalse()
        {
            int boardEdgeLength = 2;
            var gameBoard = new Board.Board(boardEdgeLength);
            for (int rowNum = 0; rowNum < boardEdgeLength; rowNum++)
            {
                gameBoard.SetSquare(1, rowNum, (rowNum%2 == 0) ? Player.Black : Player.White);
            }
            Assert.IsFalse(gameBoard.Completed);
        }

        [Test]
        public void GetPlayerScore__Black1White0_Black1White0()
        {
            var gameBoard = new Board.Board(8);
            gameBoard.SetSquare(0, 0, Player.Black);
            Assert.AreEqual(1, gameBoard.GetPlayerScore(Player.Black));
            Assert.AreEqual(0, gameBoard.GetPlayerScore(Player.White));
        }
    }
}