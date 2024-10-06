using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAll;

public class GetLeaveTypesQueryHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeResponse>>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository = leaveTypeRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<LeaveTypeResponse>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
    {
        // Query the database
        var leaveTypes = await _leaveTypeRepository.GetAllAsync();

        // Convert data objects to DTO objects
        var data = _mapper.Map<List<LeaveTypeResponse>>(leaveTypes);

        // Return list of DTO objects
        return data;
    }
}
