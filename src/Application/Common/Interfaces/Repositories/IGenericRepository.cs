using Domain.Common.Abstractions;

namespace Application.Common.Interfaces.Repositories;

public interface IGenericRepository<T> where T : BaseAuditableEntity
{
    IQueryable<T> AsQueryable(bool includeDeleted = false);
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
    Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task AddAsync(T entity, CancellationToken cancellationToken);
    Task UpdateAsync(T entity, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task RestoreAsync(Guid id, CancellationToken cancellationToken);
}
