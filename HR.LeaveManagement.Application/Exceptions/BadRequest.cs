using FluentValidation.Results;

namespace HR.LeaveManagement.Application.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message)
    {

    }
    public BadRequestException(string message, ValidationResult innerException) : base(message)
    {
        ValidationErrors = innerException.Errors.Select(e => e.ErrorMessage).ToList();
    }

    public List<string> ValidationErrors { get; set; } = [];


}
