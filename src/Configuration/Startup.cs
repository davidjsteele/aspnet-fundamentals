using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNET.Fundamentals.Configuration.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ASPNET.Fundamentals.Configuration
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                var numberKey = _config.GetValue("NumberKey", 99);

                var configSection = _config.GetSection("section1");
                var configSubSection = _config.GetSection("section2:subsection0");
                var children = configSection.GetChildren();

                var starship = new Starship();
                _config.GetSection("starship").Bind(starship);

                var tvShow = _config.GetSection("tvshow").Get<TvShow>();

                var arrayExample = _config.GetSection("array").Get<ArrayExample>();

                var jsonArrayExample = _config.GetSection("json_array").Get<JsonArrayExample>();

                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
