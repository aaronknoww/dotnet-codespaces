using FluentValidation;
using HrLeaveManagementDomain;

namespace HrLeaveManagementApplication;

// Recibe la clase u objeto  a la que se le va aplicar las validaciones necesarias en este caso CreateLeaveTypeCommand.
public class CreateLeaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        this._leaveTypeRepository = leaveTypeRepository;
        
        RuleFor(prop => prop.Name).NotEmpty().WithMessage("{PropertyName} is required").NotNull()
                .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

        RuleFor(prop => prop.DefaultDays).GreaterThan(100).WithMessage("{PropertyName} cannot exceed 100")
        .LessThan(1).WithMessage("{PropertyName} cannot less than 1");

        RuleFor(q => q).MustAsync(LeaveTypeNameUnique).WithMessage("Leave type alerady exists");
        
        //RuleFor(p => p.DefaultDays).LessThan(100).WithMessage("{PropertyName} cannot exceed 100") 
        //.GreaterThan(1).WithMessage("{PropertyName} cannot be less than 1");       
    }
    // TODO: revisar si el metodo de abajo debe de ser sincrono o no, en el video no es.
    private async Task<bool> LeaveTypeNameUnique(CreateLeaveTypeCommand command, CancellationToken token)
    {
        return await _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
    }
}
