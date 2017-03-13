using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using GoMapsCloudAPI.Filters;
using GoMapsCloudAPI.Models;



namespace GoMapsCloudAPI
{
    class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<UsersContext>(options =>
                options.UseSqlServer(connection));
            services.AddMvc(options => {
                options.Filters.Add(new ClientIdentificationFilter());
                options.Filters.Add(new GenericActionFilter());
            });
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            var serverAddressesFeature = app.ServerFeatures.Get<IServerAddressesFeature>();

            app.UseMvc();
            app.Run(async (context) =>
            {
                context.Response.ContentType = "text/html";

                await context.Response.WriteAsync("<p>GoMaps API Cloud</p>");
            });
        }
    }
}