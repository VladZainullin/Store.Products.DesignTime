namespace Store.Products.DesignTime.Events;

public sealed class ProductCostSetEvent
{
    public required Guid ProductId { get; init; }

    public required decimal Cost { get; init; }
}