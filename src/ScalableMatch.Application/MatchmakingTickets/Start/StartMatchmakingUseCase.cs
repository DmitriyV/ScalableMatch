using ScalableMatch.Application.Common;
using ScalableMatch.Application.Common.Exceptions;
using ScalableMatch.Application.Common.Validators;
using ScalableMatch.Application.GameSession;
using ScalableMatch.Domain.MatchmakingTicket;

namespace ScalableMatch.Application.MatchmakingTickets.Start
{
    public class StartMatchmakingUseCase(ITicketRepository ticketRepository, IPlayerDtoValidator validator) : IStartMatchmakingUseCase
    {
        private readonly ITicketRepository _ticketRepository = ticketRepository;
        private readonly IPlayerDtoValidator _validator = validator;

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
                Status = MatchmakingTicketStatus.Searching
            };

            await _ticketRepository.SaveTicket(ticket);

            return ticket.ToDto();
        }
    }
}
