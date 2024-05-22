using AIO.Contracts.IServices.Custom;
using Microsoft.Extensions.DependencyInjection;

namespace AIO.Infrastructure.Extentions;
public static class BackGroundJobsBuilderExtensions
{
    public static IServiceCollection AddBackgroundJobs(this IServiceCollection services)
    {
        return services
               .AddScoped<IJobs, Jobs>();
    }
}
