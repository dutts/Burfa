using System.Collections.Generic;
using Burfa.Common;

namespace Burfa.Bots
{
    internal interface IBurfaBot
    {
        IList<GameBoardSquare> SubmitTurnGetResponse(IList<GameBoardSquare> otherPlayerTurn);
    }
}