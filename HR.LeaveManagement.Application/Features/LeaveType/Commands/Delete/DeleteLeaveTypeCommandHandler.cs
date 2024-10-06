using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.Delete;

public class DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
    : IRequestHandler<DeleteLeaveTypeCommand, Unit>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository = leaveTypeRepository;


    public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        // retrieve domain entity object
        if (await _leaveTypeRepository.GetByIdAsync(request.Id) is not { } leaveTypeToDelete)
            throw new NotFoundException(nameof(Domain.LeaveType), request.Id);

        // delete record
        await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);

        // return record
        return Unit.Value;
    }
}
