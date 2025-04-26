using FluentValidation;
using MediatR;

namespace Application.Features.Category.Commands;

public record RestoreCategoryCommand(Guid Id, string ModifiedBy) : IRequest<Unit>;

public class RestoreCategoryCommandValidator : AbstractValidator<RestoreCategoryCommand>
{
    public RestoreCategoryCommandValidator()
    {
        
    }
}
