using ScalableMatch.Application.Common.Models;

namespace ScalableMatch.Application.Common.Validators
{
    public class PlayerDtoValidator : IPlayerDtoValidator
    {
        public bool Validate(PlayerDto dto, out string message)
        {
            message = string.Empty;

            if (dto == null)
            {
                message = "PlayerDto cannot be null.";
                return false;
            }

            if (string.IsNullOrEmpty(dto.Id))
            {
                message = "Player's Id must be provided.";
                return false;
            }

            if (dto.LatencyInMs <= 0)
            {
                message = "Player's latency must be positive.";
                return false;
            }

            return true;
        }
    }
}
