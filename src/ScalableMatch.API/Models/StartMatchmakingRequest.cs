using ScalableMatch.Application.Common.Models;

namespace ScalableMatch.API.Models
{
    public class StartMatchmakingRequest
    {
        public required PlayerDto Player { get; set; }
    }
}
