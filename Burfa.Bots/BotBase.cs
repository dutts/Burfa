using System;
using Burfa.Common.Board;
using Burfa.Common.Engine;
using Burfa.Common.Engine.Types;

namespace Burfa.Bots
{
    public abstract class BotBase : IBurfaBot
    {
        readonly IGame _game;
        protected readonly IGameBoard _gameBoard;
        protected readonly Player _player;

        protected BotBase(IGame game, IGameBoard gameBoard) //, Player player)
        {
            _game = game;
            _gameBoard = gameBoard;
            _player = Player.White;
        }

        public abstract Tuple<int, int> GetTurn();
    }
}
