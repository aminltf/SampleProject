using Application.Features.Product.Dtos;
using MediatR;

namespace Application.Features.Product.Queries;

public record GetProductByIdQuery(Guid Id, bool IncludeDeleted = false) : IRequest<ProductDto>;
