using Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Generic;

public abstract class BaseRepositoryCore<TEntity, TContext>
    where TEntity : BaseEntity
    where TContext : DbContext
{
    protected readonly TContext Context;
    protected readonly DbSet<TEntity> Entities;

    protected BaseRepositoryCore(TContext context)
    {
        Context = context;
        Entities = Context.Set<TEntity>();
    }
}