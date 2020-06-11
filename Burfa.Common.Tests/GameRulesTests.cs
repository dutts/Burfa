using Burfa.Common.Board;
using Burfa.Common.Engine;
using FakeItEasy;
using NUnit.Framework;

namespace Burfa.Common.Tests
{
    [TestFixture]
    public class GameRulesTests
    {
        private Rules _gameRules;
        private BoardSquare[] _testSequence;

        [SetUp]
        public void Setup()
        {
            _testSequence = new BoardSquare[8];
            for (int i = 0; i < 8; i++)
            {
                _testSequence[i] = new BoardSquare();
            }
            _gameRules = new Rules(A.Fake<Board.Board>());
        }

        [Test]
        public void IsValidInSequence__BWX00000_BlackMoveX__ReturnsTrue()
        {
            _testSequence[0].SetBlack();
            _testSequence[1].SetWhite();

            bool isValid = Rules.IsValidInSequence(Player.Black, _testSequence, 2);
            Assert.IsTrue(isValid);
        }

        [Test]
        public void IsValidInSequence__BWX00000_WhiteMoveX__ReturnsFalse()
        {
            _testSequence[0].SetBlack();
            _testSequence[1].SetWhite();

            bool isValid = Rules.IsValidInSequence(Player.White, _testSequence, 2);
            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsValidInSequence__BW0X0000_BlackMoveX__ReturnsFalse()
        {
            _testSequence[0].SetBlack();
            _testSequence[1].SetWhite();

            bool isValid = Rules.IsValidInSequence(Player.Black, _testSequence, 3);
            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsValidInSequence__BW0X0000_WhiteMoveX__ReturnsFalse()
        {
            _testSequence[0].SetBlack();
            _testSequence[1].SetWhite();

            bool isValid = Rules.IsValidInSequence(Player.White, _testSequence, 3);
            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsValidInSequence__00000XWB_BlackMoveX__ReturnsTrue()
        {
            _testSequence[7].SetBlack();
            _testSequence[6].SetWhite();

            bool isValid = Rules.IsValidInSequence(Player.Black, _testSequence, 5);
            Assert.IsTrue(isValid);
        }

        [Test]
        public void IsValidInSequence__00000XWB_WhiteMoveX__ReturnsFalse()
        {
            _testSequence[7].SetBlack();
            _testSequence[6].SetWhite();

            bool isValid = Rules.IsValidInSequence(Player.White, _testSequence, 5);
            Assert.IsFalse(isValid);
        }


        [Test]
        public void IsValidInSequence__000XWB00_BlackMoveX__ReturnsTrue()
        {
            _testSequence[4].SetWhite();
            _testSequence[5].SetBlack();

            bool isValid = Rules.IsValidInSequence(Player.Black, _testSequence, 3);
            Assert.IsTrue(isValid);
        }

        [Test]
        public void IsValidInSequence__000XWB00_WhiteMoveX__ReturnsFalse()
        {
            _testSequence[4].SetWhite();
            _testSequence[5].SetBlack();

            bool isValid = Rules.IsValidInSequence(Player.White, _testSequence, 3);
            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsValidInSequence__000XWBW0_WhiteMoveX__ReturnsFalse()
        {
            _testSequence[4].SetWhite();
            _testSequence[5].SetBlack();
            _testSequence[6].SetWhite();

            bool isValid = Rules.IsValidInSequence(Player.White, _testSequence, 3);
            Assert.IsFalse(isValid);
        }
    }
}