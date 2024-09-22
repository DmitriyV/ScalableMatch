using Moq;
using ScalableMatch.Application.Common.Interfaces;
using ScalableMatch.Application.MatchmakingTickets.AssignSession;
using ScalableMatch.Application.MatchmakingTickets.Matchmaking;
using ScalableMatch.Domain.GameSession;
using ScalableMatch.Domain.MatchmakingTicket;
using ScalableMatch.Domain.Player;

namespace ScalableMatch.Application.Tests.UseCases
{
    public class AssignSessionUseCaseTests
    {
        [Fact]
        public async void MatchmakingQueue_NoSearchingTickets_NoGameSessionCreated()
        {
            var ticketRepositoryMock = new Mock<ITicketRepository>();
            ticketRepositoryMock.Setup(x => x.GetSearchingTickets()).ReturnsAsync([]);
            var ticketRepository = ticketRepositoryMock.Object;

            var sessionRepositoryMock = new Mock<IGameSessionRepository>();
            var sessionRepository = sessionRepositoryMock.Object;

            var matchCreatorMock = new Mock<IMatchCreator>();
            var matchCreator = matchCreatorMock.Object;

            var useCase = new AssignSessionUseCase(sessionRepository, ticketRepository, matchCreator);

            await useCase.ProcessMatchmakingQueue(new CancellationToken());

            matchCreatorMock.Verify(x => x.CreateForCurrentTicket(It.IsAny<List<MatchmakingTicket>>(), It.IsAny<MatchmakingTicket>()), Times.Never);
            sessionRepositoryMock.Verify(x => x.SaveSession(It.IsAny<GameSession>()), Times.Never);
        }

        [Fact]
        public async void MatchmakingQueue_MatchingTicketsInQueue_GameSessionCreated()
        {
            var ticketRepositoryMock = new Mock<ITicketRepository>();

            var searchingTickets = new List<MatchmakingTicket>();
            for (int i = 0; i < 10; i++)
            {
                searchingTickets.Add(new MatchmakingTicket()
                {
                    Id = "ticket id " + i,
                    GameId = "one game",
                    Player = new Player() { Id = "player id " + i, LatencyInMs = 42 }
                });
            }

            ticketRepositoryMock.Setup(x => x.GetSearchingTickets()).ReturnsAsync(searchingTickets);
            var ticketRepository = ticketRepositoryMock.Object;

            var sessionRepositoryMock = new Mock<IGameSessionRepository>();
            var sessionRepository = sessionRepositoryMock.Object;

            var currentTicket = searchingTickets[0];
            var tickets = searchingTickets.ToList();
            tickets.Remove(currentTicket);

            var matchCreatorMock = new Mock<IMatchCreator>();
            matchCreatorMock.Setup(x => x.CreateForCurrentTicket(tickets, currentTicket)).Returns(tickets);
            var matchCreator = matchCreatorMock.Object;

            var useCase = new AssignSessionUseCase(sessionRepository, ticketRepository, matchCreator);

            await useCase.ProcessMatchmakingQueue(new CancellationToken());

            matchCreatorMock.Verify(x => x.CreateForCurrentTicket(It.IsAny<List<MatchmakingTicket>>(), It.IsAny<MatchmakingTicket>()), Times.Once);
            sessionRepositoryMock.Verify(x => x.SaveSession(It.IsAny<GameSession>()), Times.Once);
        }
    }
}
