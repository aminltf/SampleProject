using Application.Features.Category.Dtos;
using FluentValidation;
using MediatR;

namespace Application.Features.Category.Commands;

public record CreateCategoryCommand(string Name, string Description, string CreatedBy) : IRequest<CategoryDto>;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        
    }
}
