using FluentValidation;
using MediatR;

namespace Application.Features.Product.Commands;

public record RestoreProductCommand(Guid Id, string ModifiedBy) : IRequest<Unit>;

public class RestoreProductCommandValidator : AbstractValidator<RestoreProductCommand>
{
    public RestoreProductCommandValidator()
    {
        
    }
}
