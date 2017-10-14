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

        private readonly IGame _game;
        readonly IBurfaBot _burfaBot;

        public GameController(IGame game, IBurfaBot burfaBot)
        {
            _burfaBot = burfaBot;
            _game = game;
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
            var board = _game.Board;
            //var json = JsonConvert.SerializeObject(board);

            //var name = HttpContext.Session.GetString(SessionKeyName);
            //var yearsMember = HttpContext.Session.GetInt32(SessionKeyYearsMember);
            return Content(board.ToDisplayString());
        }

        public IActionResult TakeTurn(int x, int y)
        {
            _game.TakeTurn(x, y);
            var computerTurn = _burfaBot.GetTurn();
            _game.TakeTurn(computerTurn.Item1, computerTurn.Item2);

            return RedirectToAction("Board");
        }
    }
}
