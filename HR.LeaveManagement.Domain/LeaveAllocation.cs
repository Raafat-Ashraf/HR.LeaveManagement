using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Domain;

public class LeaveAllocation : BaseEntity
{
    public int NumberOfDays { get; set; }
    public int Period { get; set; }

    public int LeaveTypeId { get; set; }
    public LeaveType LeaveType { get; set; } = new();
    public string EmployeeId { get; set; } = string.Empty;
}
