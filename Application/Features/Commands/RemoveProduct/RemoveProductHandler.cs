using Application.Contracts.Features.Commands.RemoveProduct;
using MediatR;
using Persistence.Contracts;
using Persistence.Contracts.DbSets.Products.Parameters;

namespace Application.Features.Commands.RemoveProduct;

internal sealed class RemoveProductHandler(IDbContext context) : IRequestHandler<RemoveProductCommand>
{
    public async Task Handle(RemoveProductCommand request, CancellationToken cancellationToken)
    {
        var product = await context.Products.GetAsync(new GetProductByIdParameters
        {
            Id = request.RouteDto.ProductId,
            CancellationToken = cancellationToken
        });
        
        context.Products.Remove(product);
        await context.SaveChangesAsync(cancellationToken);
    }
}