using ScalableMatch.Domain.Common;
using ScalableMatch.Domain.Constants;
using ScalableMatch.Domain.Enums;
using ScalableMatch.Domain.Exceptions;

namespace ScalableMatch.Domain.Entities
{
    public class GameSession : BaseEntity
    {
        private HashSet<Player> _players { get; set; } = [];

        public bool HasEnoughPlayers => _players.Count >= PlayersInGameSession.Minumum;

        public bool IsFull => _players.Count == PlayersInGameSession.Maximum;

        public bool AcceptBackfill { get; set; } = true;

        public GameSessionState Status { get; set; }

        public void AddPlayer(Player player)
        {
            var sessionIsFull = _players.Count >= PlayersInGameSession.Maximum;
            if (sessionIsFull)
                throw new TooManyPlayersException();

            _players.Add(player);
        }
    }
}
