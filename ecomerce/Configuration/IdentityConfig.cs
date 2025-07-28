using Ecomerce.Data;
using Microsoft.AspNetCore.Identity;

namespace Ecomerce.Configuration
{
    public static class IdentityConfig
    {
        public static WebApplicationBuilder AddIdentityConfiguration(this WebApplicationBuilder builder)
        {
            //original
            /*builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();*/

            /*alterado*/
            // Adiciona o Identity com configurações para exigir confirmação de conta e configurar as roles
            builder.Services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                // Configurações de bloqueio de contas
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
            }).AddEntityFrameworkStores<ApplicationDbContext>()
              .AddDefaultTokenProviders(); // Adiciona provedores de tokens padrão

            return builder;
        }
    }
}
