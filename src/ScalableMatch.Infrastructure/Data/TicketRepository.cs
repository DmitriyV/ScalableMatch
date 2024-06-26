using ScalableMatch.Application.Common.Interfaces;
using ScalableMatch.Domain.Entities;

namespace ScalableMatch.Infrastructure.Data
{
    public class TicketRepository : ITicketRepository
    {
        public Task<List<MatchmakingTicket>> GetSearchingTickets()
        {
            throw new NotImplementedException();
        }

        public Task<MatchmakingTicket> GetTicketById(string ticketId)
        {
            throw new NotImplementedException();
        }

        public Task SaveTicket(MatchmakingTicket ticket)
        {
            return Task.CompletedTask;
        }

        public Task UpdateTicket(MatchmakingTicket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
