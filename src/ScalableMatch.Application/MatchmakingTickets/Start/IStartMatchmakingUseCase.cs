using ScalableMatch.Application.Common.Models;

namespace ScalableMatch.Application.MatchmakingTickets.Start
{
    public interface IStartMatchmakingUseCase
    {
        Task<MatchmakingTicketDto> QueuePlayerAsync(PlayerDto player, string gameId);
    }
}
