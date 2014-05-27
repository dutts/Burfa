using Burfa.Common;

namespace Burfa.GameBoard
{
    public class GameBoardViewModel : ViewModelBase // DependencyObject //todo: prism
    {
        private IGameEngine _gameEngine;

        public GameBoardViewModel(IGameEngine gameEngine)
        {
            _gameEngine = gameEngine;
        }
    }
}