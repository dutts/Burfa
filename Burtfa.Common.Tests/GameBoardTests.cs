using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Burfa.Common;

namespace Burtfa.Common.Tests
{
    [TestClass]
    public class GameBoardTests
    {
        [TestMethod]
        public void CreateGameBoard__DefaultEdgeWidth__CorrectNUmberOfSquares()
        {
            var gameBoard = new GameBoard();
            Assert.AreEqual(64, gameBoard.GameBoardSquareCount);
        }

        [TestMethod]
        public void CreateGameBoard__DefinedEdgeWidth__CorrectNUmberOfSquares()
        {
            var gameBoard = new GameBoard(10);
            Assert.AreEqual(100, gameBoard.GameBoardSquareCount);
        }

        [TestMethod]
        public void Constructor__IterateOverGeneratedSquares__CorrectXYPositions()
        {
            int boardEdgeLength = 8;
            var gameBoard = new GameBoard(boardEdgeLength);
            for (int i = 0; i < boardEdgeLength; i++)
            {
                for (int j = 0; j < boardEdgeLength; j++)
                {
                    var gameBoardSquare = gameBoard.GetGameBoardSquare(i, j);

                    Assert.AreEqual(j, gameBoardSquare.Y);
                    Assert.AreEqual(i, gameBoardSquare.X);
                }
            }
        }

        [TestMethod]
        public void GetRow__CorrectSquaresReturned()
        {
            var boardEdgeLength = 8;
            var gameBoard = new GameBoard(boardEdgeLength);

            for (int rowNum = 0; rowNum < boardEdgeLength; rowNum++)
            {
                var topRow = gameBoard.GetRow(rowNum);
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
            var boardEdgeLength = 8;
            var gameBoard = new GameBoard(boardEdgeLength);

            for (int columnNum = 0; columnNum < boardEdgeLength; columnNum++)
            {
                var topRow = gameBoard.GetColumn(columnNum);
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
            var boardEdgeLength = 2;
            var gameBoard = new GameBoard(boardEdgeLength);
            for (int columnNum = 0; columnNum < boardEdgeLength; columnNum++)
            {
                for (int rowNum = 0; rowNum < boardEdgeLength; rowNum++)
                {
                    gameBoard.SetSquare(columnNum, rowNum, (rowNum % 2 == 0) ? Player.Black : Player.White);
                }
            }

            Assert.IsTrue(gameBoard.Completed);
        }

        [TestMethod]
        public void Completed__PartialBoard__ReturnsFalse()
        {
            var boardEdgeLength = 2;
            var gameBoard = new GameBoard(boardEdgeLength);
            for (int rowNum = 0; rowNum < boardEdgeLength; rowNum++)
            {
                gameBoard.SetSquare(1, rowNum, (rowNum % 2 == 0) ? Player.Black : Player.White);
            }
            Assert.IsFalse(gameBoard.Completed);
        }

        [TestMethod]
        public void GetPLayerScore__Black1White0_Black1White0()
        {
            var gameBoard = new GameBoard(8);
            gameBoard.SetSquare(0, 0, Player.Black);
            Assert.Equals(1, gameBoard.GetPlayerScore(Player.Black));
            Assert.Equals(0, gameBoard.GetPlayerScore(Player.White));
        }
    }
}
