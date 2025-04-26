using Application.Common.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Category.Commands.Handlers;

public class RestoreCategoryCommandHandler : IRequestHandler<RestoreCategoryCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public RestoreCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(RestoreCategoryCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.Category.RestoreAsync(request.Id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
