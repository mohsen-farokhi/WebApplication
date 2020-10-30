using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplication.EndPoints.BlazorApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped
                (sp => new HttpClient
                {
                    BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseUrl"))
                });

            await builder.Build().RunAsync();
        }
    }
}
