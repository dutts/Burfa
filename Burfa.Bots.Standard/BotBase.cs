using System;
using Burfa.Common.Board;
using Burfa.Common.Engine;

namespace Burfa.Bots
{
    public abstract class BotBase : IBurfaBot
    {
        protected readonly IGameRules _rules;
        private readonly IGameEngine _engine;
        protected readonly IGameBoard _gameBoard;
        protected readonly Player _player;

        protected BotBase(IGameRules rules, IGameEngine engine, IGameBoard gameBoard) //, Player player)
        {
            _rules = rules;
            _engine = engine;
            _gameBoard = gameBoard;
            _player = Player.White;
        }

        public abstract Tuple<int,int> GetTurn();
    }
}
