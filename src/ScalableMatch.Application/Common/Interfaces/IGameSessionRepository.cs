﻿using ScalableMatch.Domain.GameSession;

namespace ScalableMatch.Application.Common.Interfaces
{
    public interface IGameSessionRepository
    {
        Task SaveSession(GameSession session);

        Task UpdateSession(GameSession session);

        Task<List<GameSession>> GetAvailableSessions(string gameId);
    }
}
