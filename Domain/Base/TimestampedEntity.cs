namespace Domain.Base;

public abstract class TimestampedEntity : BaseEntity
{
    public DateTime CreatedAt { get; } =  DateTime.UtcNow;
}