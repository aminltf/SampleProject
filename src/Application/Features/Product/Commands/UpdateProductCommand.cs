using Application.Features.Product.Dtos;
using FluentValidation;
using MediatR;

namespace Application.Features.Product.Commands;

public record UpdateProductCommand(Guid Id, string Name, decimal Price, string Description, string ModifiedBy) : IRequest<ProductDto>;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        
    }
}
