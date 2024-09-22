namespace ScalableMatch.Domain
{
    public abstract class BaseEntity
    {
        // Using non-generic string types for simplicity
        public required string Id { get; set; }
    }
}
