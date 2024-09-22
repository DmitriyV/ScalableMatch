namespace ScalableMatch.Domain.GameSession
{
    public class TooManyPlayersException : Exception
    {
        public TooManyPlayersException() : base($"A game session cannot contain more than \"{PlayersInGameSession.Maximum}\" players.")
        {
        }
    }
}
