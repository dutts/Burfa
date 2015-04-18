using System;

namespace Burfa.Bots
{
    public interface IBurfaBot
    {
        Tuple<int, int> GetTurn();
    }
}