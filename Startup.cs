using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using GoMapsCloudAPI.Filters;



namespace GoMapsCloudAPI
{
    class Startup
    {   
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => {
                options.Filters.Add(new ClientIdentificationFilter());
                options.Filters.Add(new GenericActionFilter());
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}