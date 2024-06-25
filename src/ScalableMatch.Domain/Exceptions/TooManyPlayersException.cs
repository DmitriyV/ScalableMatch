using ScalableMatch.Domain.Constants;

namespace ScalableMatch.Domain.Exceptions
{
    public class TooManyPlayersException : Exception
    {
        public TooManyPlayersException() : base($"A game session cannot contain more than \"{PlayersInGameSession.Maximum}\" players.")
        {
        }
    }
}
