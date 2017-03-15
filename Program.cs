using System;
using Microsoft.AspNetCore.Hosting;
namespace GoMapsCloudAPI
{
    public class Program
    {
        public static int Main(string[] args)
        {
            Console.WriteLine("Running GoMaps Cloud API.");

            var builder = new WebHostBuilder()
                .UseStartup<Startup>()
                .UseKestrel();

            var host = builder.Build();
            host.Run();

            return 0;
        }
    }
}
