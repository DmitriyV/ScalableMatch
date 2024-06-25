namespace ScalableMatch.API.Models
{
    public class Player
    {
        public required string PlayerId { get; set; }
        
        public required int LatencyInMs { get; set; }
    }
}
