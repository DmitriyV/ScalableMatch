using ScalableMatch.Application.MatchmakingTickets.AssignSession;
using ScalableMatch.Domain.Entities;

namespace ScalableMatch.Application.Tests
{
    public class LatencyRuleTests
    {
        [Fact]
        public void LatencyRule_TargetLatency5_ShouldReturnWithMatchingLatency()
        {
            var rule = new LatencyRule(latencyTolerance: 1);

            var tickets = new List<MatchmakingTicket>()
            {
                new()
                {
                    Id = "ticket id", 
                    GameId = "game id",
                    Player = new Player() {Id = "player id", LatencyInMs = 3}
                },
                new()
                {
                    Id = "ticket id 2",
                    GameId = "game id",
                    Player = new Player() {Id = "player id 2", LatencyInMs = 4}
                },
                new()
                {
                    Id = "ticket id 3",
                    GameId = "game id",
                    Player = new Player() {Id = "player id 3", LatencyInMs = 5}
                },
                new()
                {
                    Id = "ticket id 4",
                    GameId = "game id",
                    Player = new Player() {Id = "player id 4", LatencyInMs = 6}
                },
                new()
                {
                    Id = "ticket id 5",
                    GameId = "game id",
                    Player = new Player() {Id = "player id 5", LatencyInMs = 7}
                }
            };

            int targetLatency = 5;
            var result = rule.Apply(tickets, targetLatency).ToList();

            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void LatencyRule_TargetLatency50_ShouldReturnEmptyList()
        {
            var rule = new LatencyRule(latencyTolerance: 10);

            var tickets = new List<MatchmakingTicket>()
            {
                new()
                {
                    Id = "ticket id",
                    GameId = "game id",
                    Player = new Player() {Id = "player id", LatencyInMs = 3}
                }
            };

            int targetLatency = 50;
            var result = rule.Apply(tickets, targetLatency).ToList();

            Assert.Empty(result);
        }
    }
}
