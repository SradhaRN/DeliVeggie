using System;
using System.Collections.Generic;
using System.Text;
using DeliVeggie.MongoDB.Abstract;
using DeliVeggie.MongoDB.Implementation;
using DeliVeggie.Product.Service.Abstract;
using DeliVeggie.Product.Service.Implementation;
using EasyNetQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace DeliVeggie.Product.Service
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IPriceReductionRepository, PriceReductionRepository>();

            services.AddSingleton<IProductResponseService, ProductResponseService>();
            services.AddHostedService<ProductResponseService>();

        }
    }
}