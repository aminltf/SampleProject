using Application.Common.Interfaces.Repositories;
using Application.Common.Models.Pagination;
using Application.Features.Product.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Product.Queries.Handlers;

public class GetAllDeletedProductsQueryHandler : IRequestHandler<GetAllDeletedProductsQuery, PageResponse<ProductDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllDeletedProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PageResponse<ProductDto>> Handle(GetAllDeletedProductsQuery request, CancellationToken cancellationToken)
    {
        var query = _unitOfWork.Products.AsQueryable(includeDeleted: true)
            .Where(x => x.IsDeleted)
            .AsQueryable();

        // Pagination
        var totalCount = await query.CountAsync(cancellationToken);
        var items = await query
            .Skip((request.Pagination.PageNumber - 1) * request.Pagination.PageSize)
            .Take(request.Pagination.PageSize)
            .ToListAsync(cancellationToken);
        var dtoList = _mapper.Map<List<ProductDto>>(items);
        return new PageResponse<ProductDto>
        {
            Items = dtoList,
            TotalCount = totalCount,
            PageNumber = request.Pagination.PageNumber,
            PageSize = request.Pagination.PageSize
        };
    }
}
