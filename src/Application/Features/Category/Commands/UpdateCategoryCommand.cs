using Application.Features.Category.Dtos;
using FluentValidation;
using MediatR;

namespace Application.Features.Category.Commands;

public record UpdateCategoryCommand(Guid Id, string Name, string Description, string ModifiedBy) : IRequest<CategoryDto>;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        
    }
}
