using Application.Features.Product.Dtos;
using FluentValidation;
using MediatR;

namespace Application.Features.Product.Commands;

public record CreateProductCommand(string Name, decimal Price, string Description, string CreatedBy) : IRequest<ProductDto>;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        
    }
}
