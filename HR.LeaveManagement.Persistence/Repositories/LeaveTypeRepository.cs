using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveTypeRepository(HrDatabaseContext hrDatabaseContext)
    : GenericRepository<LeaveType>(hrDatabaseContext), ILeaveTypeRepository
{
    public async Task<bool> IsLeaveTypeUniqueAsync(string name)
    {
        return await _hrDatabaseContext.LeaveTypes.AnyAsync(qt => qt.Name == name);
    }
}
