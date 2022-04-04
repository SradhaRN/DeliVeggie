using DeliVeggie.Models.Entity.Product;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliVeggie.MongoDB
{
    public static class SeedData
    {
        public static void SeedInitialData(this IMongoCollection<Product> collection)
        {
            collection.InsertOne(new Product
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Uncle Ben's Rice",
                Price = 15,
                EntryDate = DateTime.Now
            });
            collection.InsertOne(new Product
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Potatoes",
                Price = 17.5,
                EntryDate = DateTime.Now
            });
        }
        public static void SeedInitialPriceDeductionData(this IMongoCollection<PriceReduction> collection)
        {
            collection.InsertOne(new PriceReduction
            {
                DayOfWeek = 1,
                Reduction = 0
            });
            collection.InsertOne(new PriceReduction
            {
                DayOfWeek = 2,
                Reduction = 0
            });
            collection.InsertOne(new PriceReduction
            {
                DayOfWeek = 3,
                Reduction = 0
            });
            collection.InsertOne(new PriceReduction
            {
                DayOfWeek = 4,
                Reduction = 0
            });
            collection.InsertOne(new PriceReduction
            {
                DayOfWeek = 5,
                Reduction = 0
            });
            collection.InsertOne(new PriceReduction
            {
                DayOfWeek = 6,
                Reduction = 0.2
            });
            collection.InsertOne(new PriceReduction
            {
                DayOfWeek = 7,
                Reduction = 0.5
            });
        }
    }
}
