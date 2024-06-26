using ScalableMatch.Application.Common.Models;
using ScalableMatch.Domain.Entities;

namespace ScalableMatch.Application.Common
{
    public static class EntityMapper
    {
        public static Player ToEntity(this PlayerDto dto) => new()
        {
            Id = dto.Id,
            LatencyInMs = dto.LatencyInMs
        };

        public static PlayerDto ToDto(this Player entity) => new()
        {
            Id = entity.Id,
            LatencyInMs = entity.LatencyInMs
        };

        public static MatchmakingTicketDto ToDto(this MatchmakingTicket entity) => new()
        {
            Id = entity.Id,
            Player = entity.Player.ToDto(),
            GameId = entity.GameId,
            Status = entity.Status.ToString(),
            CreatedAt = entity.CreatedAt
        };
    }
}
