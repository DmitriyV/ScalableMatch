using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ScalableMatch.API.Controllers;
using ScalableMatch.API.Models;
using ScalableMatch.Domain;

namespace ScalableMatch.API.Tests
{
    public class MatchmakingControllerTests
    {
        [Fact]
        public void StartMatchmaking_RequestValidation_PlayerIdShouldNotBeEmpty()
        {
            // Arrange
            var logger = new Mock<ILogger<MatchmakingController>>().Object;
            var matchMackingService = new Mock<IMatchmakingService>().Object;
            var controller = new MatchmakingController(logger, matchMackingService);
            var playerWithEmptyId = new Player() { PlayerId = string.Empty, LatencyInMs = 10 };
            var request = new StartMatchmakingRequest
            {
                Player = playerWithEmptyId
            };

            // Act
            var response = controller.StartMatchmaking(request);

            // Assert
            Assert.IsType<BadRequestObjectResult>(response);
        }

        [Theory]
        [InlineData(-10)]
        [InlineData(-1)]
        [InlineData(0)]
        public void StartMatchmaking_RequestValidation_LatencyMustBePositive(int invalidLatency)
        {
            // Arrange
            var logger = new Mock<ILogger<MatchmakingController>>().Object;
            var matchMackingService = new Mock<IMatchmakingService>().Object;
            var controller = new MatchmakingController(logger, matchMackingService);
            var playerWithInvalidLatency = new Player() { PlayerId = "player id", LatencyInMs = invalidLatency };
            var request = new StartMatchmakingRequest
            {
                Player = playerWithInvalidLatency
            };

            // Act
            var response = controller.StartMatchmaking(request);

            // Assert
            Assert.IsType<BadRequestObjectResult>(response);
        }
    }
}