using Microsoft.Extensions.DependencyInjection;

namespace HrLeaveManagementPersistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        return services;
    }

}
