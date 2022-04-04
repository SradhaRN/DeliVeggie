using DeliVeggie.Models.Entity.Product;
using DeliVeggie.RabbitMQ.Abstract;
using DeliVeggie.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliVeggie.Services.Implementation
{
    public class ProductService : IProductService
    {

        private readonly IRequester _requester;

        public ProductService(IRequester requester)
        {
            _requester = requester;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            var data = _requester.GetAllProductsRequest();
            return data;
        }

        public Product GetProductDetails(string productId)
        {
            var data = _requester.GetProductDetailsRequest(productId, (int)DateTime.Today.DayOfWeek + 1);
            return data;
        }
    }
}
