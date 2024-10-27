namespace Persistence.Contracts.DbSets.Products.Parameters;

public sealed class GetProductByIdParameters
{
    public required Guid Id { get; init; }

    public required CancellationToken CancellationToken { get; init; }
}