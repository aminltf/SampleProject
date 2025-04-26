#nullable disable

using Application.Common.Interfaces.Repositories;
using Domain.Common.Abstractions;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseAuditableEntity
{
    protected readonly ApplicationContext _context;

    public GenericRepository(ApplicationContext context) => _context = context;

    public IQueryable<T> AsQueryable(bool includeDeleted = false)
    {
        var query = _context.Set<T>().AsQueryable();

        if (!includeDeleted)
            query = query.Where(x => !x.IsDeleted);

        return query;
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Set<T>().FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        await _context.Set<T>().AddAsync(entity, cancellationToken);
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _context.Set<T>().FindAsync(new object[] { id }, cancellationToken);
        entity.IsDeleted = true;
        _context.Set<T>().Update(entity);
    }

    public async Task RestoreAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _context.Set<T>()
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        entity.IsDeleted = false;
        _context.Set<T>().Update(entity);
    }
}
