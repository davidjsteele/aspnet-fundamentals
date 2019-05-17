using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace ASPNET.Fundamentals.Configuration
{
    public class Program
    {
        public static Dictionary<string, string> arrayDict = new Dictionary<string, string>
        {
            {"array:entries:0", "value0"},
            {"array:entries:1", "value1"},
            {"array:entries:2", "value2"},
            {"array:entries:4", "value4"},
            {"array:entries:5", "value5"}
        };

        public static Dictionary<string, string> _switchMappings = new Dictionary<string, string>
        {
            { "-CLKey1", "CommandLineKey1" },
            { "-CLKey2", "CommandLineKey2" }
        };

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddInMemoryCollection(arrayDict);
                    config.AddJsonFile("json_array.json", optional: false, reloadOnChange: false);
                    config.AddJsonFile("starship.json", optional: false, reloadOnChange: false);
                    config.AddXmlFile("tvshow.xml", optional: false, reloadOnChange: false);
                    config.AddIniFile("config.ini", optional: true, reloadOnChange: true);
                    // Call AddCommandLine last to allow arguments to override other configuration.
                    config.AddCommandLine(args, _switchMappings);
                    // Call AddEnvironmentVariables last if you need to allow environment
                    // variables to override values from other providers.
                    config.AddEnvironmentVariables(prefix: "PREFIX_");
                })
                .UseStartup<Startup>();
    }
}
