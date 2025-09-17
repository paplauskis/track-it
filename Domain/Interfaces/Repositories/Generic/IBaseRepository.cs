using Domain.Base;

namespace Domain.Interfaces.Repositories.Generic;

public interface IBaseRepository<T> : 
    IReadRepository<T>,
    IWriteRepository<T>
    where T : BaseEntity
{
}