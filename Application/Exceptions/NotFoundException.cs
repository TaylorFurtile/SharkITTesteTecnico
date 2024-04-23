namespace SharkITTesteTecnico.Application.Exceptions;

public class NotFoundException(string entity) : Exception($"{entity} was not found.")
{
}
