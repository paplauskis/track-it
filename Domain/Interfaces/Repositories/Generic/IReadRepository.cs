using Domain.Base;

namespace Domain.Interfaces.Repositories.Generic;

public interface IReadRepository<T> : IGetByIdRepository<T>, IGetAllRepository<T>
    where T : BaseEntity
{
}