namespace ScalableMatch.Application.Common.Exceptions
{
    public class ValidationException(string errorMessage) : Exception(errorMessage)
    {
    }
}
