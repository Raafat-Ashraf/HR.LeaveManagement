namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.Update;

public abstract class UpdateLeaveTypeCommand : IRequest<Unit>
{
    public string Name { get; set; } = string.Empty;
    public int DefaultDays { get; set; }
}
