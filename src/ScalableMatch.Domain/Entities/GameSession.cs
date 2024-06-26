using ScalableMatch.Domain.Common;
using ScalableMatch.Domain.Constants;
using ScalableMatch.Domain.Enums;
using ScalableMatch.Domain.Exceptions;

namespace ScalableMatch.Domain.Entities
{
    public class GameSession : BaseEntity
    {
        public List<Player> Players { get; set; } = [];

        public bool HasEnoughPlayers => Players.Count >= PlayersInGameSession.Minumum;

        public bool IsFull => Players.Count == PlayersInGameSession.Maximum;

        public required string GameId { get; set; }

        public bool AcceptBackfill { get; set; } = true;

        public GameSessionState Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public void AddPlayer(Player player)
        {
            if (IsFull)
                throw new TooManyPlayersException();

            Players.Add(player);
        }
    }
}
