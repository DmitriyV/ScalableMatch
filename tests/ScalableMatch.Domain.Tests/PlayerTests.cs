using ScalableMatch.Domain.Entities;
using ScalableMatch.Domain.Exceptions;

namespace ScalableMatch.Domain.Tests
{
    public class PlayerTests
    {
        [Theory]
        [InlineData(-10)]
        [InlineData(-1)]
        [InlineData(0)]
        public void CreatingPlayer_InvalidLatency_ShouldThrowException(int invalidLatency)
        {
            Assert.Throws<InvalidLatencyException>(() => new Player() { Id = "id", LatencyInMs = invalidLatency });
        }

        [Fact]
        public void CreatingPlayer_ValidLatency_PlayerShouldBeCreated()
        {
            var expected = new Player() { Id = "id", LatencyInMs = 42 };

            Assert.NotNull(expected);
        }
    }
}