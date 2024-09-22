using Moq;
using ScalableMatch.Application.MatchmakingTickets.AssignSession;
using ScalableMatch.Domain.Player;
using ScalableMatch.Domain.MatchmakingTicket;

namespace ScalableMatch.Application.Tests
{
    public class MatchCreatorTests
    {
        [Fact]
        public void CreateForCurrentTicket_NoMatchingTickets_OnlyCurrentTicketInMatch()
        {
            const int targetLatency = 42;
            var currentTicket = new MatchmakingTicket()
            {
                Id = "ticket id",
                GameId = "one game",
                Player = new Player() { Id = "player id", LatencyInMs = targetLatency }
            };

            var differentGameTickets = new List<MatchmakingTicket>()
            {
                new ()
                {
                    Id = "ticket id 2",
                    GameId = "another game",
                    Player = new Player() { Id = "player id", LatencyInMs = targetLatency }
                }
            };

            var latencyRule = new Mock<ILatencyRule>();
            latencyRule.Setup(x => x.Apply(It.IsAny<List<MatchmakingTicket>>(), targetLatency)).Returns([]);

            var matchCreator = new MatchCreator(latencyRule.Object);

            var result = matchCreator.CreateForCurrentTicket(differentGameTickets, currentTicket);

            Assert.Single(result);
        }

        [Fact]
        public void CreateForCurrentTicket_20MatchingTickets_Only10TicketsInMatch()
        {
            const int targetLatency = 42;
            var currentTicket = new MatchmakingTicket()
            {
                Id = "ticket id",
                GameId = "one game",
                Player = new Player() { Id = "player id", LatencyInMs = targetLatency }
            };

            var tickets = new List<MatchmakingTicket>();
            for (int i = 0; i < 20; i++)
            {
                tickets.Add(new MatchmakingTicket()
                {
                    Id = "ticket id " + i,
                    GameId = "one game",
                    Player = new Player() { Id = "player id " + i, LatencyInMs = targetLatency }
                });
            }


            var latencyRule = new Mock<ILatencyRule>();
            latencyRule.Setup(x => x.Apply(It.IsAny<List<MatchmakingTicket>>(), targetLatency)).Returns(tickets);

            var matchCreator = new MatchCreator(latencyRule.Object);

            var result = matchCreator.CreateForCurrentTicket(tickets, currentTicket);

            Assert.Equal(10, result.Count);
        }
    }
}
