using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ASPNET.Fundamentals.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("hostsettings.json", optional: true)
                .AddCommandLine(args)
                .Build();

            return WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://*:5000")
                .UseConfiguration(configBuilder)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddXmlFile("config.xml", optional: true, reloadOnChange: true);
                })
                .ConfigureLogging(logging =>
                {
                    logging.SetMinimumLevel(LogLevel.Warning);
                })
                .ConfigureKestrel((context, options) =>
                {
                    options.Limits.MaxRequestBodySize = 20000000;
                })
                .UseDefaultServiceProvider((context, options) => {
                    options.ValidateScopes = true;
                })
                .UseStartup<Startup>();
        }
    }
}
