using DeliVeggie.Models.Entity.Product;
using DeliVeggie.MongoDB.Abstract;
using DeliVeggie.MongoDB.Mdo;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeliVeggie.MongoDB.Implementation
{
    public class PriceReductionRepository : IPriceReductionRepository
    {

        private readonly IMongoCollection<PriceReductionMdo> _priceReduction;
        public PriceReductionRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("DeliVeggieSradha");
            _priceReduction = database.GetCollection<PriceReductionMdo>("PriceReductions");

            //One Time Only
            //_priceReduction.SeedInitialPriceDeductionData();
        }


        public async Task<PriceReductionMdo> GetPriceReductionAsync(int dayOfWeek)
        {

            var priceReductionDoc = _priceReduction.Find(c => c.DayOfWeek == dayOfWeek).FirstOrDefault();
            if (priceReductionDoc == null) return null;
            return priceReductionDoc;
        }
    }
}
