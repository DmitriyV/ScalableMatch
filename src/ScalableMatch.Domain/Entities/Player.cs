using ScalableMatch.Domain.Common;
using ScalableMatch.Domain.Exceptions;

namespace ScalableMatch.Domain.Entities
{
    public class Player: BaseEntity
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
    }
}
