using Application.Common.Interfaces.Repositories;
using Application.Exceptions;
using Application.Features.Product.Dtos;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Queries.Handlers;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProductByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(request.Id, CancellationToken.None);

        if (product is null) throw new NotFoundException($"Product with ID {request.Id} was not found.");

        return _mapper.Map<ProductDto>(product);
    }
}
