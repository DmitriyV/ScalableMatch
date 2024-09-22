using ScalableMatch.Domain.MatchmakingTicket;

namespace ScalableMatch.Application.MatchmakingTickets.AssignSession
{
    public interface ILatencyRule
    {
        IEnumerable<MatchmakingTicket> Apply(List<MatchmakingTicket> tickets, int targetLatency);
    }
}