using ScalableMatch.Application.Common.Models;

namespace ScalableMatch.API.StartMatchmaking
{
    public record StartMatchmakingRequest(PlayerDto Player, string GameId);
}
