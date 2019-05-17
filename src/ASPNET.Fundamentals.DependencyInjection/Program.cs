using System;
using ASPNET.Fundamentals.DependencyInjection.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ASPNET.Fundamentals.DependencyInjection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                try
                {
                    var serviceContext = services.GetRequiredService<IMyDependency>();
                    serviceContext.WriteMessage("I resolved a service from main!");
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred.");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
