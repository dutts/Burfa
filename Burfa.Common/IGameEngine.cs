using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burfa.Common
{
    interface IGameEngine
    {
        TurnResult TakeTurn(Player player, int x, int y);
        void Reset();
    }
}
