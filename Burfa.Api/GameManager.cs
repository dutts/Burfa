using System;
using System.Collections.Generic;
using Burfa.Common.Engine;

namespace Burfa.Api
{
    public interface IGameManager
    {
        Game GetOrAdd(string id);
        Game Create(string id);
        void Remove(string id);
        bool Contains(string id);
    }

    public class GameManager : IGameManager
    {
        private readonly Dictionary<string, Game> _games = new Dictionary<string, Game>();

        public Game GetOrAdd(string id)
        {
            if (!_games.ContainsKey(id))
            {
                var newGame = new Game();
                _games[id] = newGame;
            }
            return _games[id];
        }

        public Game Create(string id)
        {
            var game = new Game();
            _games[id] = game;
            return game;
        }

        public void Remove(string id)
        {
            if (_games.ContainsKey(id)) _games.Remove(id);
        }

        public bool Contains(string id)
        {
            return _games.ContainsKey(id);
        }
    }
}
