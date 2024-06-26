namespace ScalableMatch.Application.MatchmakingTickets.Stop
{
    public interface IStopMatchmakingUseCase
    {
        Task DequeuePlayerAsync(string ticketId);
    }
}
