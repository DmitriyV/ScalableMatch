using ScalableMatch.Domain.Common;
using ScalableMatch.Domain.Entities;
using ScalableMatch.Domain.Enums;

namespace ScalableMatch.API.Models
{
    public class MatchmakingTicket: BaseEntity
    {
        public string? GameSessionId { get; set; }

        public required Player Player { get; set; } 

        public MatchmakingTicketStatus Status { get; set; }
    }
}
