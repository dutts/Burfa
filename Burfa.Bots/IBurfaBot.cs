using Burfa.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burfa.Bots
{
    interface IBurfaBot
    {
        IList<GameBoardSquare> SubmitTurnGetResponse(IList<GameBoardSquare> otherPlayerTurn);
    }
}
