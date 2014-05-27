namespace Burfa.Common
{
    public interface IGameEngine
    {
        IGameBoard Board { get; }
        Player CurrentPlayer { get; }
        GameState CurrentGameState { get; }
        TurnResult LastTurnResult { get; }
        void Setup();
        void TakeTurn(int x, int y);
        void TakeTurn(Player player, int x, int y);
        void Reset();
    }

    public class GameEngine : IGameEngine
    {
        private readonly IGameBoard _gameBoard;
        private readonly IGameRules _gameRules;
        private TurnResult _lastTurnResult;

        public GameEngine(IGameBoard gameBoard, IGameRules gameRules)
        {
            _gameBoard = gameBoard;
            _gameRules = gameRules;
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
            var result = new TurnResult {IsValid = false, State = GameState.InPlay};

            ValidOrientation validOrientation = _gameRules.IsValidTurn(player, x, y);
            if (validOrientation != ValidOrientation.None)
            {
                result = new TurnResult {IsValid = true, State = CurrentGameState};
                _gameBoard.SetSquaresFromTurnPos(x, y, player, validOrientation);
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