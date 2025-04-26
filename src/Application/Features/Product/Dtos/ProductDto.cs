using FluentValidation;

namespace Application.Features.Product.Dtos;

public record ProductDto(Guid Id, string Name, decimal Price, string Description);

public class ProductDtoValidator : AbstractValidator<ProductDto>
{
    public ProductDtoValidator()
    {
        
    }
}
