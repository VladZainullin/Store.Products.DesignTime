using Application.Contracts.Features.Commands.CreateProduct;
using Application.Contracts.Features.Commands.RemoveProduct;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/categories/{categoryId:guid}/products")]
public sealed class ProductsController : AppController
{
    [HttpPost]
    public async Task<NoContentResult> AddProductToCategoryAsync(
        [FromForm] CreateProductRequestFormDto formDto)
    {
        await Sender.Send(new CreateProductCommand(formDto), HttpContext.RequestAborted);

        return NoContent();
    }

    [HttpDelete]
    public async Task<NoContentResult> RemoveProductFromCategoryAsync(
        [FromRoute] RemoveProductRequestRouteDto routeDto)
    {
        await Sender.Send(new RemoveProductCommand(routeDto), HttpContext.RequestAborted);

        return NoContent();
    }
}