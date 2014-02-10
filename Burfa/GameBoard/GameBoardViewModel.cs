using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Burfa.Common;

namespace Burfa.GameBoard
{
    public class GameBoardViewModel : ViewModelBase// DependencyObject //todo: prism
    {
        private IGameEngine _gameEngine;

        public GameBoardViewModel(IGameEngine gameEngine)
        {
            _gameEngine = gameEngine;
        }

    }
}
