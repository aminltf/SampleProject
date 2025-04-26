using FluentValidation;
using MediatR;

namespace Application.Features.Product.Commands;

public record DeleteProductCommand(Guid Id, string DeletedBy) : IRequest<Unit>;

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        
    }
}
