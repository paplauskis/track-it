using Domain.Base;

namespace Domain.Interfaces.Repositories.Generic;

public interface IWriteRepository<T> : 
    ICreateRepository<T>,
    IUpdateRepository<T>,
    IDeleteRepository<T>
    where T : BaseEntity
{
}