using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Burfa.Common;

namespace Burtfa.Common.Tests
{
    [TestClass]
    public class GameBoardTeets
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
            int boardEdgeLendth = 8;
            var gameBoard = new GameBoard(boardEdgeLendth);
            for (int i = 0; i < boardEdgeLendth; i++)
            {
                for (int j = 0; j < boardEdgeLendth; j++)
                {
                    var gameBoardSquare = gameBoard.GetGameBoardSquare(i, j);

                    Assert.AreEqual(j, gameBoardSquare.X);
                    Assert.AreEqual(i, gameBoardSquare.Y);
                }
            }

        }
    }
}
