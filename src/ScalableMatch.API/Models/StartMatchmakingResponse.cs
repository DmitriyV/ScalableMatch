using ScalableMatch.Application.Common.Models;

namespace ScalableMatch.API.Models
{
    public class StartMatchmakingResponse
    {
        public required MatchmakingTicketDto MatchmakingTicket { get; set; }
    }
}
