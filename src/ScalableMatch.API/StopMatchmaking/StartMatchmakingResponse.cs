using ScalableMatch.Application.MatchmakingTickets;

namespace ScalableMatch.API.StopMatchmaking
{
    public record StartMatchmakingResponse(MatchmakingTicketDto MatchmakingTicket);
}
