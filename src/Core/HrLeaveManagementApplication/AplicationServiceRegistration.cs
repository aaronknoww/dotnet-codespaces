using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HrLeaveManagementApplication;

public static class AplicationServiceRegistration
{
    public static IServiceCollection AddAplicationServices(this IServiceCollection services) 
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }

}
