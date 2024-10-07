using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Logging;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAll;

public class GetLeaveTypesQueryHandler(
    ILeaveTypeRepository leaveTypeRepository,
    IMapper mapper,
    IAppLogger<GetLeaveTypesQueryHandler> logger)
    : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeResponse>>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository = leaveTypeRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IAppLogger<GetLeaveTypesQueryHandler> _logger = logger;

    public async Task<List<LeaveTypeResponse>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
    {
        // Query the database
        var leaveTypes = await _leaveTypeRepository.GetAllAsync();

        // Convert data objects to DTO objects
        var data = _mapper.Map<List<LeaveTypeResponse>>(leaveTypes);

        // Add log
        _logger.LogInformation("Leave types were retrieved successfully");

        // Return list of DTO objects
        return data;
    }
}
