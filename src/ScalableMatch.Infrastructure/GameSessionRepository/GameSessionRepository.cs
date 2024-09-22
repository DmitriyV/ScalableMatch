using ScalableMatch.Application.GameSession;
using ScalableMatch.Domain.GameSession;

namespace ScalableMatch.Infrastructure.GameSessionRepository
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
