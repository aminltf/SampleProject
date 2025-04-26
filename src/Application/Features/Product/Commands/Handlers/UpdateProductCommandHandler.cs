using Application.Common.Interfaces.Repositories;
using Application.Exceptions;
using Application.Features.Product.Dtos;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Commands.Handlers;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Product.GetByIdAsync(request.Id, cancellationToken);

        if (product is null) throw new NotFoundException($"Product with ID {request.Id} was not found.");

        product.ModifiedBy = request.ModifiedBy;
        product.Name = request.Name;
        product.Price = request.Price;
        product.Description = request.Description;

        await _unitOfWork.Product.UpdateAsync(product, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return _mapper.Map<ProductDto>(product);
    }
}
