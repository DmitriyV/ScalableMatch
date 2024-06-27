namespace ScalableMatch.Application.MatchmakingTickets.AssignSession
{
    public interface IAssignSessionUseCase
    {
        Task ProcessMatchmakingQueue(CancellationToken cancellationToken);
    }
}
