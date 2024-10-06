using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.Update;

public class UpdateLeaveTypeCommandValidator : AbstractValidator<UpdateLeaveTypeCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public UpdateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(70).WithMessage("{PropertyName} must not exceed 70 characters");

        RuleFor(p => p.DefaultDays)
            .LessThan(1).WithMessage("{PropertyName} cannot be less than 1")
            .GreaterThan(100).WithMessage("{PropertyName} cannot exceed 1");

        RuleFor(q => q)
            .MustAsync(LeaveTypeNameUnique).WithMessage("Leave type already exists");
    }

    private Task<bool> LeaveTypeNameUnique(UpdateLeaveTypeCommand command, CancellationToken cancellationToken)
        => _leaveTypeRepository.IsLeaveTypeUniqueAsync(command.Name);
}
