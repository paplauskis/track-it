using Domain.Base;
using Domain.Interfaces.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Generic;

public abstract class BaseWriteRepository<TEntity, TContext> :
    BaseRepositoryCore<TEntity, TContext>,
    IWriteRepository<TEntity>
    where TEntity : BaseEntity
    where TContext : DbContext
{
    protected BaseWriteRepository(TContext context) : base(context) { }
    
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