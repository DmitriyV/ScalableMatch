using ScalableMatch.Domain.Common;
using ScalableMatch.Domain.Constants;
using ScalableMatch.Domain.Enums;
using ScalableMatch.Domain.Exceptions;

namespace ScalableMatch.Domain.Entities
{
    public class GameSession : BaseEntity
    {
        private HashSet<Player> Players { get; set; } = [];

        public int NumberOfPlayers => Players.Count;

        public bool HasEnoughPlayers => Players.Count >= PlayersInGameSession.Minumum;

        public bool IsFull => Players.Count == PlayersInGameSession.Maximum;

        public required string GameId { get; set; }

        public bool AcceptBackfill { get; set; } = true;

        public GameSessionState Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public int AverageLatencyInMs => (int) Players.Average(x => x.LatencyInMs);

        public void AddPlayer(Player player)
        {
            if (IsFull)
                throw new TooManyPlayersException();

            Players.Add(player);
        }
    }
}
