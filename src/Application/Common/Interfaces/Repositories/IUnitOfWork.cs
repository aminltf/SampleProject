using Domain.Common.Abstractions;

namespace Application.Common.Interfaces.Repositories;

public interface IUnitOfWork : IAsyncDisposable
{
    IGenericRepository<T> Repository<T>() where T : BaseAuditableEntity;
    IProductRepository Product { get; }
    ICategoryRepository Category { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
