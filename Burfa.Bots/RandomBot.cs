using System;
using Burfa.Common.Engine;
using Burfa.Common.Engine.Types;

namespace Burfa.Bots
{
    public class RandomBot : BotBase
    {
        private readonly Random _rng;

        public RandomBot(IGame game, Player player) : base(game)
        {
            _rng = new Random();
        }

        public override Tuple<int,int> GetTurn()
        {
            for (int i = 0; i < 1000; i++)
            {
                var xPos = _rng.Next(0, _game.Board.BoardEdgeLength - 1);
                var yPos = _rng.Next(0, _game.Board.BoardEdgeLength - 1);

                if (Rules.IsValidTurn(_game.Board, _player, xPos, yPos) != ValidOrientation.None)
                {
                    return Tuple.Create(xPos, yPos);
                }
            }
            return null;
        }
    }
}