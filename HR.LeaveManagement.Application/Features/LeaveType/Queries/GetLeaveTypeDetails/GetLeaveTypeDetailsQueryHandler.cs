using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;

public class GetLeaveTypeDetailsQueryHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsResponse>
{
    private readonly IMapper _mapper = mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository = leaveTypeRepository;

    public async Task<LeaveTypeDetailsResponse> Handle(GetLeaveTypeDetailsQuery request,
        CancellationToken cancellationToken)
    {
        // Query the database
        if (await _leaveTypeRepository.GetByIdAsync(request.Id) is not { } leaveType)
            throw new NotFoundException(nameof(Domain.LeaveType), request.Id);

        // convert data object to DTO object
        var data = _mapper.Map<LeaveTypeDetailsResponse>(leaveType);

        // return list of DTO object
        return data;
    }
}
