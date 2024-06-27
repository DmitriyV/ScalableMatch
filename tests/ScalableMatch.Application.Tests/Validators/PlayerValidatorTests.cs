using ScalableMatch.Application.Common.Models;
using ScalableMatch.Application.Common.Validators;

namespace ScalableMatch.Application.Tests.Validators
{
    public class PlayerValidatorTests
    {
        private readonly IPlayerDtoValidator _playerValidator = new PlayerDtoValidator();

        [Fact]
        public void Validate_DtoIsNull_ShouldReturnFalse()
        {
            var result = _playerValidator.Validate(null!, out var errorMessage);

            Assert.False(result);
            Assert.Equal("PlayerDto cannot be null.", errorMessage);
        }

        [Theory]
        [InlineData(-10)]
        [InlineData(-1)]
        [InlineData(0)]
        public void Validate_InvalidLatency_ShouldReturnFalse(int invalidLatency)
        {
            var dto = new PlayerDto()
            {
                Id = "valid id",
                LatencyInMs = invalidLatency
            };

            var result = _playerValidator.Validate(dto, out var _);

            Assert.False(result);
        }

        [Fact]
        public void Validate_ValidLatency_ShouldReturnTrue()
        {
            const int validLatency = 42;
            var dto = new PlayerDto()
            {
                Id = "valid id",
                LatencyInMs = validLatency
            };

            var result = _playerValidator.Validate(dto, out var _);

            Assert.True(result);
        }
    }
}
