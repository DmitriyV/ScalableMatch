using ScalableMatch.Application.GameSession;

namespace ScalableMatch.API.StartMatchmaking
{
    public record StartMatchBackfillRequest(PlayerDto Player, string? TicketId);
}
