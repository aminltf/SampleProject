using Application.Common.Interfaces.Repositories;
using Application.Exceptions;
using Application.Features.Category.Dtos;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Commands.Handlers;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.Category.GetByIdAsync(request.Id, cancellationToken);

        if (category is null) throw new NotFoundException($"Category with ID {request.Id} was not found.");

        category.ModifiedBy = request.ModifiedBy;
        category.Name = request.Name;
        category.Description = request.Description;

        await _unitOfWork.Category.UpdateAsync(category, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return _mapper.Map<CategoryDto>(category);
    }
}
