namespace ScalableMatch.Domain.GameSession
{
    public class GameSession : BaseEntity
    {
        public List<Player.Player> Players { get; set; } = [];

        public bool HasEnoughPlayers => Players.Count >= PlayersInGameSession.Minumum;

        public bool IsFull => Players.Count == PlayersInGameSession.Maximum;

        public required string GameId { get; set; }

        public bool AcceptBackfill { get; set; } = false;

        public GameSessionState Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public void AddPlayer(Player.Player player)
        {
            if (IsFull)
                throw new TooManyPlayersException();

            Players.Add(player);
        }
    }
}
