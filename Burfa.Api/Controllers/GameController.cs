using System;
using Burfa.Bots;
using Burfa.Common.Board;
using Burfa.Common.Engine;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Burfa.Api.Controllers
{
    public class GameController : Controller
    {
        const string SessionGameName = "_GameName";

        private readonly IGameEngine _gameEngine;
        readonly IBurfaBot _burfaBot;

        public GameController(IGameEngine gameEngine, IBurfaBot burfaBot)
        {
            _burfaBot = burfaBot;
            _gameEngine = gameEngine;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Board");
        }

        public IActionResult NewGame(string gameId)
        {
            HttpContext.Session.SetString(SessionGameName, gameId);
            return Content($"New game {gameId} created");
        }

        public IActionResult Board()
        {
            var board = _gameEngine.Board;
            //var json = JsonConvert.SerializeObject(board);

            //var name = HttpContext.Session.GetString(SessionKeyName);
            //var yearsMember = HttpContext.Session.GetInt32(SessionKeyYearsMember);
            return Content(board.ToDisplayString());
        }

        public IActionResult TakeTurn(int x, int y)
        {
            _gameEngine.TakeTurn(x, y);
            var computerTurn = _burfaBot.GetTurn();
            _gameEngine.TakeTurn(computerTurn.Item1, computerTurn.Item2);

            return RedirectToAction("Board");
        }
    }
}
