using ScalableMatch.Domain.Common;
using ScalableMatch.Domain.Entities;

namespace ScalableMatch.Domain.Events
{
    public class GameSessionReadyEvent : BaseEvent
    {
        public GameSessionReadyEvent(GameSession session)
        {
            GameSession = session;
        }

        public GameSession GameSession { get; }
    }
}
