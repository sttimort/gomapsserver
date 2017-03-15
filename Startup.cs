using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using GoMapsCloudAPI.Models;
using GoMapsCloudAPI.Filters;
using GoMapsCloudAPI.Interfaces;



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
                options.UseSqlServer(connection)
            );
            services.AddMvc(options => {
                options.Filters.Add(new ClientIdentificationFilter());
                options.Filters.Add(new GenericActionFilter());
            });
            services.AddSingleton<IUsersRepository, UsersRepository>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}