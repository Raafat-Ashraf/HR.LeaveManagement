namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.Create;

public record CreateLeaveTypeCommand(
    string Name,
    int DefaultDays
) : IRequest<int>;
