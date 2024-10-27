using Domain.Entities.Products;
using Persistence.Contracts.DbSets.Products.Parameters;

namespace Persistence.Contracts.DbSets.Products;

public interface IProductDbSet : IDbSet<Product>
{
    public Task<Product> GetAsync(GetProductByIdParameters parameters);
}