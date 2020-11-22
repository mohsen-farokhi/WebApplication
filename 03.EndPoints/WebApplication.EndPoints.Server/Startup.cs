using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication.Domain.DomainServices;
using WebApplication.Domain.Abstracts.DomainServices;
using WebApplication.Domain.Abstracts.UnitOfWork;
using WebApplication.Infrastructures.DataAccess.UnitOfWork;
using WebApplication.Infrastructures.DataAccess.Tools;
using WebApplication.Infrastructures.DataAccess.Tools.Enums;
using Microsoft.EntityFrameworkCore;
using WebApplication.Infrastructures.DataAccess.DbContexts;

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
            //services.AddDbContext<DatabaseContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("MyConnectionString")));

            services.AddCors(options =>
            {
                options.AddPolicy(AdminCorsPolicy,
                    builder =>
                    {
                        builder
                            .WithOrigins("http://localhost:5000")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            //.AllowCredentials()
                            ;
                    });
            });

            services.AddControllers();

            services.AddTransient<IUnitOfWork, UnitOfWork>(sp =>
            {
                Options options =
                    new Options
                    {
                        Provider =
                            (Provider)
                            int.Parse(Configuration.GetSection(key: "databaseProvider").Value),

                        ConnectionString =
                            Configuration.GetSection(key: "ConnectionStrings").GetSection(key: "MyConnectionString").Value,
                    };

                return new UnitOfWork(options: options);
            });

            services.AddScoped<IOperationService, OperationService>();
            services.AddScoped<ICultureService, CultureService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IUserService, UserService>();

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
