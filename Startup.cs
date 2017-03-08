using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace GoMapsCloudAPI
{
    class Startup
    {
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            var serverAddressesFeature = app.ServerFeatures.Get<IServerAddressesFeature>();

            app.Run(async (context) =>
            {
                context.Response.ContentType = "text/html";
                
                await context.Response.WriteAsync("<p>GoMaps API Cloud</p>");
            });
        }
    }
}