using ScalableMatch.Application.Common.Models;

namespace ScalableMatch.API.StartMatchmaking
{
    public record StartMatchBackfillRequest(PlayerDto Player, string? TicketId);
}
