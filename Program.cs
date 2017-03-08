using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace GoMapsCloudAPI
{
    public class Program
    {
        public static int Main()
        {
            Console.WriteLine("Running GoMaps Cloud API.");

            var builder = new WebHostBuilder()
                .UseStartup<Startup>()
                .UseKestrel()
                .UseUrls("http://localhost:5000");

            var host = builder.Build();
            host.Run();

            return 0;
        }
    }
}
