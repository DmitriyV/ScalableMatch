namespace ScalableMatch.Application.Common.Models
{
    public class MatchmakingTicketDto
    {
        public required string Id { get; set; }

        public string? GameSessionId { get; set; }

        public required PlayerDto Player { get; set; }
    }
}
