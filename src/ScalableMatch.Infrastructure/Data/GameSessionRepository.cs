﻿using ScalableMatch.Application.Common.Interfaces;
using ScalableMatch.Domain.Entities;

namespace ScalableMatch.Infrastructure.Data
{
    public class GameSessionRepository : IGameSessionRepository
    {
        public Task<List<GameSession>> GetAvailableSessions(string gameId)
        {
            throw new NotImplementedException();
        }

        public Task SaveSession(GameSession session)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSession(GameSession session)
        {
            throw new NotImplementedException();
        }
    }
}
