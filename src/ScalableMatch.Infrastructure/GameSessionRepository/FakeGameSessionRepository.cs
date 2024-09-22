using ScalableMatch.Application.GameSession;
using ScalableMatch.Domain.GameSession;

namespace ScalableMatch.Infrastructure.GameSessionRepository
{
    public class FakeGameSessionRepository : IGameSessionRepository
    {
        public Task<List<GameSession>> GetAvailableSessions(string gameId)
        {
            return Task.FromResult(new List<GameSession>()
            {
                new()
                {
                    Id = "1",
                    GameId = gameId,
                    Status = GameSessionState.Created,
                    CreatedAt = DateTime.Now,
                    Players =
                    [
                        new() { Id = "51", LatencyInMs = 51 },
                        new() { Id = "32", LatencyInMs = 32 },
                    ]
                },
                new()
                {
                    Id = "2",
                    GameId = gameId,
                    Status = GameSessionState.Created,
                    CreatedAt = DateTime.Now,
                    Players =
                    [
                        new() { Id = "22", LatencyInMs = 51 }
                    ]
                }
            });
        }

        public Task SaveSession(GameSession session)
        {
            return Task.CompletedTask;
        }

        public Task UpdateSession(GameSession session)
        {
            return Task.CompletedTask;
        }
    }
}
