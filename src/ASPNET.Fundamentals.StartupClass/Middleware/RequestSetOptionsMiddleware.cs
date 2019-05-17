using ASPNET.Fundamentals.StartupClass.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ASPNET.Fundamentals.StartupClass.Middleware
{
    public class RequestSetOptionsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IOptions<AppOptions> _injectedOptions;

        public RequestSetOptionsMiddleware(RequestDelegate next, IOptions<AppOptions> injectedOptions)
        {
            _next = next;
            _injectedOptions = injectedOptions;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            Console.WriteLine("RequestSetOptionsMiddleware.Invoke");

            var option = httpContext.Request.Query["option"];

            if (!string.IsNullOrWhiteSpace(option))
            {
                _injectedOptions.Value.Option = WebUtility.HtmlEncode(option);
            }

            await _next(httpContext);
        }
    }
}
