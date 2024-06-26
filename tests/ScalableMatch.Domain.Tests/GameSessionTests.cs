using ScalableMatch.Domain.Entities;
using ScalableMatch.Domain.Exceptions;

namespace ScalableMatch.Domain.Tests
{
    public class GameSessionTests
    {

        [Fact]
        public void CreateSession_ValidParameters_SessionShouldBeCreated()
        {
            var expected = new GameSession()
            {
                Id = "id",
                AcceptBackfill = true,
                Status = Enums.GameSessionState.Created,
                GameId = "game id"
            };

            Assert.NotNull(expected);
        }

        [Fact]
        public void AddPlayer_SessionIsFull_ShouldThrowException()
        {
            var gameSession = new GameSession()
            {
                Id = "id",
                Status = Enums.GameSessionState.Created,
                GameId = "game id"
            };
            for (var i = 0; i < 10; i++)
            {
                gameSession.AddPlayer(new Player() { Id = i.ToString(), LatencyInMs = i + 1 });
            }

            Assert.Throws<TooManyPlayersException>(() => gameSession.AddPlayer(new Player() { Id = "10", LatencyInMs = 10 }));
        }
    }
}
