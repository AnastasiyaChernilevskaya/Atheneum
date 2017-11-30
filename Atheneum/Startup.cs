using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Atheneum.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Atheneum
{
    public class Startup
    {
        private IConfigurationRoot _configuration;

        public Startup(IHostingEnvironment environment)
        {
            var ConfigBuilder = new ConfigurationBuilder().SetBasePath(environment.ContentRootPath)
                        .AddJsonFile("appsettings.json");
            _configuration = ConfigBuilder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_configuration);
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AtheneumContext>(options =>
               options.UseSqlServer(connectionString));
            services.AddTransient<AtheneumDbInitializer>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AtheneumDbInitializer seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(" Welcome to Dotnet Core !!");
            });

            try
            {
                seeder.SeedData().Wait();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
    }
}
