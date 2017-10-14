using System;
using Burfa.Common.Board;
using Burfa.Common.Engine;
using Burfa.Common.Engine.Types;

namespace Burfa.Bots
{
    public abstract class BotBase : IBurfaBot
    {
        protected readonly IGameRules _rules;
        readonly IGame _game;
        protected readonly IGameBoard _gameBoard;
        protected readonly Player _player;

        protected BotBase(IGameRules rules, IGame game, IGameBoard gameBoard) //, Player player)
        {
            _rules = rules;
            _game = game;
            _gameBoard = gameBoard;
            _player = Player.White;
        }

        public abstract Tuple<int, int> GetTurn();
    }
}
