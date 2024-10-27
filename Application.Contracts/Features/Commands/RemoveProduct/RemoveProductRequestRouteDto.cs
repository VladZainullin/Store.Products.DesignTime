namespace Application.Contracts.Features.Commands.RemoveProduct;

public sealed class RemoveProductRequestRouteDto
{
    public required Guid CategoryId { get; init; }
    
    public required Guid ProductId { get; init; }
}