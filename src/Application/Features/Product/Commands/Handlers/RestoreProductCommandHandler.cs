using Application.Common.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Product.Commands.Handlers;

public class RestoreProductCommandHandler : IRequestHandler<RestoreProductCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public RestoreProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(RestoreProductCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.Product.RestoreAsync(request.Id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
