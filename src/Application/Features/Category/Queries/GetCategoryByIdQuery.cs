using Application.Features.Category.Dtos;
using MediatR;

namespace Application.Features.Category.Queries;

public record GetCategoryByIdQuery(Guid Id, bool IncludeDeleted = false) : IRequest<CategoryDto>;
