using ScalableMatch.Application.Common.Models;

namespace ScalableMatch.Application.Common.Validators
{
    public interface IPlayerDtoValidator
    {
        bool Validate(PlayerDto dto, out string message);
    }
}