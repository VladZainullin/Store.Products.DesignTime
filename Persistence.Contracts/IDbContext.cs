using Persistence.Contracts.DbSets.Products;

namespace Persistence.Contracts;

public interface IDbContext
{
    IProductDbSet Products { get; }
    
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}