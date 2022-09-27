using Finbuckle.MultiTenant;
using Microsoft.Extensions.DependencyInjection;

namespace APIAPRSoftware.Services
{
    public static class IServicesCollectionExtensions
    {
        public static void AddMultitenanceConfiguration(this IServiceCollection services,string connectionString)
        {
            services.AddMultiTenant<TenantInfo>()
                .WithRouteStrategy()
                .WithConfigurationStore();

        }
    }
}
