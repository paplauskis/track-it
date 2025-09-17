using Domain.Base;

namespace Domain.Interfaces.Repositories.Generic;

public interface IGetAllRepository<T> where T : BaseEntity
{
    Task<IReadOnlyCollection<T>> GetAllAsync();
}