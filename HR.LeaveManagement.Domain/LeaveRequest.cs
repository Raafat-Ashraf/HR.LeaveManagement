using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Domain;

public class LeaveRequest : BaseEntity
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public DateTime DateRequested { get; set; }
    public string RequestComments { get; set; } = null!;

    public bool? Approved { get; set; }
    public bool Cancelled { get; set; }

    public int LeaveTypeId { get; set; }
    public LeaveType LeaveType { get; set; } = new();

    public string RequestingEmployeeId { get; set; } = null!;

}
