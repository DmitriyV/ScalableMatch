namespace ScalableMatch.Domain.MatchmakingTicket
{
    public class MatchmakingTicket : BaseEntity
    {
        public required string GameId { get; set; }

        public required Player.Player Player { get; set; }

        public MatchmakingTicketStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
