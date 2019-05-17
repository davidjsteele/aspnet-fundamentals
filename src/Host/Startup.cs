using System;
using ASPNET.Fundamentals.Host.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ASPNET.Fundamentals.Host
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;

        public Startup(IHostingEnvironment env)
        {
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            if (_env.IsDevelopment())
            {
                // Development configuration
            }
            else
            {
                // Staging/Production configuration
            }

            var contentRootPath = _env.ContentRootPath;
            Console.WriteLine($"Content root path = {contentRootPath}");

            services.AddTransient<CustomFileReader>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            IApplicationLifetime appLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });

            appLifetime.ApplicationStarted.Register(OnStarted);
            appLifetime.ApplicationStopping.Register(OnStopping);
            appLifetime.ApplicationStopped.Register(OnStopped);

            Console.CancelKeyPress += (sender, eventArgs) =>
            {
                appLifetime.StopApplication();
                // Don't terminate the process immediately, wait for the Main thread to exit gracefully.
                eventArgs.Cancel = true;
            };
        }

        private void OnStarted()
        {
            // Perform post-startup activities here
            Console.Write("Application has started.");
        }

        private void OnStopping()
        {
            // Perform on-stopping activities here
            Console.Write("Application is stopping.");
        }

        private void OnStopped()
        {
            // Perform post-stopped activities here
            Console.Write("Application stopped.");
        }
    }
}
