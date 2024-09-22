using ScalableMatch.Application.Common;
using ScalableMatch.Domain.Player;
using ScalableMatch.Domain.MatchmakingTicket;
using ScalableMatch.Application.GameSession;

namespace ScalableMatch.Application.Tests
{
    public class EntityMapperTests
    {
        [Fact]
        public void PlayerDtoToEntity_ValidParameters_ShouldMap()
        {
            var dto = new PlayerDto()
            {
                Id = "player id",
                LatencyInMs = 14
            };

            var entity = dto.ToEntity();

            Assert.Equal(dto.Id, entity.Id);
            Assert.Equal(dto.LatencyInMs, entity.LatencyInMs);
        }

        [Fact]
        public void PlayerEntityToDto_ValidParameters_ShouldMap()
        {
            var entity = new Player()
            {
                Id = "player id",
                LatencyInMs = 14
            };

            var dto = entity.ToDto();

            Assert.Equal(entity.Id, dto.Id);
            Assert.Equal(entity.LatencyInMs, dto.LatencyInMs);
        }

        [Fact]
        public void MatchmakingTicketToDto_ValidParameters_ShouldMap()
        {
            var player = new Player()
            {
                Id = "player id",
                LatencyInMs = 14
            };

            var entity = new MatchmakingTicket()
            {
                Id = "ticket id",
                GameId = "game id",
                Player = player,
                Status = MatchmakingTicketStatus.Searching,
                CreatedAt = DateTime.UtcNow,
            };

            var dto = entity.ToDto();

            Assert.Equal(entity.Id, dto.Id);
            Assert.Equal(entity.GameId, dto.GameId);
            Assert.Equal(entity.Status.ToString(), dto.Status);
            Assert.Equal(entity.CreatedAt, dto.CreatedAt);
        }
    }
}