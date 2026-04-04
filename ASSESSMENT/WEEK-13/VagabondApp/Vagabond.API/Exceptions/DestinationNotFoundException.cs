namespace Vagabond.API.Exceptions;

public class DestinationNotFoundException : Exception
{
    public int DestinationId { get; }

    public DestinationNotFoundException(int id)
        : base($"Destination with ID {id} was not found.")
    {
        DestinationId = id;
    }
}