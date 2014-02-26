using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Burfa.Common;
using FakeItEasy;

namespace Burtfa.Common.Tests
{
    [TestClass]
    public class GameRulesTests
    {
        private GameBoardSquare[] _testSequence;
        private GameRules _gameRules;

        [TestInitialize]
        public void Setup()
        {
            _testSequence = new GameBoardSquare[8];
            for (int i = 0; i < 8; i++)
            {
                _testSequence[i] = new GameBoardSquare();
            }
            _gameRules = new GameRules(A.Fake<GameBoard>());
        }

        [TestMethod]
        public void IsValidInSequence__BWX00000_BlackMoveX__ReturnsTrue()
        {
            _testSequence[0].SetBlack();
            _testSequence[1].SetWhite();

            var isValid = GameRules.IsValidInSequence(Player.Black, _testSequence, 2);
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void IsValidInSequence__BWX00000_WhiteMoveX__ReturnsFalse()
        {
            _testSequence[0].SetBlack();
            _testSequence[1].SetWhite();

            var isValid = GameRules.IsValidInSequence(Player.White, _testSequence, 2);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsValidInSequence__BW0X0000_BlackMoveX__ReturnsFalse()
        {
            _testSequence[0].SetBlack();
            _testSequence[1].SetWhite();

            var isValid = GameRules.IsValidInSequence(Player.Black, _testSequence, 3);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsValidInSequence__BW0X0000_WhiteMoveX__ReturnsFalse()
        {
            _testSequence[0].SetBlack();
            _testSequence[1].SetWhite();

            var isValid = GameRules.IsValidInSequence(Player.White, _testSequence, 3);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsValidInSequence__000XWB00_BlackMoveX__ReturnsTrue()
        {
            _testSequence[4].SetWhite();
            _testSequence[5].SetBlack();
           
            var isValid = GameRules.IsValidInSequence(Player.Black, _testSequence, 3);
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void IsValidInSequence__000XWB00_WhiteMoveX__ReturnsFalse()
        {
            _testSequence[4].SetWhite();
            _testSequence[5].SetBlack();

            var isValid = GameRules.IsValidInSequence(Player.White, _testSequence, 3);
            Assert.IsFalse(isValid);
        }
    }
}
