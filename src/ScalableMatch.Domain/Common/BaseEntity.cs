namespace ScalableMatch.Domain.Common
{
    public abstract class BaseEntity
    {
        // Using non-generic string types for simplicity
        public required string Id { get; set; }
    }
}
