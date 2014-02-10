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
        TurnResult TakeTurn(int x, int y);
        TurnResult TakeTurn(Player player, int x, int y);
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

        public Player CurrentPlayer { get; set; }
        public GameState CurrentGameState { get; set; }

        private IGameBoard _gameBoard;

        public GameEngine(IGameBoard gameBoard)
        {
            _gameBoard = gameBoard;
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

        public TurnResult TakeTurn(int x, int y)
        {
            return TakeTurn(CurrentPlayer, x, y);
        }

        public TurnResult TakeTurn(Player player, int x, int y)
        {
            var result = new TurnResult() { IsValid = true, State = GameState.InPlay };
            //TODO
            _gameBoard.SetSquare(x, y, player);
            //TODO
            CurrentGameState = result.State;
            if (result.IsValid && CurrentGameState == GameState.InPlay) ToggleCurrentPlayer();
            return result;
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
