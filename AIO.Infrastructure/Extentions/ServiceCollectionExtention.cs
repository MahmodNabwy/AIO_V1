using AIO.Core.Entities.Auth;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.TokenProviders;
using AIO.Shared.Consts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AIO.Infrastructure.Extentions
{
    public static class ServiceCollectionExtention
    {
        // extention for bulider.service
        public static void AddDbContext(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<AIODBContext>(options =>
            {
                options.UseSqlServer(connectionString, b =>
                {
                    b.MigrationsAssembly(typeof(AIODBContext).Assembly.FullName);
                    // .UseNetTopologySuite();
                    b.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
                });
            });

        public static IdentityBuilder AddIdentity(this IServiceCollection services)
        {
            return services.AddIdentity<User, IdentityRole>(option =>
            {
                //option.Password.RequiredLength = 7;
                //option.Password.RequireDigit = false;
                //option.Password.RequireUppercase = false;
                option.SignIn.RequireConfirmedAccount = true;
                option.SignIn.RequireConfirmedEmail = true;
                option.User.RequireUniqueEmail = true;
                option.Tokens.EmailConfirmationTokenProvider = Res.emailConfirmation;
            }).AddEntityFrameworkStores<AIODBContext>()
              .AddDefaultTokenProviders()
              .AddTokenProvider<EmailConfirmationTokenProvider<User>>(Res.emailConfirmation); ;
        }
    }
}
