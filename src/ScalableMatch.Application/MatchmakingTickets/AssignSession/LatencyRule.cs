using ScalableMatch.Domain.Entities;

namespace ScalableMatch.Application.MatchmakingTickets.AssignSession
{
    public class LatencyRule : ILatencyRule
    {
        private readonly int _latencyTolerance;

        public LatencyRule(int latencyTolerance = 30)
        {
            _latencyTolerance = latencyTolerance;
        }

        public IEnumerable<MatchmakingTicket> Apply(List<MatchmakingTicket> tickets, int targetLatency)
        {
            foreach (var ticket in tickets)
            {
                if (Math.Abs(ticket.Player.LatencyInMs - targetLatency) <= _latencyTolerance)
                {
                    yield return ticket;
                }
            }
        }
    }
}
