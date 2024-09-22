namespace ScalableMatch.Domain.GameSession
{
    public enum GameSessionState
    {
        Created = 0,
        Playing = 1,
        Completed = 2,
        Cancelled = 3,
        Failed = 4
    }
}
