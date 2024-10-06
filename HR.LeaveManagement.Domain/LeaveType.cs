using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Domain;

public class LeaveType : BaseEntity
{
    public string Name { get; init; } = null!;
    public int DefaultDays { get; init; }
}
