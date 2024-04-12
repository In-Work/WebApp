using Microsoft.AspNetCore.Builder;
using WebApp.Middleware;

namespace WebApp.Extensions
{
    public static class AppExtensions
    {
        public static IApplicationBuilder UseFileLogging(this IApplicationBuilder app) => app.UseMiddleware<LogMiddleware>();
    }
}
