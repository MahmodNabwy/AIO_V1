using AIO.Infrastructure.Extentions;
using Hangfire;
using Hangfire.Dashboard.BasicAuthorization;
using Hangfire.SqlServer;

namespace AIO.API.ServiceBuilderExtensions;

public static class RegisterHangFireExtension
{
    public static IServiceCollection RegisterHangFire(this IServiceCollection services, string connstring)
    {
        //builder.Services.AddHangfire(x => x.UseSqlServerStorage(connString));
        return services.AddHangfire(x => x
                    .UseSqlServerStorage(
                       connstring,
                        new SqlServerStorageOptions
                        {
                            PrepareSchemaIfNecessary = true
                        }
                    ))
         .AddHangfireServer(options =>
         options.Queues = new[] { "a", "b", "c", "default" })
         .AddBackgroundJobs();
    }

    public static IApplicationBuilder RegisterHangFireDashBoard(this IApplicationBuilder app)
    {

        return app.UseHangfireDashboard("/DHJobs", new DashboardOptions
        {
            DashboardTitle = "AIO Jobs",
            IgnoreAntiforgeryToken = true,
            Authorization = new[] { new BasicAuthAuthorizationFilter(new BasicAuthAuthorizationFilterOptions
            {
                RequireSsl = false,
                SslRedirect = false,
                LoginCaseSensitive = true,
                Users = new []
                {
                    new BasicAuthAuthorizationUser
                    {
                        Login = "Admin",
                        PasswordClear =  "Admin_123-"
                    }
                }

            }) }
        });
    }
}