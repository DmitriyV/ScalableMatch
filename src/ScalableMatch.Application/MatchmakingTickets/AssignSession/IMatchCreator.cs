using ScalableMatch.Domain.MatchmakingTicket;

namespace ScalableMatch.Application.MatchmakingTickets.AssignSession
{
    public interface IMatchCreator
    {
        List<MatchmakingTicket> CreateForCurrentTicket(List<MatchmakingTicket> tickets, MatchmakingTicket currentTicket);
    }
}