using ScalableMatch.Application.Common.Exceptions;
using ScalableMatch.Application.Common.Interfaces;
using ScalableMatch.Application.Common.Validators;
using ScalableMatch.Domain.Enums;

namespace ScalableMatch.Application.MatchmakingTickets.Stop
{
    public class StopMatchmakingUseCase : IStopMatchmakingUseCase
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly ITicketIdValidator _validator;

        public StopMatchmakingUseCase(ITicketRepository ticketRepository, ITicketIdValidator validator)
        {
            _ticketRepository = ticketRepository;
            _validator = validator;
        }
        public async Task DequeuePlayerAsync(string ticketId)
        {
            var result = _validator.Validate(ticketId, out string message);
            if (result == false)
                throw new ValidationException(message);

            var ticket = await _ticketRepository.GetTicketById(ticketId);
            ticket.Status = MatchmakingTicketStatus.Cancelled;

            await _ticketRepository.UpdateTicket(ticket);
        }
    }
}
