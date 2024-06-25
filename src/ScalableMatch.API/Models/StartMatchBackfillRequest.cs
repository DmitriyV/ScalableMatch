
using ScalableMatch.Application.Common.Models;

namespace ScalableMatch.API.Models
{
    public class StartMatchBackfillRequest
    {
        public required PlayerDto Player { get; set; }

        public string? TicketId { get; set; }
    }
}
