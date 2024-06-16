namespace ScalableMatch.API.Models
{
    public class MatchmakingTicket
    {
        public required string TicketId { get; set; }

        public string? GameSessionId { get; set; }

        public required Player Player { get; set; } 

        public MatchmakingTicketStatus Status { get; set; }
    }
}
