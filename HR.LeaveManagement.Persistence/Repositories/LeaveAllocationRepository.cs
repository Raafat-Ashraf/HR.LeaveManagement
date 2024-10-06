using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveAllocationRepository(HrDatabaseContext hrDatabaseContext)
    : GenericRepository<LeaveAllocation>(hrDatabaseContext), ILeaveAllocationRepository
{
    public async Task<LeaveAllocation?> GetLeaveAllocationWithDetails(int id)
    {
        var leaveAllocation = await _hrDatabaseContext.LeaveAllocations.Include(x => x.LeaveType)
            .FirstOrDefaultAsync(x => x.Id == id);

        return leaveAllocation;
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
    {
        return await _hrDatabaseContext.LeaveAllocations
            .Include(x => x.LeaveType)
            .ToListAsync();
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId)
    {
        return await _hrDatabaseContext.LeaveAllocations
            .Include(x => x.LeaveType)
            .Where(x => x.EmployeeId == userId)
            .ToListAsync();
    }

    public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
    {
        return await _hrDatabaseContext.LeaveAllocations
            .AnyAsync(q => q.EmployeeId == userId && q.LeaveTypeId == leaveTypeId && q.Period == period);
    }

    public async Task AddAllocations(List<LeaveAllocation> allocations)
    {
        await _hrDatabaseContext.LeaveAllocations.AddRangeAsync(allocations);
    }

    public async Task<LeaveAllocation?> GetUserAllocations(string userId, int leaveTypeId)
    {
        return await _hrDatabaseContext.LeaveAllocations
            .FirstOrDefaultAsync(q => q.EmployeeId == userId && q.LeaveTypeId == leaveTypeId);
    }
}
