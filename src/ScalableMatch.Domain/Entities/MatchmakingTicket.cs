using ScalableMatch.Domain.Common;
using ScalableMatch.Domain.Enums;

namespace ScalableMatch.Domain.Entities
{
    public class MatchmakingTicket : BaseEntity
    {
        public string? GameSessionId { get; set; }

        public required Player Player { get; set; }

        public MatchmakingTicketStatus Status { get; set; }
    }
}
