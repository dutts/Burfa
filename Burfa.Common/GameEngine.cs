using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burfa.Common
{
    public class GameEngine : IGameEngine
    {
        private GameBoard _board;

        public Player CurrentPlayer { get; set; }

        public GameEngine()
        {
            Reset();
        }

        public TurnResult TakeTurn(Player player, int x, int y)
        {
            return default(TurnResult);
        }

        public void Reset()
        {
            _board = new GameBoard();
        }
    }

}
