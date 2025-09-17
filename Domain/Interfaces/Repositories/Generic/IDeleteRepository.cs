using Domain.Base;

namespace Domain.Interfaces.Repositories.Generic;

public interface IDeleteRepository<T> where T : BaseEntity
{
    Task DeleteAsync(T entity);
}