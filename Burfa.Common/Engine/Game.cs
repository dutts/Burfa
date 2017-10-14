using Burfa.Common.Board;
using Burfa.Common.Engine.Types;

namespace Burfa.Common.Engine
{
    public interface IGame
    {
        IGameBoard Board { get; }
        Player CurrentPlayer { get; }
        GameState CurrentGameState { get; }
        TurnResult LastTurnResult { get; }
        void Setup();
        void TakeTurn(int x, int y);
        void TakeTurn(Player player, int x, int y);
        void Reset();
        void SkipTurn();
    }

    public class Game : IGame
    {
        readonly IGameBoard _gameBoard;
        TurnResult _lastTurnResult;

        public Game(IGameBoard gameBoard)
        {
            _lastTurnResult = new TurnResult { IsValid = true, State = GameState.Initial };
            _gameBoard = gameBoard;
            Reset();
            Setup();
        }

        public IGameBoard Board
        {
            get { return _gameBoard; }
        }

        public TurnResult LastTurnResult
        {
            get { return _lastTurnResult; }
        }

        public Player CurrentPlayer { get; set; }
        public GameState CurrentGameState { get; set; }

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
            var result = new TurnResult { IsValid = false, State = GameState.InPlay };

            ValidOrientation validOrientation = Rules.IsValidTurn(_gameBoard, player, x, y);
            if (validOrientation != ValidOrientation.None)
            {
                if (CurrentGameState == GameState.Initial) CurrentGameState = GameState.InPlay;
                result = new TurnResult { IsValid = true, State = CurrentGameState };
                _gameBoard.SetSquaresFromTurnPos(x, y, player, validOrientation);
                _gameBoard.SetSquare(x, y, player);
                CurrentGameState = result.State;
                if (result.IsValid && CurrentGameState == GameState.InPlay) ToggleCurrentPlayer();
            }
            _lastTurnResult = result;
        }

        public void SkipTurn()
        {
            ToggleCurrentPlayer();
        }

        public void Reset()
        {
            _gameBoard.Reset();
        }

        void ToggleCurrentPlayer()
        {

            CurrentPlayer = (CurrentPlayer == Player.Black) ? Player.White : Player.Black;
        }
    }
}