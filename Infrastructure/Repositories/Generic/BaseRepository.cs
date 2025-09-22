using Domain.Base;
using Domain.Interfaces.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Generic;

public abstract class BaseRepository<TEntity, TContext> :
    BaseRepositoryCore<TEntity, TContext>,
    IReadRepository<TEntity>,
    IWriteRepository<TEntity>
    where TEntity : BaseEntity
    where TContext : DbContext
{
    public BaseRepository(TContext context) : base(context) { }
    
    public virtual async Task<TEntity?> GetByIdAsync(int id)
    {
        return await Entities.FindAsync(id);
    }

    public virtual async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
    {
        return await Entities.AsNoTracking().ToListAsync();
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        await Entities.AddAsync(entity);
        await Context.SaveChangesAsync();
        
        return entity;
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity updatedEntity)
    {
        Context.Update(updatedEntity);
        await Context.SaveChangesAsync();
        
        return updatedEntity;
    }

    public virtual async Task DeleteAsync(TEntity entity)
    {
        Entities.Remove(entity);
        await Context.SaveChangesAsync();
    }
}