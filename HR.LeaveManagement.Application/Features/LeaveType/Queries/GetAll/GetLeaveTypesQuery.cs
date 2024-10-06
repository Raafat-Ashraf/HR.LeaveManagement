using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAll;

public record GetLeaveTypesQuery : IRequest<List<LeaveTypeResponse>>, IRequest<LeaveTypeDetailsResponse>;
