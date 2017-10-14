using System;
using Burfa.Common.Engine;
using Burfa.Common.Engine.Types;

namespace Burfa.Bots
{
    public abstract class BotBase : IBurfaBot
    {
        protected readonly IGame _game;
        protected readonly Player _player;

        protected BotBase(IGame game) //, Player player)
        {
            _game = game;
            _player = Player.White;
        }

        public abstract Tuple<int, int> GetTurn();
    }
}
