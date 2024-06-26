using ScalableMatch.Application.Common;
using ScalableMatch.Application.Common.Interfaces;
using ScalableMatch.Application.Common.Models;
using ScalableMatch.Domain.Entities;
using ScalableMatch.Domain.Enums;

namespace ScalableMatch.Application.MatchmakingTickets.Start
{
    public class StartMatchmakingUseCase : IStartMatchmakingUseCase
    {
        private readonly ITicketRepository _ticketRepository;

        public StartMatchmakingUseCase(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<MatchmakingTicketDto> QueuePlayerAsync(PlayerDto player, string gameId)
        {
            var ticket = new MatchmakingTicket()
            {
                Id = Guid.NewGuid().ToString(),
                Player = player.ToEntity(),
                GameId = gameId,
                CreatedAt = DateTime.UtcNow,
                Status = MatchmakingTicketStatus.Queued
            };

            await _ticketRepository.SaveTicket(ticket);

            return ticket.ToDto();
        }
    }
}
