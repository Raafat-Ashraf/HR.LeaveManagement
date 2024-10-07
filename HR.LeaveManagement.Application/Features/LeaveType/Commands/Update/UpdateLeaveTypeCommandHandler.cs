using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Logging;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.Update;

public class UpdateLeaveTypeCommandHandler(
    IMapper mapper,
    ILeaveTypeRepository leaveTypeRepository,
    IAppLogger<UpdateLeaveTypeCommandHandler> logger)
    : IRequestHandler<UpdateLeaveTypeCommand, Unit>
{
    private readonly IMapper _mapper = mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository = leaveTypeRepository;
    private readonly IAppLogger<UpdateLeaveTypeCommandHandler> _logger = logger;


    public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        // Validate incoming data
        var validator = new UpdateLeaveTypeCommandValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (validationResult.Errors.Any())
        {
            _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(LeaveType), request.Id);
            throw new BadRequestException("Invalid LeaveType", validationResult);
        }

        // Convert to domain entity object
        var leaveTypeToUpdate = _mapper.Map<Domain.LeaveType>(request);

        // Add to database
        await _leaveTypeRepository.UpdateAsync(leaveTypeToUpdate);

        // Return Unit value
        return Unit.Value;
    }
}
