using MediatR;

namespace Application.Contracts.Features.Commands.UpdateProductInCategory;

public sealed record UpdateProductCommand(
    UpdateProductRequestRouteDto RouteDto,
    UpdateProductRequestBodyDto BodyDto) : IRequest;