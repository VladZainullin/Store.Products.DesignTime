namespace Store.Products.DesignTime.Events;

public sealed class ProductTitleSetEvent
{
    public required Guid ProductId { get; init; }

    public required string Title { get; init; }
}