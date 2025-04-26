using Application.Common.Interfaces.Repositories;
using Application.Common.Models.Pagination;
using Application.Features.Category.Dtos;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Category.Queries.Handlers;

public class GetAllDeletedCategoriesQueryHandler : IRequestHandler<GetAllDeletedCategoriesQuery, PageResponse<CategoryDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllDeletedCategoriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PageResponse<CategoryDto>> Handle(GetAllDeletedCategoriesQuery request, CancellationToken cancellationToken)
    {
        var query = _unitOfWork.Category.AsQueryable(includeDeleted: true)
            .Where(x => x.IsDeleted)
            .AsQueryable();

        // Pagination
        var totalCount = await query.CountAsync(cancellationToken);
        var items = await query
            .Skip((request.Pagination.PageNumber - 1) * request.Pagination.PageSize)
            .Take(request.Pagination.PageSize)
            .ToListAsync(cancellationToken);
        var dtoList = _mapper.Map<List<CategoryDto>>(items);
        return new PageResponse<CategoryDto>
        {
            Items = dtoList,
            TotalCount = totalCount,
            PageNumber = request.Pagination.PageNumber,
            PageSize = request.Pagination.PageSize
        };
    }
}
