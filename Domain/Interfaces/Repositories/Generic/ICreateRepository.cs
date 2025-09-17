using Domain.Base;

namespace Domain.Interfaces.Repositories.Generic;

public interface ICreateRepository<T> where T : BaseEntity
{
    Task<T> AddAsync(T entity);
}