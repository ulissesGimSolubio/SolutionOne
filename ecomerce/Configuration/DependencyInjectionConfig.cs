namespace Ecomerce.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static WebApplicationBuilder AddDependencyInjectionConfiguration(this WebApplicationBuilder builder)
        {
            //Injeção de dependência
            //taghelpers e exception filter
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            //builder.Services.AddControllersWithViews();

            return builder;
        }
    }
}
