using ASPNET.Fundamentals.StartupClass.StartupFilters;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ASPNET.Fundamentals.StartupClass
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddTransient<IStartupFilter, RequestSetOptionsStartupFilter>();
                })
                .UseStartup<Startup>();
    }
}
