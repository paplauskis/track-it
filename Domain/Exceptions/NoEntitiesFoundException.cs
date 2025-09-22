namespace Domain.Exceptions;

public class NoEntitiesFoundException :  Exception
{
    public NoEntitiesFoundException() { }
    
    public NoEntitiesFoundException(string message) : base(message) { }
}