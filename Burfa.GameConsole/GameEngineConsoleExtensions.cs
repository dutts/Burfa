using Burfa.Common.Engine;

namespace Burfa.GameConsole
{
    public static class GameEngineConsoleExtensions
    {
        public static void ToConsole(this IGameEngine ge)
        {
            ge.Board.ToConsole();
            if (ge.LastTurnResult.State != GameState.Initial) System.Console.WriteLine("Last turn was " + (ge.LastTurnResult.IsValid ? "" : "not ") + "valid");
            System.Console.WriteLine("Current Player Turn : " + ge.CurrentPlayer);
        }
    }
}