using Domain.Base;

namespace Domain.Interfaces.Data;

public interface ITypeEntityDataReader
{
    IReadOnlyCollection<T> Read<T>() where T : TypeEntity, new();

    Task<IReadOnlyCollection<T>> ReadAsync<T>() where T : TypeEntity, new();
}