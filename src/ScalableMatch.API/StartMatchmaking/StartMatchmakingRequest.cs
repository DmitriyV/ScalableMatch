using ScalableMatch.Application.GameSession;

namespace ScalableMatch.API.StartMatchmaking
{
    public record StartMatchmakingRequest(PlayerDto Player, string GameId);
}
