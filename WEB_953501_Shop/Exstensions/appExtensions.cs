using WEB_953501_Shop.Middleware;
using Microsoft.AspNetCore.Builder;

namespace WEB_953501_Shop.Extensions
{
    public static class AppExtensions
    {
        public static IApplicationBuilder UseFileLogging(this
        IApplicationBuilder app)
        => app.UseMiddleware<LogMiddleware>();
    }
}