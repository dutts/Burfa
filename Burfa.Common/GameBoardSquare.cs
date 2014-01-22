using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burfa.Common
{
    public class GameBoardSquare
    {
        #region Logic Testing
        public int X { get; set; }
        public int Y { get; set; }
        #endregion

        public Player State
        {
            get;
            private set;
        }

        public void SetBlack()
        {
            State = Player.Black;
        }

        public void SetWhite()
        {
            State = Player.White;
        }

        public void Set(Player player)
        {
            State = player;
        }

        public void Clear()
        {
            State = default(Player);
        }
    }
}
