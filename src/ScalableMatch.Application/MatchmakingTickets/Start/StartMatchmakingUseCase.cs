using ScalableMatch.Application.Common;
using ScalableMatch.Application.Common.Exceptions;
using ScalableMatch.Application.Common.Interfaces;
using ScalableMatch.Application.Common.Models;
using ScalableMatch.Application.Common.Validators;
using ScalableMatch.Domain.Entities;
using ScalableMatch.Domain.Enums;

namespace ScalableMatch.Application.MatchmakingTickets.Start
{
    public class StartMatchmakingUseCase : IStartMatchmakingUseCase
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IPlayerDtoValidator _validator;

        public StartMatchmakingUseCase(ITicketRepository ticketRepository, IPlayerDtoValidator validator)
        {
            _ticketRepository = ticketRepository;
            _validator = validator;
        }

        public async Task<MatchmakingTicketDto> QueuePlayerAsync(PlayerDto player, string gameId)
        {
            var result = _validator.Validate(player, out string message);
            if (result == false)
                throw new ValidationException(message);

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
