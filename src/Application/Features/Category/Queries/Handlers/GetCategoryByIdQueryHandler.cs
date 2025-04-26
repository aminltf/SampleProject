using Application.Common.Interfaces.Repositories;
using Application.Exceptions;
using Application.Features.Category.Dtos;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Queries.Handlers;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCategoryByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.Category.GetByIdAsync(request.Id, cancellationToken);

        if (category is null) throw new NotFoundException($"Category with ID {request.Id} was not found.");

        return _mapper.Map<CategoryDto>(category);
    }
}
