using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burfa.Common
{
    public interface IGameEngine
    {
        IGameBoard Board { get; }
        Player CurrentPlayer { get; }
        GameState CurrentGameState { get; }
        void Setup();
        void TakeTurn(int x, int y);
        void TakeTurn(Player player, int x, int y);
        TurnResult LastTurnResult { get; }
        void Reset();
    }

    public class GameEngine : IGameEngine
    {
        public IGameBoard Board
        {
            get
            {
                return _gameBoard;
            }
        }

        private TurnResult _lastTurnResult;
        public TurnResult LastTurnResult
        {
            get { return _lastTurnResult; }
        }
        public Player CurrentPlayer { get; set; }
        public GameState CurrentGameState { get; set; }

        private IGameBoard _gameBoard;
        private IGameRules _gameRules;

        public GameEngine(IGameBoard gameBoard, IGameRules gameRules)
        {
            _gameBoard = gameBoard;
            _gameRules = gameRules;
            Reset();
            Setup();
        }

        public void Setup()
        {
            _gameBoard.SetSquare(3, 3, Player.Black);
            _gameBoard.SetSquare(4, 4, Player.Black);
            _gameBoard.SetSquare(3, 4, Player.White);
            _gameBoard.SetSquare(4, 3, Player.White);
            CurrentPlayer = Player.Black;
        }

        public void TakeTurn(int x, int y)
        {
            TakeTurn(CurrentPlayer, x, y);
        }

        public void TakeTurn(Player player, int x, int y)
        {
            TurnResult result = new TurnResult() { IsValid = false, State = GameState.InPlay };

            if (_gameRules.IsValidTurn(player, x, y))
            {
                result = new TurnResult() { IsValid = true, State = GameState.InPlay };
                _gameBoard.SetSquare(x, y, player);
                CurrentGameState = result.State;
                if (result.IsValid && CurrentGameState == GameState.InPlay) ToggleCurrentPlayer();
            }
            _lastTurnResult = result;
        }

        public void Reset()
        {
            _gameBoard.Reset();
        }

        private void ToggleCurrentPlayer()
        {
            CurrentPlayer = (CurrentPlayer == Player.Black) ? Player.White : Player.Black;
        }
    }
}
