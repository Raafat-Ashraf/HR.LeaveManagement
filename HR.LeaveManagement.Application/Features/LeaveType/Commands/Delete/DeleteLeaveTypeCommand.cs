namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.Delete;

public abstract record DeleteLeaveTypeCommand(int Id) : IRequest<Unit>;
