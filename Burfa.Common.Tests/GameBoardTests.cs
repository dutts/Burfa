using Burfa.Common.Board;
using Burfa.Common.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Burtfa.Common.Tests
{
    [TestClass]
    public class GameBoardTests
    {
        [TestMethod]
        public void CreateGameBoard__DefaultEdgeWidth__CorrectNUmberOfSquares()
        {
            var gameBoard = new Board();
            Assert.AreEqual(64, gameBoard.GameBoardSquareCount);
        }

        [TestMethod]
        public void CreateGameBoard__DefinedEdgeWidth__CorrectNUmberOfSquares()
        {
            var gameBoard = new Board(10);
            Assert.AreEqual(100, gameBoard.GameBoardSquareCount);
        }

        [TestMethod]
        public void Constructor__IterateOverGeneratedSquares__CorrectXYPositions()
        {
            int boardEdgeLength = 8;
            var gameBoard = new Board(boardEdgeLength);
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

        [TestMethod]
        public void GetRow__CorrectSquaresReturned()
        {
            int boardEdgeLength = 8;
            var gameBoard = new Board(boardEdgeLength);

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

        [TestMethod]
        public void GetColumn__CorrectSquaresReturned()
        {
            int boardEdgeLength = 8;
            var gameBoard = new Board(boardEdgeLength);

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

        [TestMethod]
        public void Completed__CompleteBoard__ReturnsTrue()
        {
            int boardEdgeLength = 2;
            var gameBoard = new Board(boardEdgeLength);
            for (int columnNum = 0; columnNum < boardEdgeLength; columnNum++)
            {
                for (int rowNum = 0; rowNum < boardEdgeLength; rowNum++)
                {
                    gameBoard.SetSquare(columnNum, rowNum, (rowNum%2 == 0) ? Player.Black : Player.White);
                }
            }

            Assert.IsTrue(gameBoard.Completed);
        }

        [TestMethod]
        public void Completed__PartialBoard__ReturnsFalse()
        {
            int boardEdgeLength = 2;
            var gameBoard = new Board(boardEdgeLength);
            for (int rowNum = 0; rowNum < boardEdgeLength; rowNum++)
            {
                gameBoard.SetSquare(1, rowNum, (rowNum%2 == 0) ? Player.Black : Player.White);
            }
            Assert.IsFalse(gameBoard.Completed);
        }

        [TestMethod]
        public void GetPlayerScore__Black1White0_Black1White0()
        {
            var gameBoard = new Board(8);
            gameBoard.SetSquare(0, 0, Player.Black);
            Assert.AreEqual(1, gameBoard.GetPlayerScore(Player.Black));
            Assert.AreEqual(0, gameBoard.GetPlayerScore(Player.White));
        }
    }
}