using Microsoft.Extensions.Hosting;
using System;

namespace DeliVeggie.Product.Service
{
    class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
                    .ConfigureServices((services) =>
                    {
                        Startup.ConfigureServices(services);
                    });
    }
}
