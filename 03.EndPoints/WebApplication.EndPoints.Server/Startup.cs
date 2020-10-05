using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication.Infrastructures.DataAccess.DbContexts;
using WebApplication.Domain.DomainServices;
using WebApplication.Domain.Abstracts.DomainServices;
using WebApplication.Domain.Abstracts.Repositories;
using WebApplication.Infrastructures.DataAccess.Repositories;

namespace WebApplication.EndPoints.Server
{
    public class Startup
    {
        public const string AdminCorsPolicy = "_ADMIN_CORS_POLICY";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WebApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddCors(options =>
            {
                options.AddPolicy(AdminCorsPolicy,
                    builder =>
                    {
                        builder
                            .WithOrigins("http://localhost:57624")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            //.AllowCredentials()
                            ;
                    });
            });

            services.AddControllers();

            services.AddScoped<ICultureRepository, CultureRepository>();
            services.AddScoped<ICultureService, CultureService>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(policyName: AdminCorsPolicy);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
