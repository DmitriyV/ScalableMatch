namespace ScalableMatch.API.Models
{
    public class StartMatchBackfillRequest
    {
        public required Player Player { get; set; }

        public string? TicketId { get; set; }
    }
}
