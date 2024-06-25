namespace ScalableMatch.Application.Common.Models
{
    public class PlayerDto
    {
        public required string Id { get; set; }

        public int LatencyInMs { get; set; }
    }
}
