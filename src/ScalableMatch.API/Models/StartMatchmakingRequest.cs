namespace ScalableMatch.API.Models
{
    public class StartMatchmakingRequest
    {
        public required Player Player { get; set; }

        public string? TicketId { get; set; }
    }
}
