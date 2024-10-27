using Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts.DbSets.Products;
using Persistence.Contracts.DbSets.Products.Parameters;

namespace Persistence.DbSets;

internal sealed class ProductDbSet(AppDbContext context) : DbSetAdapter<Product>(context), IProductDbSet
{
    public Task<Product> GetAsync(GetProductByIdParameters parameters)
    {
        return context.Products
            .SingleAsync(p => p.Id == parameters.Id, parameters.CancellationToken);
    }
}