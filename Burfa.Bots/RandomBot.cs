using System;
using Burfa.Common.Engine;
using Burfa.Common.Engine.Types;

namespace Burfa.Bots
{
    public class RandomBot : IBurfaBot
    {
        private readonly Random _rng;
        private readonly Player _player = Player.White;

        public RandomBot()
        {
            _rng = new Random();
        }

        public Tuple<int,int> GetTurn(IGame game)
        {
            for (int i = 0; i < 1000; i++)
            {
                var xPos = _rng.Next(0, game.Board.BoardEdgeLength - 1);
                var yPos = _rng.Next(0, game.Board.BoardEdgeLength - 1);

                if (Rules.IsValidTurn(game.Board, _player, xPos, yPos) != ValidOrientation.None)
                {
                    return Tuple.Create(xPos, yPos);
                }
            }
            return null;
        }
    }
}