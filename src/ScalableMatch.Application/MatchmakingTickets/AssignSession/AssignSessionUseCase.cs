using ScalableMatch.Application.GameSession;
using ScalableMatch.Domain.GameSession;
using ScalableMatch.Domain.MatchmakingTicket;

namespace ScalableMatch.Application.MatchmakingTickets.AssignSession
{
    public class AssignSessionUseCase : IAssignSessionUseCase
    {
        private readonly IGameSessionRepository _sessionRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IMatchCreator _matchCreator;

        public AssignSessionUseCase(IGameSessionRepository sessionRepository,
            ITicketRepository ticketRepository,
            IMatchCreator matchCreator)
        {
            _sessionRepository = sessionRepository;
            _ticketRepository = ticketRepository;
            _matchCreator = matchCreator;
        }

        public async Task ProcessMatchmakingQueue(CancellationToken cancellationToken)
        {
            var tickets = await GetTicketsOrderedByQueueingTime();

            while (tickets.Count > 0 && !cancellationToken.IsCancellationRequested)
            {
                var currentTicket = tickets.First();
                tickets.Remove(currentTicket);

                var potentialMatch = _matchCreator.CreateForCurrentTicket(tickets, currentTicket);

                if (potentialMatch.Count >= PlayersInGameSession.Minumum)
                {
                    foreach (var ticket in potentialMatch)
                        tickets.Remove(ticket);

                    await SaveNewGameSession(potentialMatch, currentTicket.GameId);
                }
            }
        }

        private async Task<List<MatchmakingTicket>> GetTicketsOrderedByQueueingTime()
        {
            return (await _ticketRepository.GetSearchingTickets())
                                           .OrderBy(t => t.CreatedAt)
                                           .ToList();
        }

        private async Task SaveNewGameSession(List<MatchmakingTicket> potentialMatch, string gameId)
        {
            var newSession = new Domain.GameSession.GameSession
            {
                Id = Guid.NewGuid().ToString(),
                GameId = gameId,
                Players = potentialMatch.Select(x => x.Player).ToList(),
                Status = GameSessionState.Created
            };

            foreach (var ticket in potentialMatch)
            {
                ticket.Status = MatchmakingTicketStatus.Placing;
                await _ticketRepository.UpdateTicket(ticket);
            }

            await _sessionRepository.SaveSession(newSession);
        }
    }
}