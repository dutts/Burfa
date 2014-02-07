using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burfa.Common
{
    public class GameEngine : IGameEngine
    {
        public GameBoard Board {get;set;}

        public Player CurrentPlayer { get; set; }
        public GameState CurrentGameState { get; set; }

        public GameEngine()
        {
            Reset();
            Setup();
        }

        public void Setup()
        {
            Board.SetSquare(3, 3, Player.Black);
            Board.SetSquare(4, 4, Player.Black);
            Board.SetSquare(3, 4, Player.White);
            Board.SetSquare(4, 3, Player.White);
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
            Board.SetSquare(x, y, player);
            //TODO
            CurrentGameState = result.State;
            if (result.IsValid && CurrentGameState == GameState.InPlay) ToggleCurrentPlayer();
            return result;
        }

        public void Reset()
        {
            Board = new GameBoard();
        }

        private void ToggleCurrentPlayer()
        {
            CurrentPlayer = (CurrentPlayer == Player.Black) ? Player.White : Player.Black;
        }
    }
}
