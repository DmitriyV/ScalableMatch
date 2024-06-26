using ScalableMatch.Domain.Entities;

namespace ScalableMatch.Application.Common.Interfaces
{
    public interface ITicketRepository
    {
        Task SaveTicket(MatchmakingTicket ticket);

        Task<MatchmakingTicket> GetTicketById(string ticketId);

        Task<List<MatchmakingTicket>> GetSearchingTickets();

        Task UpdateTicket(MatchmakingTicket ticket);
    }
}
