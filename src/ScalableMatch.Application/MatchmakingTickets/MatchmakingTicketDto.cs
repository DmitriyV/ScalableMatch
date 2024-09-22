using ScalableMatch.Application.GameSession;

namespace ScalableMatch.Application.MatchmakingTickets
{
    public class MatchmakingTicketDto
    {
        public required string Id { get; set; }

        public required PlayerDto Player { get; set; }

        public required string GameId { get; set; }

        public required string Status { get; set; }

        public DateTime CreatedAt { get; internal set; }
    }
}
