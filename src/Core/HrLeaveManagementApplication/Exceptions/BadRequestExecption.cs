using FluentValidation.Results;

namespace HrLeaveManagementApplication;

public class BadRequestException : Exception
{
    //private ValidationResult validatorResult;
    public List<string> ValidationErrors {get; set;}

    public BadRequestException(string message) : base(message)
    {
        
    }

    public BadRequestException(string message, ValidationResult validatorResult) : base(message)
    {
        ValidationErrors = new();
        foreach (var error in validatorResult.Errors)
        {
            ValidationErrors.Add(error.ErrorMessage);
        }
    }
}
