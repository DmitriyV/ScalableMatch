namespace ScalableMatch.API.Models
{
    public enum MatchmakingTicketStatus
    {
        Queued = 0,
        Searching = 1,
        Placing = 2,
        Cancelled = 3,
        Failed = 4
    }
}
