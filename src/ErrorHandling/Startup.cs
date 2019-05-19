// The ErrorHandler directives must be used along with the ProdEnvironment directive.
// The DeveloperExceptionPage is seen only when the DevEnvironment directive is used.

// StatusCodePages
// StatusCodePagesWithLambda
// StatusCodePagesWithFormatString
// StatusCodePagesWithRedirect
// StatusCodePagesWithReExecute
#define StatusCodePagesWithRedirect // or StatusCodePagesWithLambda or // StatusCodePagesWithFormatString or StatusCodePagesWithRedirect or StatusCodePagesWithReExecute

// ErrorHandlerPage
// ErrorHandlerLambda
#define ErrorHandlerPage

// ProdEnvironment or DevEnvironment
#define DevEnvironment

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ASPNET.Fundamentals.ErrorHandling
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
#if ProdEnvironment
            env.EnvironmentName = "Production";
#endif            
#if DevEnvironment
            env.EnvironmentName = "Development";
#endif

#if ErrorHandlerPage
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
#endif
#if ErrorHandlerLambda
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
               app.UseExceptionHandler(errorApp =>
               {
                    errorApp.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "text/html";

                        await context.Response.WriteAsync("<html lang=\"en\"><body>\r\n");
                        await context.Response.WriteAsync("ERROR!<br><br>\r\n");

                        var exceptionHandlerPathFeature = 
                            context.Features.Get<IExceptionHandlerPathFeature>();

                        // Use exceptionHandlerPathFeature to process the exception (for example, 
                        // logging), but do NOT expose sensitive error information directly to 
                        // the client.

                        if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
                        {
                            await context.Response.WriteAsync("File error thrown!<br><br>\r\n");
                        }

                        await context.Response.WriteAsync("<a href=\"/\">Home</a><br>\r\n");
                        await context.Response.WriteAsync("</body></html>\r\n");
                        await context.Response.WriteAsync(new string(' ', 512)); // IE padding
                    });
                });
            app.UseHsts();
            }
#endif
#if StatusCodePages
            app.UseStatusCodePages();
#endif
#if StatusCodePagesWithFormatString
            app.UseStatusCodePages(
                "text/plain", "Status code page, status code: {0}");
#endif
#if StatusCodePagesWithLambda
            app.UseStatusCodePages(async context =>
            {
                context.HttpContext.Response.ContentType = "text/plain";

                await context.HttpContext.Response.WriteAsync(
                    "Status code page, status code: " + 
                    context.HttpContext.Response.StatusCode);
            });
#endif
#if StatusCodePagesWithRedirect
            app.UseStatusCodePagesWithRedirects("/StatusCode?code={0}");
#endif

#if StatusCodePagesWithReExecute
            app.UseStatusCodePagesWithReExecute("/StatusCode","?code={0}");
#endif

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
