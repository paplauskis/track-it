using Domain.Base;

namespace Domain.Interfaces.Repositories.Generic;

public interface IUpdateRepository<T> where T : BaseEntity
{
    Task<T> UpdateAsync(T updatedEntity);
}