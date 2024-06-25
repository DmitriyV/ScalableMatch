namespace ScalableMatch.Application.Common.Models
{
    public class MatchmakingTicketDto
    {
        public string Id { get; set; }

        public string? GameSessionId { get; set; }

        public required PlayerDto Player { get; set; }
    }
}
