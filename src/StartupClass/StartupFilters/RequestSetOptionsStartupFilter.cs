using System;
using ASPNET.Fundamentals.StartupClass.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace ASPNET.Fundamentals.StartupClass.StartupFilters
{
    public class RequestSetOptionsStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return builder =>
            {
                builder.UseMiddleware<RequestSetOptionsMiddleware>();
                next(builder);
            };
        }
    }
}
