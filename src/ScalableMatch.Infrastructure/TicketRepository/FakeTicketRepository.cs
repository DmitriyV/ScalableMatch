using ScalableMatch.Domain.Player;
using ScalableMatch.Domain.MatchmakingTicket;
using ScalableMatch.Application.MatchmakingTickets;

namespace ScalableMatch.Infrastructure.TicketRepository
{
    public class FakeTicketRepository : ITicketRepository
    {
        public Task<List<MatchmakingTicket>> GetSearchingTickets()
        {
            List<MatchmakingTicket> tmp =
            [
                new()
                {
                    Id = "1",
                    GameId = "tetris",
                    Player = new Player() { Id = "111", LatencyInMs = 42 },
                    CreatedAt = DateTime.Now,
                    Status = MatchmakingTicketStatus.Searching
                },
                new()
                {
                    Id = "2",
                    GameId = "tetris",
                    Player = new Player() { Id = "222", LatencyInMs = 62 },
                    CreatedAt = DateTime.Now,
                    Status = MatchmakingTicketStatus.Searching
                },
            ];
            return Task.FromResult(tmp);
        }

        public Task<MatchmakingTicket> GetTicketById(string ticketId)
        {
            return Task.FromResult(new MatchmakingTicket()
            {
                Id = "fake id",
                GameId = "fake game id",
                Player = new Player() { Id = "fake player id", LatencyInMs = 42 },
                CreatedAt = DateTime.Now,
                Status = MatchmakingTicketStatus.Searching
            });
        }

        public Task SaveTicket(MatchmakingTicket ticket)
        {
            return Task.CompletedTask;
        }

        public Task UpdateTicket(MatchmakingTicket ticket)
        {
            return Task.CompletedTask;
        }
    }
}
