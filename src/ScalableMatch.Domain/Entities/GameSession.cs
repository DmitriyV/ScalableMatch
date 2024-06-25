using ScalableMatch.Domain.Common;
using ScalableMatch.Domain.Constants;
using ScalableMatch.Domain.Enums;
using ScalableMatch.Domain.Exceptions;

namespace ScalableMatch.Domain.Entities
{
    public class GameSession : BaseEntity
    {
        private HashSet<Player> Players { get; set; } = [];

        public bool HasEnoughPlayers => Players.Count >= PlayersInGameSession.Minumum;

        public bool IsFull => Players.Count == PlayersInGameSession.Maximum;

        public bool AcceptBackfill { get; set; } = true;

        public GameSessionState Status { get; set; }

        public void AddPlayer(Player player)
        {
            var sessionIsFull = Players.Count >= PlayersInGameSession.Maximum;
            if (sessionIsFull)
                throw new TooManyPlayersException();

            Players.Add(player);
        }
    }
}
