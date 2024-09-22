namespace ScalableMatch.Application.GameSession
{
    public class PlayerDto
    {
        public required string Id { get; set; }

        public int LatencyInMs { get; set; }
    }
}
