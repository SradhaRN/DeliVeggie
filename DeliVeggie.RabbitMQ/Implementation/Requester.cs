using DeliVeggie.Models.Entity.Product;
using DeliVeggie.Models.Entity.Request;
using DeliVeggie.Models.Entity.Response;
using DeliVeggie.RabbitMQ.Abstract;
using EasyNetQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliVeggie.RabbitMQ.Implementation
{
    public class Requester : IRequester
    {
        public readonly IBus _bus;

        public Requester()
        {
            _bus = RabbitHutch.CreateBus("host=localhost");
        }

        public IEnumerable<Product> GetAllProductsRequest()
        {
            var request = new ProductListRequestData ();
            var response =  this._bus
                          .Rpc
                          .Request<ProductListRequestData, ProductListResponseData>(request);

            return MapResponseDataToProducts(response.Products);
        }

        public Product GetProductDetailsRequest(string id, int dayOfWeek)
        {
            var request = new ProductDetailsRequestData { Id = id, DayOfWeek = dayOfWeek };
            var response = _bus.Rpc.Request<ProductDetailsRequestData, ProductDetailsResponseData>(request);

            return MapMessageToDto(response);
        }

        #region PRIVATE METHODS
        private Product MapMessageToDto(ProductDetailsResponseData response)
        {
            return new Product
            {
                Id = response.Id,
                EntryDate = response.EntryDate,
                Name = response.Name,
                Price = response.Price
            };
        }

        private IEnumerable<Product> MapResponseDataToProducts(IEnumerable<ProductDetailsResponseData> response)
        {
            return response
                 .Select(x => this.MapMessageToDto(x))
                 .ToList();
        }
        #endregion
    }
}
