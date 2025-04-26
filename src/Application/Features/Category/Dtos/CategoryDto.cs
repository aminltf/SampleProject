using Application.Features.Product.Dtos;
using FluentValidation;

namespace Application.Features.Category.Dtos;

public record CategoryDto(Guid Id, string Name, string Description, ICollection<ProductDto> Products);

public class CategoryDtoValidator : AbstractValidator<CategoryDto>
{
    public CategoryDtoValidator()
    {
        
    }
}
