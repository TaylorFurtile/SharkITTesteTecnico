using FluentValidation.Results;

namespace SharkITTesteTecnico.Application.Exceptions
{
    public class BadRequestException(string message, IDictionary<string, string[]> errors) : Exception(message)
    {
        public IDictionary<string, string[]> Errors { get; set; } = errors;
    }
}
