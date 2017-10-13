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
        const string SessionKeyName = "_Name";
        const string SessionKeyYearsMember = "_YearsMember";
        const string SessionKeyDate = "_Date";

        private readonly IGameEngine _gameEngine;
        readonly IBurfaBot _burfaBot;

        public GameController(IGameEngine gameEngine, IBurfaBot burfaBot)
        {
            _burfaBot = burfaBot;
            _gameEngine = gameEngine;
        }

        public IActionResult Index()
        {
            // Requires using Microsoft.AspNetCore.Http;
            //HttpContext.Session.SetString(SessionKeyName, "Rick");
            //HttpContext.Session.SetInt32(SessionKeyYearsMember, 3);
            return RedirectToAction("Board");
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
