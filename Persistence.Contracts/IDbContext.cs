using Persistence.Contracts.DbSets.Products;

namespace Persistence.Contracts;

public interface IDbContext
{
    IProductDbSet Categories { get; }
    
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}