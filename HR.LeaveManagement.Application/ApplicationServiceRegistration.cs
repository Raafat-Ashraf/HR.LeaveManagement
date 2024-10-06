using Microsoft.Extensions.DependencyInjection;

namespace HR.LeaveManagement.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }

    /*private static IServiceCollection AddAutoMapperProfilesRegistrations(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetAssembly(typeof(LeaveTypeProfile)));
        /*services.AddAutoMapper(typeof(LeaveAllocationProfile));
        services.AddAutoMapper(typeof(LeaveRequestProfile));#1#


        return services;
    }*/
}
