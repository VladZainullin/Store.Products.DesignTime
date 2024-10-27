using Application.Contracts.Features.Commands.UpdateProduct;
using Domain.Entities.Products.Parameters;
using MediatR;
using Persistence.Contracts;
using Persistence.Contracts.DbSets.Products.Parameters;

namespace Application.Features.Commands.UpdateProduct;

public sealed class UpdateProductHandler(IDbContext context, TimeProvider timeProvider) : IRequestHandler<UpdateProductCommand>
{
    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await context.Products.GetAsync(new GetProductByIdParameters
        {
            Id = request.RouteDto.ProductId,
            CancellationToken = cancellationToken
        });
        
        product.SetTitle(new SetProductTitleParameters
        {
            Title = request.BodyDto.Title,
            TimeProvider = timeProvider
        });
        
        product.SetDescription(new SetProductDescriptionParameters
        {
            Description = request.BodyDto.Description,
            TimeProvider = timeProvider
        });
        
        product.SetCost(new SetProductCostParameters
        {
            Cost = request.BodyDto.Cost,
            TimeProvider = timeProvider
        });
        
        product.SetQuantity(new SetProductQuantityParameters
        {
            Quantity = request.BodyDto.Quantity,
            TimeProvider = timeProvider
        });

        await context.SaveChangesAsync(cancellationToken);
    }
}