using FluentValidation;
using MediatR;

namespace Application.Features.Category.Commands;

public record DeleteCategoryCommand(Guid Id, string DeletedBy) : IRequest<Unit>;

public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryCommandValidator()
    {
        
    }
}
