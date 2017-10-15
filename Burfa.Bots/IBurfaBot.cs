using System;
using Burfa.Common.Engine;

namespace Burfa.Bots
{
    public interface IBurfaBot
    {
        Tuple<int, int> GetTurn(IGame game);
    }
}