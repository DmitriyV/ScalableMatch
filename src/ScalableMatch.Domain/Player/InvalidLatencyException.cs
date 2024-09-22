namespace ScalableMatch.Domain.Player
{
    public class InvalidLatencyException : Exception
    {
        public InvalidLatencyException(int latency) : base($"Latency \"{latency}\" must be positive.")
        {
        }
    }
}
