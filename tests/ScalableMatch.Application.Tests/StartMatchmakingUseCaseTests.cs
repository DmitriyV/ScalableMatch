using Moq;
using ScalableMatch.Application.Common;
using ScalableMatch.Application.Common.Interfaces;
using ScalableMatch.Application.Common.Models;
using ScalableMatch.Application.MatchmakingTickets.Start;
using ScalableMatch.Domain.Entities;
using ScalableMatch.Domain.Enums;

namespace ScalableMatch.Application.Tests
{
    public class StartMatchmakingUseCaseTests
    {
        [Fact]
        public async Task QueuePlayerAsync_ValidParameters_TicketShouldBeSaved()
        {
            var playerDto = new PlayerDto() { Id = "player id", LatencyInMs = 42 };
            const string gameId = "game id";
            Mock<ITicketRepository> repositoryMock = new Mock<ITicketRepository>();
            var ticketRepository = repositoryMock.Object;
            
            var useCase = new StartMatchmakingUseCase(ticketRepository);

            await useCase.QueuePlayerAsync(playerDto, gameId);

            repositoryMock.Verify(x => x.SaveTicket(It.IsAny<MatchmakingTicket>()));
        }

        [Fact]
        public async Task QueuePlayerAsync_ValidParameters_TicketReturned()
        {
            var playerDto = new PlayerDto() { Id = "player id", LatencyInMs = 42 };
            const string gameId = "game id";
            var ticketRepository = new Mock<ITicketRepository>().Object;

            var useCase = new StartMatchmakingUseCase(ticketRepository);

            var ticket = await useCase.QueuePlayerAsync(playerDto, gameId);

            Assert.NotNull(ticket.Id);
            Assert.Equal(gameId, ticket.GameId);
            Assert.Equivalent(playerDto, ticket.Player);
            Assert.Equal("Queued", ticket.Status);
        }
    }
}
