using HR.LeaveManagement.Application.Logging;
using Microsoft.Extensions.Logging;

namespace HR.LeaveManagement.Infrastructure.Logging;

public class AppLogger<T>(ILoggerFactory loggerFactory) : IAppLogger<T>
{
    private readonly ILogger<T> _logger = loggerFactory.CreateLogger<T>();


    public void LogInformation(string message, params object[] args)
    {
        _logger.LogInformation(message, args);
    }

    public void LogWarning(string message, params object[] args)
    {
        _logger.LogWarning(message, args);
    }
}
