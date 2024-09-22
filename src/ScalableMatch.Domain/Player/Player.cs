namespace ScalableMatch.Domain.Player
{
    public class Player : BaseEntity
    {
        private int _latencyInMs;

        public required int LatencyInMs
        {
            get => _latencyInMs;
            set
            {
                if (value <= 0)
                    throw new InvalidLatencyException(value);

                _latencyInMs = value;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Player player &&
                   Id == player.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
