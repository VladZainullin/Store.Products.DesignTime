namespace Store.Products.DesignTime.Events;

public sealed class ProductDescriptionSetEvent
{
    public required Guid ProductId { get; init; }

    public required string Description { get; init; }
}