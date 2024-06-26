namespace ScalableMatch.Application.Common.Validators
{
    public interface ITicketIdValidator
    {
        bool Validate(string ticketId, out string message);
    }
}
