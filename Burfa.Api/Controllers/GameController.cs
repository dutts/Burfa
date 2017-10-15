using System;
using Burfa.Bots;
using Burfa.Common.Engine;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Burfa.Api.Controllers
{
    public class GameController : Controller
    {
        const string SessionGameName = "_GameName";

        private readonly IGameManager _gameManager;
        private readonly IBurfaBot _bot;

        public GameController(IGameManager gameManager, IBurfaBot bot)
        {
            _bot = bot;
            _gameManager = gameManager;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Board");
        }

        public IActionResult NewGame(string gameId)
        {
            string response;
            if (_gameManager.Contains(gameId))
            {
                HttpContext.Session.Set(SessionGameName, gameId);
                response = $"Game {gameId} is already created, rejoining";
            }
            else
            {
                _gameManager.Create(gameId);
                HttpContext.Session.Set(SessionGameName, gameId);
                response = $"Game {gameId} created";
            }
            return Content(response);
        }

        public IActionResult Board()
        {
            var gameId = HttpContext.Session.Get<string>(SessionGameName);
            if (gameId != null && _gameManager.Contains(gameId))
            {
                var game = _gameManager.GetOrAdd(gameId);
                return Content(game.Board.ToDisplayString());
            }

            return NotFound();
        }

        public IActionResult TakeTurn(int x, int y)
        {

            var gameId = HttpContext.Session.Get<string>(SessionGameName);
            var game = _gameManager.GetOrAdd(gameId);

            game.TakeTurn(x, y);

            var computerTurn = _bot.GetTurn(game);
            game.TakeTurn(computerTurn.Item1, computerTurn.Item2);

            return RedirectToAction("Board");
        }
    }
}
