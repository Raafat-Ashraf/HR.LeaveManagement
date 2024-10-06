namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;

public abstract record GetLeaveTypeDetailsQuery(int Id) : IRequest<LeaveTypeDetailsResponse>;
