using Domain.Base;
using Domain.Interfaces.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Generic;

public abstract class BaseReadRepository<TEntity, TContext> :
    BaseRepositoryCore<TEntity, TContext>,
    IReadRepository<TEntity>
    where TEntity : BaseEntity
    where TContext : DbContext
{
    public BaseReadRepository(TContext context) : base(context) { }
    
    public virtual async Task<TEntity?> GetByIdAsync(int id)
    {
        return await Entities.FindAsync(id);
    }

    public virtual async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
    {
        return await Entities.AsNoTracking().ToListAsync();
    }
}