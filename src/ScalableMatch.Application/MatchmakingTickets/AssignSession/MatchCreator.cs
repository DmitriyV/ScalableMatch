using ScalableMatch.Domain.GameSession;
using ScalableMatch.Domain.MatchmakingTicket;

namespace ScalableMatch.Application.MatchmakingTickets.AssignSession
{
    public class MatchCreator : IMatchCreator
    {
        private readonly ILatencyRule _latencyRule;

        public MatchCreator(ILatencyRule latencyRule) => _latencyRule = latencyRule;

        public List<MatchmakingTicket> CreateForCurrentTicket(List<MatchmakingTicket> tickets, MatchmakingTicket currentTicket)
        {
            var matchTargetLatency = currentTicket.Player.LatencyInMs;

            var ticketsByGameId = tickets.Where(x => x.GameId == currentTicket.GameId).ToList();
            var matchingTickets = _latencyRule.Apply(ticketsByGameId, matchTargetLatency);

            var potentialMatch = new List<MatchmakingTicket>
            {
                currentTicket
            };

            foreach (var ticket in matchingTickets)
            {
                if (potentialMatch.Count >= PlayersInGameSession.Maximum)
                    break;

                potentialMatch.Add(ticket);
            }

            return potentialMatch;
        }
    }
}
