using ScalableMatch.Application.Common.Models;

namespace ScalableMatch.Application.MatchmakingTickets.Start
{
    public interface IStartMatchmakingUseCase
    {
        MatchmakingTicketDto QueuePlayer(PlayerDto player);
    }
}
