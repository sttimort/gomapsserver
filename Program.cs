using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace GoMapsCloudAPI
{
    public class Program
    {
        public static int Main(string[] args)
        {
            Console.WriteLine("Running GoMaps Cloud API.");

            var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();

            var builder = new WebHostBuilder()
                .UseConfiguration(config)
                .UseStartup<Startup>()
                .UseKestrel();

            var host = builder.Build();
            host.Run();

            return 0;
        }
    }
}
