using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burfa.Common
{
    public interface IGameRules
    {
        bool IsValidTurn(Player player, int x, int y);
    }

    public class GameRules : IGameRules
    {
        private IGameBoard _board;

        public GameRules(IGameBoard board)
        {
            _board = board;
        }

        public bool IsValidTurn(Player player, int xm, int y)
        {
            return true;
        }
    }
}
