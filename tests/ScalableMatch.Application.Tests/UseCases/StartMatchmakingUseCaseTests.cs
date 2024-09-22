using Moq;
using ScalableMatch.Application.Common.Exceptions;
using ScalableMatch.Application.Common.Interfaces;
using ScalableMatch.Application.Common.Models;
using ScalableMatch.Application.Common.Validators;
using ScalableMatch.Application.MatchmakingTickets.Start;
using ScalableMatch.Domain.MatchmakingTicket;

namespace ScalableMatch.Application.Tests.UseCases
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
            var validatorMock = new Mock<IPlayerDtoValidator>();
            string message;
            validatorMock.Setup(x => x.Validate(playerDto, out message)).Returns(true);

            var useCase = new StartMatchmakingUseCase(ticketRepository, validatorMock.Object);

            await useCase.QueuePlayerAsync(playerDto, gameId);

            repositoryMock.Verify(x => x.SaveTicket(It.IsAny<MatchmakingTicket>()));
        }

        [Fact]
        public async Task QueuePlayerAsync_ValidParameters_TicketReturned()
        {
            var playerDto = new PlayerDto() { Id = "player id", LatencyInMs = 42 };
            const string gameId = "game id";
            var ticketRepository = new Mock<ITicketRepository>().Object;
            var validatorMock = new Mock<IPlayerDtoValidator>();
            string message;
            validatorMock.Setup(x => x.Validate(playerDto, out message)).Returns(true);

            var useCase = new StartMatchmakingUseCase(ticketRepository, validatorMock.Object);

            var ticket = await useCase.QueuePlayerAsync(playerDto, gameId);

            Assert.NotNull(ticket.Id);
            Assert.Equal(gameId, ticket.GameId);
            Assert.Equivalent(playerDto, ticket.Player);
            Assert.Equal("Searching", ticket.Status);
        }

        [Fact]
        public async Task QueuePlayerAsync_InvalidParameters_ValidationExceptionThrown()
        {
            PlayerDto playerDto = null!;
            const string gameId = "game id";
            var ticketRepository = new Mock<ITicketRepository>().Object;
            var validatorMock = new Mock<IPlayerDtoValidator>();
            string message;
            validatorMock.Setup(x => x.Validate(playerDto, out message)).Returns(false);

            var useCase = new StartMatchmakingUseCase(ticketRepository, validatorMock.Object);

            await Assert.ThrowsAsync<ValidationException>(async () => await useCase.QueuePlayerAsync(playerDto, gameId));
        }
    }
}
