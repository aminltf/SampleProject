#nullable disable

using Application.Common.Interfaces.Repositories;
using Domain.Common.Abstractions;
using Infrastructure.Contexts;
using System.Collections;

namespace Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationContext _context;
    private Hashtable _repositories;

    public UnitOfWork(ApplicationContext context, IProductRepository products, ICategoryRepository category)
    {
        _context = context;
        Product = products;
        Category = category;
    }

    public IProductRepository Product { get; }
    public ICategoryRepository Category { get; }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
    }

    public IGenericRepository<T> Repository<T>() where T : BaseAuditableEntity
    {
        if (_repositories == null)
            _repositories = new Hashtable();

        var type = typeof(T).Name;

        if (!_repositories.ContainsKey(type))
        {
            var repositoryType = typeof(GenericRepository<T>);
            var repositoryInstance = Activator.CreateInstance(repositoryType, _context);

            _repositories.Add(type, repositoryInstance);
        }

        return (IGenericRepository<T>)_repositories[type];
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
