using Domain.Base;

namespace Domain.Interfaces.Repositories.Generic;

public interface IGetByIdRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(int id);
}