using Microsoft.AspNetCore.Hosting;

namespace ASPNET.Fundamentals.Host.Utilities
{
    public class CustomFileReader
    {
        private readonly IHostingEnvironment _env;

        public CustomFileReader(IHostingEnvironment env)
        {
            _env = env;
        }

        public string ReadFile(string filePath)
        {
            var fileProvider = _env.WebRootFileProvider;

            // Process the file here

            return string.Empty;
        }
    }
}
