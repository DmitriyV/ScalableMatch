using ScalableMatch.Application.Common.Validators;

namespace ScalableMatch.Application.Tests
{
    public class TicketIdValidatorTests
    {
        private readonly ITicketIdValidator _ticketValidator = new TicketIdValidator();

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Validate_TicketIdIsEmtpy_ShouldReturnFalse(string invalidId)
        {
            var result = _ticketValidator.Validate(invalidId, out var errorMessage);

            Assert.False(result);
            Assert.Equal("TicketId is required.", errorMessage);
        }

        [Fact]
        public void Validate_TicketIdIsCorrect_ShouldReturnTrue()
        {
            const string ticketId = "ticket id";

            var result = _ticketValidator.Validate(ticketId, out var errorMessage);

            Assert.True(result);
        }
    }
}
