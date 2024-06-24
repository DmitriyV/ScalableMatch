namespace ScalableMatch.Domain
{
    public interface IMatchmakingService
    {
        public void StartMatchmaking();

        public void StopMatchmaking();

        public void StartMatchBackfill();
    }
}
