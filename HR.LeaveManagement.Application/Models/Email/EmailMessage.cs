namespace HR.LeaveManagement.Application.Models.Email;

public abstract class EmailMessage
{
    public string To { get; set; } = null!;
    public string Subject { get; set; } = null!;
    public string Body { get; set; } = null!;
}
