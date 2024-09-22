using ScalableMatch.Domain.MatchmakingTicket;

namespace ScalableMatch.Application.MatchmakingTickets
{
    public interface ITicketRepository
    {
        Task SaveTicket(MatchmakingTicket ticket);

        Task<MatchmakingTicket> GetTicketById(string ticketId);

        Task<List<MatchmakingTicket>> GetSearchingTickets();

        Task UpdateTicket(MatchmakingTicket ticket);
    }
}
