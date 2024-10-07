using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.Update;

public class UpdateLeaveTypeCommandValidator : AbstractValidator<UpdateLeaveTypeCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public UpdateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;

        RuleFor(x=>x.Id)
            .NotNull()
            .MustAsync(LeaveTypeMustExist);

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

    private async Task<bool> LeaveTypeMustExist(int id, CancellationToken cancellationToken)
        => await _leaveTypeRepository.GetByIdAsync(id) != null;

    private async Task<bool> LeaveTypeNameUnique(UpdateLeaveTypeCommand command, CancellationToken cancellationToken)
        => await _leaveTypeRepository.IsLeaveTypeUniqueAsync(command.Name);


}
