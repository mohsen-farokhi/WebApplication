using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;

namespace WebApplication.EndPoints.Server.Middlewares
{
    public static class GlobalExceptionMiddleware
    {
        public static void RegisterExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IEndpointConventionBuilder>();
                    if(contextFeature != null)
                    {
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(new ErrorInfo
                        {
                            StatusCode = context.Response.StatusCode,
                            ErrorMessage = "Internal Server Error."
                        }));
                    }

                });
            });
        }
    }
}
