using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveRequestRepository(HrDatabaseContext hrDatabaseContext)
    : GenericRepository<LeaveRequest>(hrDatabaseContext), ILeaveRequestRepository
{

    public async Task<LeaveRequest?> GetLeaveRequestWithDetailsAsync(int id)
    {
        var leaveRequest = await _hrDatabaseContext.LeaveRequests
            .Include(q => q.LeaveType)
            .FirstOrDefaultAsync(q => q.Id == id);

        return leaveRequest;
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
    {
        var leaveRequests = await _hrDatabaseContext.LeaveRequests
            .Include(x => x.LeaveType)
            .ToListAsync();

        return leaveRequests;
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(string userId)
    {
        var leaveRequests = await _hrDatabaseContext.LeaveRequests
            .Where(x=>x.RequestingEmployeeId == userId)
            .Include(x=>x.LeaveType)
            .ToListAsync();

        return leaveRequests;
    }
}
