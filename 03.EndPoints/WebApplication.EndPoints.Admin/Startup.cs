using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using WebApplication.Infrastructures.DataAccess.DbContexts;
using WebApplication.Domain.Abstracts.Repositories;
using WebApplication.Infrastructures.DataAccess.Repositories;
using WebApplication.Domain.DomainServices;
using WebApplication.Domain.Abstracts.DomainServices;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Razor;
using Infrastructures;
using Microsoft.AspNetCore.Mvc;
using WebApplication.EndPoints.Admin.Resources;

namespace WebApplication.EndPoints.Admin
{
    public class Startup
    {
        public const string AdminCorsPolicy = "_ADMIN_CORS_POLICY";
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
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

            #region Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = "/Login";
                options.LogoutPath = "/Logout";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            });
            #endregion

            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            })
            .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix,
                options => { options.ResourcesPath = "Resources"; })
            .AddDataAnnotationsLocalization(options =>
            {
                options.DataAnnotationLocalizerProvider = (type, factory) =>
                factory.Create(typeof(ShareResource));
            })
            .AddRazorRuntimeCompilation();

            services.AddRazorPages();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("fa-IR"),
                    new CultureInfo("en-US"),
                };
                options.DefaultRequestCulture = new RequestCulture("fa-IR");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            services.AddSingleton<CultureLocalizer>();

            services.AddScoped<ICultureRepository, CultureRepository>();
            services.AddScoped<ICultureService, CultureService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseCors(policyName: AdminCorsPolicy);

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            var supportedCultures = new List<CultureInfo>()
            {
                new CultureInfo("fa-IR"),
                new CultureInfo("en-US")
            };
            var options = new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture("fa-IR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                RequestCultureProviders = new List<IRequestCultureProvider>()
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider()
                }
            };
            app.UseRequestLocalization(options);

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers(); //api

                endpoints.MapAreaControllerRoute(
                    name: "AdministratorArea",
                    areaName: "Administrator",
                    pattern: "Administrator/{controller=User}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "CmsArea",
                    areaName: "Cms",
                    pattern: "Cms/{controller=Post}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });

        }
    }
}
