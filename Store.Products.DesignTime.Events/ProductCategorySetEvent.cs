namespace Store.Products.DesignTime.Events;

public sealed class ProductCategorySetEvent
{
    public required Guid ProductId { get; init; }

    public required Guid CategoryId { get; init; }
}