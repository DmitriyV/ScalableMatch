using ScalableMatch.Application.Common.Interfaces;
using ScalableMatch.Domain.MatchmakingTicket;

namespace ScalableMatch.Infrastructure.TicketRepository
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
            throw new NotImplementedException();
        }

        public Task UpdateTicket(MatchmakingTicket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
