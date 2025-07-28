using Ecomerce.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;

namespace Ecomerce.Configuration
{
    public static class MvcConfig
    {
        public static WebApplicationBuilder AddMvcConfiguration(this WebApplicationBuilder builder)
        {
            //Adicionando o arquivo de configuração appsettings.json
            //Caso altere a configuração em produção é necessário reiniciar o servidor
            /*builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.jason", true, true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.jason", true, true)
                .AddEnvironmentVariables();*/
            
            //Global Validate Antiforgery Token
            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());                
            });


            // Configuração do Razor para entender caso tenha uma pasta Areas ou mudança para outro nome como Modulos
            builder.Services.Configure<RazorViewEngineOptions>(options =>
            {
                options.AreaViewLocationFormats.Clear();
                options.AreaViewLocationFormats.Add("/Areas/{2}/Views/{1}/{0}" + RazorViewEngine.ViewExtension); //Ou trocar a parte de + por .cshtml
                options.AreaViewLocationFormats.Add("/Areas/{2}/Views/Shared/{0}" + RazorViewEngine.ViewExtension); //Ou trocar a parte de + por .cshtml
                options.AreaViewLocationFormats.Add("/Views/Shared/{0}" + RazorViewEngine.ViewExtension); //Ou trocar a parte de + por .cshtml
            });

            // Add services to the container.
            var connectionString = builder
                .Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            //Obrigando a usar hsts
            builder.Services.AddHsts(options =>
            {
                options.Preload = true; //suportada pelos browsers
                options.IncludeSubDomains = true; //suportada pelos browsers e subdominios
                options.MaxAge = TimeSpan.FromDays(60); //expiracao em 60 dias
                options.ExcludedHosts.Add("example.com"); //posso excluir a verificacao de um host
                options.ExcludedHosts.Add("www.example.com");//posso excluir a verificacao de um host
            });

            return builder;
        }

        public static WebApplication UseMvcConfiguration(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            // Adicione o middleware de tratamento de exceções
            app.UseMiddleware<Ecomerce.Middleware.ExceptionMiddleware>();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");           

            app.MapRazorPages();

            return app;
        }
    }
}
