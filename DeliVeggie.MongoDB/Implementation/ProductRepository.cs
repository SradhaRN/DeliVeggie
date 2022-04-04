using DeliVeggie.Models.Entity.Product;
using DeliVeggie.MongoDB.Abstract;
using DeliVeggie.MongoDB.Mdo;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliVeggie.MongoDB.Implementation
{
    public class ProductRepository : IProductRepository
    {
       

        private readonly IMongoCollection<ProductMdo> _product;
        public ProductRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("DeliVeggieSradha");
            _product = database.GetCollection<ProductMdo>("Products");

            //One Time Only
            //_product.SeedInitialData();            
        }
        public async Task<List<ProductMdo>> GetAllAsync()
        {
            var response = _product.Find(c => true).ToList();
            return response;
        }

        public async Task<ProductMdo> GetProductByIdAsync(string productId)
        {

            var product = _product.Find(c => c.Id == productId).FirstOrDefault();
            if (product == null) return null;
            return product;
        }
    }
}