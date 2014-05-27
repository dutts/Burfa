using System.Collections.Generic;
using Burfa.Common;
using Burfa.Common.Board;

namespace Burfa.Bots
{
    internal interface IBurfaBot
    {
        IList<BoardSquare> SubmitTurnGetResponse(IList<BoardSquare> otherPlayerTurn);
    }
}