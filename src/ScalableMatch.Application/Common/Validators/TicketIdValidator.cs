namespace ScalableMatch.Application.Common.Validators
{
    public class TicketIdValidator : ITicketIdValidator
    {
        public bool Validate(string ticketId, out string message)
        {
            message = string.Empty;

            if (string.IsNullOrEmpty(ticketId))
            {
                message = "TicketId is required.";
                return false;
            }

            return true;
        }
    }
}
