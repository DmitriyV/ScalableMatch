using ScalableMatch.Application.Common.Interfaces;
using ScalableMatch.Domain.GameSession;
using ScalableMatch.Domain.Player;

namespace ScalableMatch.Infrastructure.GameSessionRepository
{
    public class FakeGameSessionRepository : IGameSessionRepository
    {
        public Task<List<GameSession>> GetAvailableSessions(string gameId)
        {
            return Task.FromResult(new List<GameSession>()
            {
                new GameSession()
                {
                    Id = "1",
                    GameId = gameId,
                    Status = GameSessionState.Created,
                    CreatedAt = DateTime.Now,
                    Players = new List<Player>()
                    {
                        new Player() { Id = "51", LatencyInMs = 51 },
                        new Player() { Id = "32", LatencyInMs = 32 },
                    }
                },
                new GameSession()
                {
                    Id = "2",
                    GameId = gameId,
                    Status = GameSessionState.Created,
                    CreatedAt = DateTime.Now,
                    Players = new List<Player>()
                    {
                        new Player() { Id = "22", LatencyInMs = 51 }
                    }
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
