using Application.Common.Models.Pagination;
using Application.Features.Category.Dtos;
using MediatR;

namespace Application.Features.Category.Queries;

public class GetAllDeletedCategoriesQuery : IRequest<PageResponse<CategoryDto>>
{
    public PageRequest Pagination { get; set; } = new();
}
