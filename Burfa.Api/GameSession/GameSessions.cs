using System;
using System.Collections.Generic;

namespace Burfa.Api.GameSession
{
    public interface IGameSessions
    {
        GameSession GetOrAdd(string sessionId, Func<GameSession> factory);
    }

    public class GameSessions : IGameSessions
    {
        readonly Dictionary<string, GameSession> _sessions = new Dictionary<string, GameSession>();

        public GameSession GetOrAdd(string sessionId, Func<GameSession> factory)
        {
            if (_sessions.ContainsKey(sessionId)) return _sessions[sessionId];
            else
            {
                var newSession = factory.Invoke();
                _sessions[sessionId] = newSession;
                return newSession;
            }
        }
    }
}
