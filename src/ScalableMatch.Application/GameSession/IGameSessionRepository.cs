namespace ScalableMatch.Application.GameSession
{
    public interface IGameSessionRepository
    {
        Task SaveSession(Domain.GameSession.GameSession session);

        Task UpdateSession(Domain.GameSession.GameSession session);

        Task<List<Domain.GameSession.GameSession>> GetAvailableSessions(string gameId);
    }
}
