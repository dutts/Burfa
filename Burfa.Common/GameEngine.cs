using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burfa.Common
{
    public class GameEngine : IGameEngine
    {
        public GameBoard Board {get;set;}

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
            Board = new GameBoard();
        }
    }
}
